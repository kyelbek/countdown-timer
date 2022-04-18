using System;
using System.Timers;
using kyelbek.Interruptable;

namespace PimpuTimer
{
    public class Clock : Interruptable
    {
        private readonly Sound notification = new Sound();
        private readonly int setTime = 120;
        private int curTime, m, s;

        public void Init()
        {
            curTime = setTime;
            notification.Init(@"\ding.wav");
        }

        public string GetTimeString()
        {
            m = curTime / 60;
            s = curTime - (m * 60);
            return String.Format("{0:00}:{1:00}", m, s);
        }

        protected override void OnTick(object source, ElapsedEventArgs eventArgs)
        {
            if (curTime <= 0) curTime = setTime;
            curTime--;
            if (curTime <= 5) notification.Play();
        }

    }
}
