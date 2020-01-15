using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public partial class Form1 : Form
    {
        private Game game;
        private Input inputSystem;
        private IPhysicsEngine physics;
        private Graphics graphics;
        private Audio audio;
        private CancellationTokenSource source = new CancellationTokenSource();
        private SynchronizationContext graphicsContext;

        public Form1()
        {
            InitializeComponent();

            inputSystem = new Input();
            KeyUp += inputSystem.OnKeyUp;
            KeyDown += inputSystem.OnKeyDown;

            graphicsContext = SynchronizationContext.Current;

            var gameLoop = new Task(() => {
                var sw = new HPTimer();
                sw.Start();
                double t = 0.0;
                const double dt = 0.01;
                Time.deltaTime = (float)dt;
                Time.fixedDeltaTime = (float)dt;
                double currentTime = sw.Elapsed;
                double accumulator = 0.0;

                while (true)
                {
                    double newTime = sw.Elapsed;
                    double frameTime = newTime  - currentTime;
                    currentTime = newTime;

                    accumulator += frameTime;

                    while (accumulator >= dt)
                    {
                        game.FixedUpdate();

                        physics.Simulate((float)dt);

                        game.Update();
                        accumulator -= dt;
                        t += dt;
                    }

                    //  render
                    try
                    {
                        graphicsContext.Send((state) =>
                        {
                            lbl_Score.Text = $"Score: {game.scores[0]} - {game.scores[1]}";
                            doubleBufferedPanel1.Invalidate();
                            doubleBufferedPanel1.Update();
                        }, null);
                    }
                    catch
                    {

                    }
                }
            }, source.Token);

            physics = new PhysicsV3();
            graphics = new Graphics(doubleBufferedPanel1);
            audio = new Audio();
            game = new Game(doubleBufferedPanel1, physics, inputSystem, graphics, audio);          

            gameLoop.Start();

            Application.ApplicationExit += OnApplicationQuit;
        }

        private void OnApplicationQuit(object sender, EventArgs e)
        {
            source.Cancel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }

    public static class Time
    {
        public static float deltaTime;
        public static float fixedDeltaTime;
    }
}
