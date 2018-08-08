using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMPS.forms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        private void MnuAdd_Click_1(object sender, EventArgs e)
        {
            Department de = new Department();
            de.Show();
        }

        private void calculationOfWagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPhilHealth frm = new FormPhilHealth();
            frm.Show();

        }

        private void MnuMonthlyReport_Click(object sender, EventArgs e)
        {
            forms.FormPagIbig pag = new FormPagIbig();
            pag.Show();
        }

        private void MnuPositionInformation_Click(object sender, EventArgs e)
        {
            FormPositions pos = new FormPositions();
            pos.Show();
        }

        private void MnuSelectiveServiceSystem_Click(object sender, EventArgs e)
        {
            FormSSS ss = new FormSSS();
            ss.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
