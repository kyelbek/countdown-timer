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

        public void Load(string soundfile)
        {
            soundPath = GetDir() + soundfile;
            if (!File.Exists(soundPath)) return;
            media = new SoundPlayer(soundPath);
            media.Load();
            isLoaded = true;
        }

        public void Load(Stream soundstream)
        {
            media = new SoundPlayer(soundstream);
            media.Load();
            isLoaded = true;
        }

        public void Play()
        {
            if (isLoaded) media.Play();
        }
    }
}
