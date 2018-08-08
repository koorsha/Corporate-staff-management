using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMPS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=EHSAN-PC\EHSAN;Initial Catalog=amps;Integrated Security=True");
            SqlCommand com = new SqlCommand("LoginToApp", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@username", textboxUserName.Text.ToString());
            com.Parameters.Add("@password",textboxPassword.Text.ToString());
            con.Open();
            int count = Convert.ToInt32(com.ExecuteScalar());
            con.Close();
            if (count==1)
            {
                this.Hide();
                forms.Home de = new forms.Home();
                de.Show();
                
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
