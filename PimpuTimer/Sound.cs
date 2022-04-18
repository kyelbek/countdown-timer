using System;
using System.Media;
using System.IO;

namespace PimpuTimer
{
    public class Sound
    {
        private bool isLoaded;
        private string soundPath;
        private SoundPlayer media;

        private string GetDir()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        private bool Load(string soundfile)
        {
            //soundPath = GetDir() + @"\assets" + soundfile;
            //if (!File.Exists(soundPath)) return false;
            //media = new SoundPlayer(soundPath);
            media = new SoundPlayer(Properties.Resources.ding);
            media.Load();
            return true;
        }

        public void Init(string soundfile)
        {
            isLoaded = Load(soundfile);
        }

        public void Play()
        {
            if (isLoaded) media.Play();
        }
    }
}
