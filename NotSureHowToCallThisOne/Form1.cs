using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;
        private Game game;
        private Input inputSystem;
        private PhysicsV2 physics;
        private Graphics graphics;
        private Audio audio;
        private Task physicsTask;
        private Task graphicsTask;
        private Task mainTask;
        private Task audioTask;
        private CancellationTokenSource source = new CancellationTokenSource();
        private static string PhysicsElapsed;
        private static string GameElapsed;
        internal static string OtherNewVelocity;
        internal static string NewVelocity;
        private const int fpsLimiter = 1000;

        public static string Delta { get; internal set; }
        public static string GraphicsElapsed { get; internal set; }
        public static string RelativePositioning { get; internal set; }

        public Form1()
        {
            InitializeComponent();

            var action = new Action<ISystem, float>((system, interval) =>
            {
                var start = DateTime.Now.Ticks;
                long previous = 0;

                do
                {
                    var newPrevious = DateTime.Now.Ticks;
                    var delta = (newPrevious - previous) / TimeSpan.TicksPerMillisecond;
                        system.Update(delta);
                    if (delta >= interval)
                    {
                        previous = newPrevious;
                    }
                } while (true);
            });

            ResourceLoader.LoadImage(".\\Resources\\player1.png", "p1");
            ResourceLoader.LoadImage(".\\Resources\\player2.png", "p2");
            ResourceLoader.LoadImage(".\\Resources\\player1_hit.png", "p1hit");
            ResourceLoader.LoadImage(".\\Resources\\player2_hit.png", "p2hit");
            ResourceLoader.LoadImage(".\\Resources\\ball.png", "ball");
            ResourceLoader.LoadSound(".\\Resources\\hit.wav", "hit");

            

            inputSystem = new Input();
            KeyUp += inputSystem.OnKeyUp;
            KeyDown += inputSystem.OnKeyDown;

            DoubleBuffered = true;
            physics = new PhysicsV2();
            graphics = new Graphics(doubleBufferedPanel1);
            audio = new Audio();
            game = new Game(doubleBufferedPanel1, physics, inputSystem, graphics, audio);
            physicsTask = new Task(() => {
                var start = DateTime.Now.Ticks;
                long previous = 0;
                var interval = 1000f / 120;
                var physicsSw = new Stopwatch();
                var gameSw = new Stopwatch();
                do
                {
                    var newPrevious = DateTime.Now.Ticks;
                    var delta = (newPrevious - previous) / TimeSpan.TicksPerMillisecond;
                    if (delta >= interval)
                    {
                        physicsSw.Restart();
                        physics.Simulate(delta);
                        physicsSw.Stop();
                        Form1.PhysicsElapsed = $"{physicsSw.ElapsedMilliseconds}";
                        //  any changes that need to be made go here
                        gameSw.Restart();
                        game.FixedUpdate(delta);
                        gameSw.Stop();
                        Form1.GameElapsed = $"{gameSw.ElapsedMilliseconds}";
                        previous = newPrevious;
                    }
                } while (true);
            }, source.Token);
            graphicsTask = new Task(() => {
                var start = DateTime.Now.Ticks;
                long previous = 0;
                var interval = 1000f / 60;
                do
                {
                    var newPrevious = DateTime.Now.Ticks;
                    var delta = (newPrevious - previous) / TimeSpan.TicksPerMillisecond;
                    if (delta >= interval)
                    {
                        graphics.Update(delta);
                        previous = newPrevious;
                    }
                } while (true);
            }, source.Token);
            mainTask = new Task(() => action(game, 1000f / fpsLimiter), source.Token);

            audioTask = new Task(() => action(audio, 1000f / fpsLimiter), source.Token);

            physicsTask.Start();
            graphicsTask.Start();
            mainTask.Start();
            audioTask.Start();

            Application.ApplicationExit += OnApplicationQuit;

            var camera = new GameObject();
            var cameraCam = new Camera(camera, doubleBufferedPanel1);
            camera.AddComponent(cameraCam);
            var cameraCollider = new BoxCollider(camera);
            cameraCollider.size = new Size(Width, Height);
            cameraCollider.isTrigger = true;
            camera.AddComponent(cameraCollider);
            //camera.AddComponent(new FollowPlayer(camera, player));

            pictureBox1.BackColor = Color.FromArgb(127, Color.Green);
            pictureBox1.Visible = false;

            timer = new System.Windows.Forms.Timer
            {
                Interval = 1000 / 240
            };
            var rb = game.player2.GetComponent<Rigidbody>();
            //rb.useGravity = true;
            timer.Tick += (source, e) => {
                //lbl_Score.Text = $"Delta: {Delta} || Physics.Update: {PhysicsElapsed} || Game.FixedUpdate: {GameElapsed} || Graphics: {GraphicsElapsed}";
                //lbl_Score.Text = $"Score: {game.scores[0]} - {game.scores[1]}";
                lbl_Score.Text = $"{PhysicsElapsed}";
                lbl_NewVelocity.Text = $"{NewVelocity}";
                lbl_OtherNewVelocity.Text = $"{OtherNewVelocity}";
                pictureBox1.Size = cameraCollider.size;
                pictureBox1.Location = new Point((int)cameraCollider.center.X, (int)cameraCollider.center.Y);
                lbl_Input.Text = $"Left:{inputSystem.IsPressed(Keys.Left)}\nRight:{inputSystem.IsPressed(Keys.Right)}\nDown:{inputSystem.IsPressed(Keys.Down)}\nUp:{inputSystem.IsPressed(Keys.Up)}";
            };

            timer.Start();


        }

        public class CustomContext : SynchronizationContext
        {

        }

        private void OnApplicationQuit(object sender, EventArgs e)
        {
            source.Cancel();
        }
        ~Form1()
        {
            timer.Stop();
            timer.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
