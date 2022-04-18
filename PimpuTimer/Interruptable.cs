using System;
using System.Timers;

namespace kyelbek
{
    namespace Interruptable
    {
        public abstract class Interruptable
        {
            private readonly Timer _timerInstance = new Timer();
            private bool IsInitialized { get; set; }

            /// <summary>
            /// Method that binds elapsed event method to the timer instance.
            /// Checks if event was bound earlier to prevent duplicates.
            /// </summary>
            private void Initialize()
            {
                if (IsInitialized) return;
                _timerInstance.Elapsed += OnTick;
                IsInitialized = true;
            }
            /// <summary>
            /// Method that allows the user to start the controller.
            /// Can only start if interval field was set earlier properly.
            /// </summary>
            public void Start(double interval)
            {
                if (interval <= 0) return;
                if (_timerInstance.Enabled) return;


                _timerInstance.Interval = interval;
                Initialize();
                _timerInstance.AutoReset = true;
                _timerInstance.Enabled = true;
            }
            /// <summary>
            /// Method that allows the user to stop the interrupt controller.
            /// </summary>
            public void Stop()
            {
                _timerInstance.Stop();
            }
            /// <summary>
            /// Forces classes that inherit to implement their own elapsed event.
            /// </summary>
            /// <param name="source"></param>
            /// <param name="eventArgs"></param>
            protected abstract void OnTick(object source, ElapsedEventArgs eventArgs);
        }
    }
}
