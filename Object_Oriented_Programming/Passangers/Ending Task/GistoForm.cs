using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ending_Task
{
    public partial class GistoForm : Form
    {
        public GistoForm(List<Passanger> passangers)
        {
            InitializeComponent();
            this.passangers = passangers;
        }
        List<Passanger> passangers = new List<Passanger>();

        private void GistoForm_Load(object sender, EventArgs e)
        {
            foreach (var passanger in passangers)
                chartOfPassangerItems.Series["Items"].Points.AddXY(passanger.Surname, passanger.CountItems);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            fr1.Show();
            Hide();
        }
    }
}
