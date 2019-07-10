using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW1007_async_await
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Timers.Timer t = new System.Timers.Timer(100);
            t.Elapsed += t_Elapsed;
            t.Enabled = true;
        }

        void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Action a = () => 
            {
                int i = DateTime.Now.Millisecond;
                label1.Text = i.ToString();
                if (i % 2 == 0)
                {
                    label1.ForeColor = Color.Green;
                }
                else
                {
                    label1.ForeColor = Color.Blue;
                }
            };
            label1.BeginInvoke(a);
        }
    }
}
