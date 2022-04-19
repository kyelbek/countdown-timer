using System;
using System.Windows.Threading;
using System.Windows.Forms;

namespace PimpuTimer
{
    public partial class TimerWindow : Form
    {
        Clock klok;

        public TimerWindow()
        {
            InitializeComponent();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(100);
            dispatcherTimer.Tick += dispatcherTimer_OnTick;
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_OnTick(object sender, EventArgs e)
        {
            labelTimer.Text = klok.GetTimeString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            klok.Start(1000);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            klok.Stop();
            klok.Reset();
        }

        private void TimerWindow_Load(object sender, EventArgs e)
        {
            klok = new Clock();
            klok.Init(120);
        }
    }
}
