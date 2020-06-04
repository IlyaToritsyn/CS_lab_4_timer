using System;
using System.Windows.Forms;

namespace Control
{
    public partial class Form1 : Form
    {
        private bool IsTimerEnabled { get; set; } = false;

        private DateTime TimerOff { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Умен. времени в таймере.
        /// </summary>
        private void UpdateTimer()
        {
            ////Умен. сек.
            //if (numericUpDownSeconds.Value > 0)
            //{
            //    numericUpDownSeconds.Value--;
            //}

            ////Умен. мин и сек.
            //else if (numericUpDownMinutes.Value > 0)
            //{
            //    numericUpDownMinutes.Value--;
            //    numericUpDownSeconds.Value = 59;
            //}

            ////Умен. часы, мин и сек.
            //else if (numericUpDownHours.Value > 0)
            //{
            //    numericUpDownHours.Value--;
            //    numericUpDownMinutes.Value = 59;
            //    numericUpDownSeconds.Value = 59;
            //}

            ////Если время вышло.
            //else if (numericUpDownHours.Value == 0 && numericUpDownMinutes.Value == 0 && numericUpDownSeconds.Value == 0)
            //{
            //    IsTimerEnabled = false;

            //    MessageBox.Show("Ваше время вышло.");
            //}

            if (TimerOff <= DateTime.Now)
            {
                IsTimerEnabled = false;

                MessageBox.Show("Время вышло.");
            }

            else
            {
                TimeSpan lastTime = TimerOff - DateTime.Now;
                numericUpDownHours.Value = lastTime.Hours;
                numericUpDownMinutes.Value = lastTime.Minutes;
                numericUpDownSeconds.Value = lastTime.Seconds;
            }
        }

        /// <summary>
        /// Метод элемента Timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            clockLabel.Text = DateTime.Now.ToLongTimeString();

            if (IsTimerEnabled)
            {
                UpdateTimer();
            }
        }

        /// <summary>
        /// Если нажата кнопка Пуск.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTimer_Click(object sender, EventArgs e)
        {
            TimerOff = DateTime.Now;

            TimerOff = TimerOff.AddHours((double)numericUpDownHours.Value);
            TimerOff = TimerOff.AddMinutes((double)numericUpDownMinutes.Value);
            TimerOff = TimerOff.AddSeconds((double)numericUpDownSeconds.Value);

            IsTimerEnabled = true;
        }
    }
}
