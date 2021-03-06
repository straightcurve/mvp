﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public class Game
    {
        private Control canvas;
        private Audio audio;
        private GameObject ball;
        public GameObject player2;
        public GameObject player1;
        private object syncEntities = new object();
        public readonly int[] scores = new int[2];
        public List<GameObject> Entities { get; } = new List<GameObject>();

        public Game(Control canvas, IPhysicsEngine physics, Input inputSystem, Graphics graphics, Audio audio)
        {
            this.audio = audio;
            this.canvas = canvas;

            ResourceLoader.LoadImage(".\\Resources\\player1.png", "p1");
            ResourceLoader.LoadImage(".\\Resources\\player2.png", "p2");
            ResourceLoader.LoadImage(".\\Resources\\player1_hit.png", "p1hit");
            ResourceLoader.LoadImage(".\\Resources\\player2_hit.png", "p2hit");
            ResourceLoader.LoadImage(".\\Resources\\ball.png", "ball");
            ResourceLoader.LoadSound(".\\Resources\\hit.wav", "hit");

            CreateWall(canvas.Width / 2, 50, new Size(canvas.Width, 100));
            CreateWall(canvas.Width / 2, canvas.Height - 50, new Size(canvas.Width, 100));
            //CreateWall(50, canvas.Height / 2, new Size(100, canvas.Height));
            //CreateWall(canvas.Width - 50, canvas.Height / 2, new Size(100, canvas.Height));

            CreateGoal(25, canvas.Height / 2, new Size(50, canvas.Height / 3), 0);
            CreateGoal(canvas.Width - 26, canvas.Height / 2, new Size(50, canvas.Height / 3), 1);

            CreateBall(physics);
            CreatePlayer1(inputSystem);
            CreatePlayer2(inputSystem);

            //var responsive = new GameObject("responsive");
            //responsive.AddComponent(new Responsive(responsive, form, entities));

            lock (syncEntities)
            {
                //entities.Add(responsive);
                Entities.ForEach(entity =>
                {
                    var rigidbody = entity.GetComponent<Rigidbody>();
                    if (rigidbody != null)
                        physics.AddRigidbody(rigidbody);
                    else
                    {
                        var collider = entity.GetComponent<ICollider>();
                        if (collider != null)
                            physics.Add(collider);
                    }
                    var renderer = entity.GetComponent<Renderer>();
                    if (renderer != null)
                        graphics.Add(renderer);
                });
            }
        }

        private void OnScored(int playerGoal)
        {
            scores[(playerGoal + 1) % 2]++;
        
            Reset();
        }
        private void CreateBall(IPhysicsEngine physics)
        {
            this.ball = new GameObject("Ball");
            var renderer = new Renderer(ball, canvas);
            renderer.size = new Size(25, 25);
            renderer.SetSprite("ball");
            ball.AddComponent(renderer);
            var collider = new BoxCollider(ball);
            collider.size = renderer.size;
            ball.AddComponent(collider);
            var rigidbody = new Rigidbody(ball, collider);
            rigidbody.mass = 10;
            rigidbody.friction = 0.001f;
            rigidbody.drag = 10f;
            rigidbody.useGravity = true;
            ball.AddComponent(rigidbody);
            var ballComp = new Ball(ball);
            ball.AddComponent(ballComp);
            ball.transform.position = new Vector2(canvas.Width / 2, canvas.Height / 2);

            lock(syncEntities)
            {
                Entities.Add(ball);
            }
        }

        private void CreatePlayer1(Input inputSystem)
        {
            this.player1 = new GameObject("Player 1");
            var renderer = new Renderer(player1, canvas);
            renderer.size = new Size(50, 50);
            renderer.SetSprite("p1");
            player1.AddComponent(renderer);
            var collider = new BoxCollider(player1);
            collider.size = renderer.size;
            player1.AddComponent(collider);
            var rigidbody = new Rigidbody(player1, collider);
            rigidbody.mass = 50;
            player1.AddComponent(rigidbody);
            var movement = new Movement(player1, inputSystem, rigidbody);
            movement.up = Keys.W;
            movement.left = Keys.A;
            movement.down = Keys.S;
            movement.right = Keys.D;
            player1.AddComponent(movement);
            var boundary = new Boundary(player1, canvas);
            player1.AddComponent(boundary);
            var hit = new PlayerHit(player1, renderer, canvas, 1, audio);
            player1.AddComponent(hit);
            player1.transform.position = new Vector2(canvas.Width / 4, canvas.Height / 2);

            lock (syncEntities)
            {
                Entities.Add(player1);
            }
        }
        private void CreatePlayer2(Input inputSystem)
        {
            player2 = new GameObject("Player 2");
            var renderer = new Renderer(player2, canvas);
            renderer.size = new Size(50, 50);
            renderer.SetSprite("p2");
            player2.AddComponent(renderer);
            var collider = new BoxCollider(player2);
            collider.size = renderer.size;
            player2.AddComponent(collider);
            var rigidbody = new Rigidbody(player2, collider);
            rigidbody.mass = 50;
            player2.AddComponent(rigidbody);
            player2.AddComponent(new Movement(player2, inputSystem, rigidbody));
            var boundary = new Boundary(player2, canvas);
            player2.AddComponent(boundary);
            var hit = new PlayerHit(player2, renderer, canvas, 2, audio);
            player2.AddComponent(hit);
            player2.transform.position = new Vector2(canvas.Width - canvas.Width / 4, canvas.Height / 2);

            lock (syncEntities)
            {
                Entities.Add(player2);
            }
        }

        private void CreateGoal(int x, int y, Size size, int player)
        {
            var goal = new GameObject($"Goal {player + 1}");
            var renderer = new Renderer(goal, canvas);
            renderer.size = size;
            goal.AddComponent(renderer);
            var collider = new BoxCollider(goal);
            collider.isTrigger = true;
            collider.size = size;
            goal.AddComponent(collider);
            //var rigidbody = new Rigidbody(goal, collider);
            //rigidbody.isStatic = true;
            //goal.AddComponent(rigidbody);
            var goalComp = new Goal(goal, player);
            goalComp.Scored += OnScored;
            goal.AddComponent(goalComp);
            goal.transform.position = new Vector2(x, y);

            lock (syncEntities)
            {
                Entities.Add(goal);
            }
        }
        private void CreateWall(float x, float y, Size size)
        {
            var wall = new GameObject($"Wall ({x}, {y})");
            var renderer = new Renderer(wall, this.canvas);
            renderer.size = size;
            wall.AddComponent(renderer);
            var collider = new BoxCollider(wall);
            collider.size = size;
            collider.isStatic = true;
            wall.AddComponent(collider);
            //var rigidbody = new Rigidbody(wall, collider);
            //rigidbody.isStatic = true;
            //wall.AddComponent(rigidbody);
            wall.transform.position = new Vector2(x, y);

            lock (syncEntities)
            {
                Entities.Add(wall);
            }
        }

        public void Reset()
        {
            ball.GetComponent<Rigidbody>().velocity = new Vector2();
            player1.GetComponent<Rigidbody>().velocity = new Vector2();
            player2.GetComponent<Rigidbody>().velocity = new Vector2();
            ball.transform.position = new Vector2(canvas.Width / 2, canvas.Height / 2);
            player1.transform.position = new Vector2(canvas.Width / 4, canvas.Height / 2);
            player2.transform.position = new Vector2(canvas.Width - canvas.Width / 4, canvas.Height / 2);
        }

        public void FixedUpdate()
        {
            lock (syncEntities)
            {
                for (int i = 0; i < Entities.Count; i++)
                {
                    Entities[i].FixedUpdate();
                }
            }
        }

        public void Update() {
            lock(syncEntities)
            {
                for (int i = 0; i < Entities.Count; i++)
                {
                    Entities[i].Update();
                }
            }
        }
    }
}
