using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public class Input {

        private readonly bool[] keys = new bool[255];

        public Input()
        {

        }

        public bool IsPressed(Keys key) {
            return keys[(int)key];
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            keys[(int)e.KeyCode] = true;
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            keys[(int)e.KeyCode] = false;
        }
    }
}
