using System;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace CCPos.Forms
{
    public partial class frmSplashScreen : MetroForm
    {
        private ProgressBar progressBar;
        private Timer timer;
        private int progressValue;
        private int loadDuration = 2400;  // 2.4 seconds
        private int incrementValue;
        private int progressMaxValue = 40;  // Adjusted max value to match number of ticks

        public frmSplashScreen()
        {
            InitializeComponent();

            // Set form border style to none
            this.FormBorderStyle = FormBorderStyle.None;

            // Remove maximized window state, set custom size instead
            this.Size = new System.Drawing.Size(400, 300);  // Set form size to 400x300

            // Set start position to center screen
            this.StartPosition = FormStartPosition.CenterScreen;

            // Ensure the form is not shown in the taskbar and has no control box
            this.ShowInTaskbar = false;
            this.ControlBox = false;

            // Initialize the progress bar
            InitializeProgressBar();

            // Set up the timer
            InitializeTimer();
        }

        private void InitializeProgressBar()
        {
            progressBar = new ProgressBar
            {
                Width = 300, // Width of the progress bar
                Height = 25, // Height of the progress bar
                Style = ProgressBarStyle.Continuous,
                Maximum = progressMaxValue,  // Adjusted to match the number of ticks
                Minimum = 0,
                Value = 0,
                Dock = DockStyle.Bottom  // Place it at the bottom of the screen
            };

            // Add progress bar to the form
            this.Controls.Add(progressBar);
        }

        private void InitializeTimer()
        {
            // Timer setup
            timer = new Timer();
            timer.Interval = 60;  // Timer tick every 60 milliseconds
            timer.Tick += Timer_Tick;

            // Calculate the increment value based on the load duration
            incrementValue = 1;  // Increment by 1 per tick

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressValue + incrementValue <= progressMaxValue)
            {
                progressValue += incrementValue;  // Increment the progress value
                progressBar.Value = progressValue;
            }
            else
            {
                progressBar.Value = progressMaxValue;  // Ensure the value doesn't exceed the maximum
                timer.Stop();
                this.Close();  // Close the splash screen once loading is complete
            }
        }

        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            // You can add any load-time code here if needed.
        }
    }
}
