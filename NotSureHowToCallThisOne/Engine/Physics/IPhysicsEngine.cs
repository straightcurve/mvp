namespace NotSureHowToCallThisOne
{
    public interface IPhysicsEngine
    {
        bool Add(GameObject gameObject);
        void Add(ICollider collider);
        void AddRigidbody(Rigidbody rigidbody);
        bool IsCollisionBetween(ICollider a, ICollider b);
        void Simulate(float delta);
    }
}