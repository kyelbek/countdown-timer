using System;
using System.Timers;
using kyelbek.Interruptable;

namespace PimpuTimer
{
    public class Clock : Interruptable
    {
        private readonly Sound notification = new Sound();
        private int setTime;
        private int curTime, m, s;

        public void Init(int seconds)
        {
            setTime = seconds;
            if (setTime > 0) Reset();
            notification.Init(@"\ding.wav");
        }

        public string GetTimeString()
        {
            m = curTime / 60;
            s = curTime - (m * 60);
            return String.Format("{0:00}:{1:00}", m, s);
        }

        public void Reset()
        {
            curTime = setTime;
        }

        protected override void OnTick(object source, ElapsedEventArgs eventArgs)
        {
            if (curTime <= 0) Reset();
            curTime--;
            if (curTime <= 5) notification.Play();
        }

    }
}
