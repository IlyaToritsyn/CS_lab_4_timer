using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = true;

            //Умен. сек.
            if (numericUpDownSeconds.Value > 0)
            {
                numericUpDownSeconds.Value--;
            }

            //Умен. мин и сек.
            else if (numericUpDownMinutes.Value > 0)
            {
                numericUpDownMinutes.Value--;
                numericUpDownSeconds.Value = 59;
            }

            //Умен. часы, мин и сек.
            else if (numericUpDownHours.Value > 0)
            {
                numericUpDownHours.Value--;
                numericUpDownMinutes.Value = 59;
                numericUpDownSeconds.Value = 59;
            }

            //Если время вышло.
            else if (numericUpDownHours.Value == 0 && numericUpDownMinutes.Value == 0 && numericUpDownSeconds.Value == 0)
            {
                timer.Enabled = false;

                MessageBox.Show("Ваше время вышло.");
            }
        }
    }
}
