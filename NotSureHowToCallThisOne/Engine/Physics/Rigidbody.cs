﻿using System;
using System.Drawing;
using System.Numerics;

namespace NotSureHowToCallThisOne
{
    public class Rigidbody : IComponent
    {
        public Rigidbody(GameObject parent, ICollider collider)
        {
            this.gameObject = parent;
            this.collider = collider;
            this.transform = gameObject.transform;
            this.mass = 1f;
        }

        private float _mass;
        private bool _isStatic;
        
        public ICollider collider { get; }
        public float friction { get; set; } = .1f;
        public GameObject gameObject { get; }
        public float inverseMass { get; private set; }
        public bool isKinematic { get; set; }
        public bool isStatic { get => _isStatic; set { _isStatic = value; if (_isStatic) mass = 999999; else mass = 1; } }
        public float mass { get => _mass; set { _mass = value; inverseMass = 1 / _mass; } }
        public Transform transform { get; }
        public bool useGravity { get; set; }
        public Vector2 velocity { get; set; }

        public void ApplyForce(Vector2 force) {
            velocity += force;
        }

        public void ApplyForce(Vector2 direction, float magnitude)
        {
            velocity += direction * magnitude;
        }

        public void Update()
        {

        }

        public override string ToString()
        {
            return $"{velocity}";
        }

        public void FixedUpdate()
        {
        }
    }
}
