using System.Drawing;
using System.Numerics;

namespace NotSureHowToCallThisOne
{
    public interface ICollider : IComponent
    {
        Vector2 center { get; }
        GameObject gameObject { get; }
        Size halfSize { get; }
        bool isStatic { get; set; }
        bool isTrigger { get; set; }
        Size size { get; set; }
        ColliderType type { get; }
    }
}
