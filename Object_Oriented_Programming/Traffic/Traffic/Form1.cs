using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traffic
{
    public partial class Form1 : Form 
    {

        Graphics gr;
        TrafficLight tr;

        public Form1()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            mode0.Enabled = true;
            mode1.Enabled = true;
            mode2.Enabled = true;
            gr = panel1.CreateGraphics();
            tr = new TrafficLight(panel1,panel1.Width,panel1.Height, 100,gr);
            tr.Draw(gr);
            create.Visible = false;
            Next.Enabled = true;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            state_timer.Stop();

            tr.Mode++;
            gr = panel1.CreateGraphics();
            state_timer.Start();
            if (mode0.Checked)
                mode1.Checked = true;
            else if (mode1.Checked)
                mode2.Checked = true;
            else
                mode0.Checked = true;
        }

        private void state_timer_Tick(object sender, EventArgs e)
        {
            tr.Next();
            tr.Draw(gr);
        }

        private void mode0_CheckedChanged(object sender, EventArgs e)
        {
            if (mode0.Checked)
            {
                tr.Mode = 0;
                state_timer.Stop();
                gr = panel1.CreateGraphics();
                state_timer.Start();
            }
        }

        private void mode1_CheckedChanged(object sender, EventArgs e)
        {
            if (mode1.Checked)
            {
                tr.Mode = 1;
                state_timer.Stop();
                gr = panel1.CreateGraphics();
                state_timer.Start();
            }
        }

        private void mode2_CheckedChanged(object sender, EventArgs e)
        {
            if (mode2.Checked)
            {
                tr.Mode = 2;
                state_timer.Stop();
                gr = panel1.CreateGraphics();
                state_timer.Start();
            }
        }
    }
}
