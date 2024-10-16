using System;
using System.Diagnostics;
using System.Timers;

namespace Cronometro_CentroTecnologicoDelNotario
{
    internal class TimeCounter
    {
        /// <summary>
        /// Stopwatch used to control the elapsed time
        /// </summary>
        private Stopwatch mStopwatch;

        /// <summary>
        /// The timer will throw an event each second
        /// </summary>
        private Timer mTimer;

        /// <summary>
        /// Struct used to send information about the stopwatch
        /// </summary>
        public struct CurrentTime
        {
            public int seconds;
            public int minutes;
            public int hours;
        }

        /// <summary>
        /// Event throwed every time the stopwatch has an update
        /// </summary>
        public event EventHandler<CurrentTime> OnUpdate;

        public TimeCounter()
        {
            mStopwatch = new Stopwatch();
            mTimer = new Timer();
            mTimer.Interval = 1000;
            mTimer.Elapsed += OnTimerElapsed;
        }


        /// <summary>
        /// Start the stopwatch. If it is already started, do nothing.
        /// </summary>
        public void Start()
        {
            if (mStopwatch.IsRunning) return;
            mStopwatch.Start();
            mTimer.Start();
        }

        /// <summary>
        /// Pause the stopwatch
        /// </summary>
        public void Pause()
        {
            if (mStopwatch.IsRunning) {
                mStopwatch.Stop();
            }
            mTimer.Stop();
        }

        /// <summary>
        /// Stop and reset the stopwatch to 0
        /// </summary>
        public void Stop()
        {
            mStopwatch.Reset();
        }

        /// <summary>
        /// Get the seconds component of the measured time
        /// </summary>
        /// <returns>Seconds of the stopwatch</returns>
        public int GetSeconds()
        {
            return mStopwatch.Elapsed.Seconds;
        }

        /// <summary>
        /// Get the minutes component of the measured time
        /// </summary>
        /// <returns>Minutes of the stopwatch</returns>
        public int GetMinutes()
        {
            return mStopwatch.Elapsed.Minutes;
        }

        /// <summary>
        /// Get the hours component of the elapsed time
        /// </summary>
        /// <returns>Hours of the stopwatch</returns>
        public int GetHours()
        {
            return mStopwatch.Elapsed.Hours;
        }

        /// <summary>
        /// Timer
        /// </summary>
        /// <param name="aSource"></param>
        /// <param name="aArgs"></param>
        private void OnTimerElapsed(object aSource, ElapsedEventArgs aArgs)
        {
            OnUpdate?.Invoke(this, new CurrentTime() { hours = GetHours(), minutes = GetMinutes(), seconds = GetSeconds() });
        }
    }
}
