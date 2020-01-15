using System;
using System.Collections.Generic;

namespace NotSureHowToCallThisOne
{
    public class GameObject
    {
        private readonly List<IComponent> components = new List<IComponent>();

        public GameObject()
        {
            transform = new Transform(this);
            lock(SyncRoot)
                components.Add(transform);
        }

        public GameObject(string name) : this()
        {
            lock(SyncRoot)
                this.name = name;
        }

        public string name { get; set; }
        public Transform transform { get; private set; }

        public object SyncRoot { get; } = new object();

        public event Action<ICollider> OnTriggerEnter;
        public event Action<ICollider> OnTriggerStay;
        public event Action<ICollider> OnTriggerExit;
        public event Action<ICollider> OnCollisionEnter;
        public event Action<ICollider> OnCollisionStay;
        public event Action<ICollider> OnCollisionExit;

        public void AddComponent(IComponent component)
        {
            lock(SyncRoot)
                components.Add(component);
        }

        public T GetComponent<T>() where T: class, IComponent
        {
            lock(SyncRoot)
            {
                for (int i = 0; i < components.Count; i++)
                {
                    var component = components[i] as T;
                    if (component == null)
                        continue;
                    return component;
                }
            }
            return null;
        }

        public void Update() {
            lock (SyncRoot)
            {
                for (int i = 0; i < components.Count; i++)
                {
                    components[i].Update();
                }
            }
        }

        public void InvokeOnTriggerStay(ICollider collider)
        {
            lock (SyncRoot)
                OnTriggerStay?.Invoke(collider);
        }

        public void InvokeOnCollisionStay(ICollider collider)
        {
            lock(SyncRoot)
                OnCollisionStay?.Invoke(collider);
        }
        public void FixedUpdate()
        {
            lock(SyncRoot)
            {
                for (int i = 0; i < components.Count; i++)
                {
                    components[i].FixedUpdate();
                }
            }
        }

        public void InvokeOnTriggerEnter(ICollider other)
        {
            lock(SyncRoot)
                OnTriggerEnter?.Invoke(other);
        }

        public void InvokeOnCollisionEnter(ICollider other)
        {
            lock(SyncRoot)
                OnCollisionEnter?.Invoke(other);
        }

        public void InvokeOnTriggerExit(ICollider other)
        {
            lock(SyncRoot)
                OnTriggerExit?.Invoke(other);
        }

        public void InvokeOnCollisionExit(ICollider other)
        {
            lock(SyncRoot)
                OnCollisionExit?.Invoke(other);
        }
    }
}
