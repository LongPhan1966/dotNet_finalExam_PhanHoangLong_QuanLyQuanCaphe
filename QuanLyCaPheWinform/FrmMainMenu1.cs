using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCaPheWinform
{
    public partial class FrmMainMenu1 : Form
    {
        public FrmMainMenu1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmManager1 f = new FrmManager1();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAcount f = new FrmAcount();
            f.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmAdmin f = new FrmAdmin();
            f.ShowDialog();
        }

        private void FrmMainMenu1_Load(object sender, EventArgs e)
        {

        }
    }
}
