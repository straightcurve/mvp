using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel() : base() {
            DoubleBuffered = true;
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        } 
    }
}
