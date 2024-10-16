using System;
using System.Windows;
using System.Windows.Controls;

namespace Cronometro_CentroTecnologicoDelNotario
{
    /// <summary>
    /// Lógica de interacción para TimerUI.xaml
    /// </summary>
    public partial class TimerUI : UserControl
    {
        /// <summary>
        /// Event throwed when the stop button is pressed
        /// </summary>
        public event EventHandler OnStop;

        /// <summary>
        /// Event throwed when the start button is pressed
        /// </summary>
        public event EventHandler OnStart;

        /// <summary>
        /// Event throwed when the pause button is pressed
        /// </summary>
        public event EventHandler OnPause;

        public TimerUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Callback used when the stop buttos is pressed
        /// </summary>
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            OnStop?.Invoke(this, null);
        }


        /// <summary>
        /// Callback used when the pause buttos is pressed
        /// </summary>
        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            OnPause?.Invoke(this, null);
        }

        /// <summary>
        /// Callback used when the play buttos is pressed
        /// </summary>
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            OnStart?.Invoke(this, null);
        }

        /// <summary>
        /// Set the current time values to the clock
        /// </summary>
        /// <param name="aHours">Hours value</param>
        /// <param name="aMinutes">Minutes value</param>
        /// <param name="aSeconds">Seconds value</param>
        public void SetTime(int aHours, int aMinutes, int aSeconds)
        {
            this.Dispatcher.Invoke(() => {
                Hours.Content = aHours.ToString();
                Minutes.Content = aMinutes.ToString();
                Seconds.Content = aSeconds.ToString();
            });
        }
    }
}
