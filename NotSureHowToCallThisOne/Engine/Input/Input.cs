using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public class Input {

        private readonly bool[] keys = new bool[255];

        public bool IsPressed(Keys key) {
            var pressed = false;
            lock (keys.SyncRoot)
                pressed = keys[(int)key];
            return pressed;
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            lock (keys.SyncRoot)
                keys[(int)e.KeyCode] = true;
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            lock (keys.SyncRoot)
                keys[(int)e.KeyCode] = false;
        }
    }
}
