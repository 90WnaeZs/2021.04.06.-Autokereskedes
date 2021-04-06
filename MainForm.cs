using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autokereskedes
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void márkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Márka m = new Márka();
            m.Show();
        }

        private void tulajdonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tulajdonos t = new Tulajdonos();
            t.Show();
        }

        private void autóToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Autó a = new Autó();
            a.Show();
        }

        private void listázásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listázás l = new Listázás();
            l.Show();
        }
    }
}
