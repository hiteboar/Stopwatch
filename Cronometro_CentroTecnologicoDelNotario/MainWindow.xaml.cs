using System;
using System.Windows;
using static Cronometro_CentroTecnologicoDelNotario.TimeCounter;

namespace Cronometro_CentroTecnologicoDelNotario
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private TimeCounter mTimer;

        public MainWindow()
        {
            InitializeComponent();

            //Create the timer
            mTimer = new TimeCounter();
            mTimer.OnUpdate += UpdateUI;

            // Init event callbacks
            mUITimer.OnStart += OnStartButtonPressed;
            mUITimer.OnStop += OnStopButtonPressed;
            mUITimer.OnPause += OnPauseButtonPressed;

            //Init the timer to 0
            mUITimer.SetTime(0, 0, 0);
        }

        /// <summary>
        ///  Event callback used to start the time count
        /// </summary>
        private void OnStartButtonPressed(object aSender, EventArgs aArgs)
        {
            mTimer.Start();
        }

        /// <summary>
        /// Event callback used to pause the timer
        /// </summary>
        private void OnPauseButtonPressed(object aSender, EventArgs aArgs)
        {
            mTimer.Pause();
        }


        /// <summary>
        /// Event callback used to stop the timer and reset the values
        /// </summary>
        private void OnStopButtonPressed(object aSender, EventArgs aArgs)
        {
            mTimer.Stop();
            mUITimer.SetTime(0, 0, 0);
        }

        /// <summary>
        ///  Event callback used to update the UI
        /// </summary>
        /// <param name="aCurrentTime">Time values at the moment when the callback was called</param>
        private void UpdateUI(object aSender, CurrentTime aCurrentTime)
        {
            mUITimer.SetTime(aCurrentTime.hours, aCurrentTime.minutes, aCurrentTime.seconds);
        }


    }
}
