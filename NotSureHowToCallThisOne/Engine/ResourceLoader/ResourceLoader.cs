using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Numerics;

namespace NotSureHowToCallThisOne
{
    public static class ResourceLoader
    {
        private readonly static Dictionary<string, Image> images = new Dictionary<string, Image>();
        private readonly static Dictionary<string, SoundPlayer> sounds = new Dictionary<string, SoundPlayer>();

        public static void LoadImage(string url, string id) {
            if (!File.Exists(url))
                return;
            if (images.ContainsKey(id))
                return;

            images.Add(id, Image.FromFile(url));
        }

        public static void LoadSound(string url, string id)
        {
            if (!File.Exists(url))
                return;
            if (images.ContainsKey(id))
                return;

            var player = new SoundPlayer(url);
            player.Load();

            sounds.Add(id, player);
        }

        public static SoundPlayer GetSound(string id)
        {
            if (!sounds.ContainsKey(id))
                return null;
            return sounds[id];
        }
        public static Image GetImage(string id) {
            if (!images.ContainsKey(id))
                return null;

            return images[id];
        }
    }
}