using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public class Audio : ISystem {
        private readonly Queue<SoundPlayer> sounds = new Queue<SoundPlayer>();
        private object syncSounds = new object();

        public void Play(string sound)
        {
            var s = ResourceLoader.GetSound(sound);
            if (s == null)
                return;

            lock (syncSounds)
            {
                sounds.Enqueue(s);
            }
        }
        public void Update(float delta) {
            lock(syncSounds)
            {
                while(sounds.Count > 0)
                {
                    using(var player = sounds.Dequeue())
                    {
                        player.Play();
                    }
                }
            }
        }
    }
}

