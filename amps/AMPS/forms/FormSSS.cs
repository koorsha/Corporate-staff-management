using AMPS.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMPS.forms
{
    public partial class FormSSS : Form
    {
        private Admin admin;
        private SSS sss;
        private Counts counts;
        private SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=amps;Persist Security Info=True;User ID=sa;Password=janry");
        public FormSSS()
        {
            InitializeComponent();
            admin = new Admin();
            sss = new SSS();
            counts = new Counts();
        }
        #region generate ID
        private void GenerateID()
        {
            //sss.SSSSalaryBracetNo = new string[dataGridViewSSS.Rows.Count];
            //for (int i = 0; i < dataGridViewSSS.Rows.Count; i++)
            //{
               
                admin.GetCountSSS(counts);
                if (Convert.ToInt32(counts.Countss) == 0)
                {
                    string newID = "SSS-10001";
                    sss.SSSSalaryBracetNo = newID.ToString();

                }
                else
                {
                    admin.GetLastIDSSS(counts);
                    string id = counts.LastID.Substring(4, 5);
                    int increment = Convert.ToInt32(id) + 1;
                    string newIDs = "SSS-" + increment;
                    sss.SSSSalaryBracetNo = newIDs.ToString();

                }
            //}
        }
        #endregion
        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofImport = new OpenFileDialog();
            try
            {
                ofImport.Title = "Select file";
                ofImport.InitialDirectory = @"c:\";
                ofImport.FileName = "";
                ofImport.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
                ofImport.FilterIndex = 1;
                ofImport.RestoreDirectory = true;

                if (ofImport.ShowDialog() == DialogResult.OK)
                {

                    string path = System.IO.Path.GetFullPath(ofImport.FileName);
                    string name = "Sheet1";
                    OleDbConnection conn = new OleDbConnection();
                    conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ofImport.FileName + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                    OleDbDataAdapter adapter = new OleDbDataAdapter("Select * From [" + name + "$]", conn);

                    DataTable dsSource = new DataTable();
                    //DataSet dataSet = new DataSet();
                    adapter.Fill(dsSource);
                    dataGridViewSSS.DataSource = dsSource;
                    this.dataGridViewSSS.AllowUserToAddRows = false;
                }
                else
                {
                    ofImport.Dispose();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (dataGridViewSSS.DataSource == null)
            {
                MessageBox.Show("Please choose file to be uploaded", "Empty fields.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sss.SalaryRangeFrom = new decimal[dataGridViewSSS.Rows.Count];
                sss.SalaryRangeTo = new decimal[dataGridViewSSS.Rows.Count];
                sss.SalaryBase = new decimal[dataGridViewSSS.Rows.Count];
                sss.SocialSecurityEmployeeShare = new decimal[dataGridViewSSS.Rows.Count];
                sss.SocialSecurityEmployerShare = new decimal[dataGridViewSSS.Rows.Count];
                sss.SocialSecurityTotal = new decimal[dataGridViewSSS.Rows.Count];
                sss.EmployerShare = new decimal[dataGridViewSSS.Rows.Count];
                sss.TotalContributionEmployeeShare = new decimal[dataGridViewSSS.Rows.Count];
                sss.TotalContributionEmployerShare = new decimal[dataGridViewSSS.Rows.Count];
                sss.TotalContribution = new decimal[dataGridViewSSS.Rows.Count];
                sss.TotalContributionForSEVMOFW = new decimal[dataGridViewSSS.Rows.Count];
                for (int i = 0; i < dataGridViewSSS.Rows.Count; i++)
                {
                    sss.SalaryRangeFrom[i] = decimal.Parse(dataGridViewSSS.Rows[i].Cells["SalaryRangeFrom"].Value.ToString());
                    sss.SalaryRangeTo[i] = decimal.Parse(dataGridViewSSS.Rows[i].Cells["SalaryRangeTo"].Value.ToString());
                    sss.SalaryBase[i] = decimal.Parse(dataGridViewSSS.Rows[i].Cells["SalaryBase"].Value.ToString());
                    sss.SocialSecurityEmployeeShare[i] = decimal.Parse(dataGridViewSSS.Rows[i].Cells["SocialSecurityEmployerShare"].Value.ToString());
                    sss.SocialSecurityEmployerShare[i] = decimal.Parse(dataGridViewSSS.Rows[i].Cells["SocialSecurityEmployeeShare"].Value.ToString());
                    sss.SocialSecurityTotal[i] = decimal.Parse(dataGridViewSSS.Rows[i].Cells["SocialSecurityTotal"].Value.ToString());
                    sss.EmployerShare[i] = decimal.Parse(dataGridViewSSS.Rows[i].Cells["EmployerShare"].Value.ToString());
                    sss.TotalContributionEmployeeShare[i] = decimal.Parse(dataGridViewSSS.Rows[i].Cells["TotalContributionEmployeeShare"].Value.ToString());
                    sss.TotalContributionEmployerShare[i] = decimal.Parse(dataGridViewSSS.Rows[i].Cells["TotalContributionEmployerShare"].Value.ToString());
                    sss.TotalContribution[i] = decimal.Parse(dataGridViewSSS.Rows[i].Cells["TotalContribution"].Value.ToString());
                    sss.TotalContributionForSEVMOFW[i] = decimal.Parse(dataGridViewSSS.Rows[i].Cells["TotalContributionForSEVMOFW"].Value.ToString());
                }
                admin.DeleteSSS();
                MessageBox.Show(sss.SalaryRangeFrom[0].ToString());
                for (int i = 0; i < dataGridViewSSS.Rows.Count; i++)
                {
                    GenerateID();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("dprocedureInsertSSS", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@SSSSalaryBracetNo", sss.SSSSalaryBracetNo));
                    cmd.Parameters.Add(new SqlParameter("@SalaryRangeFrom", sss.SalaryRangeFrom[i]));
                    cmd.Parameters.Add(new SqlParameter("@SalaryRangeTo", sss.SalaryRangeTo[i]));
                    cmd.Parameters.Add(new SqlParameter("@SalaryBase", sss.SalaryBase[i]));
                    cmd.Parameters.Add(new SqlParameter("@SocialSecurityEmployeeShare", sss.SocialSecurityEmployeeShare[i]));
                    cmd.Parameters.Add(new SqlParameter("@SocialSecurityEmployerShare", sss.SocialSecurityEmployerShare[i]));
                    cmd.Parameters.Add(new SqlParameter("@SocialSecurityTotal", sss.SocialSecurityTotal[i]));
                    cmd.Parameters.Add(new SqlParameter("@EmployerShare", sss.EmployerShare[i]));
                    cmd.Parameters.Add(new SqlParameter("@TotalContributionEmployeeShare", sss.TotalContributionEmployeeShare[i]));
                    cmd.Parameters.Add(new SqlParameter("@TotalContributionEmployerShare", sss.TotalContributionEmployerShare[i]));
                    cmd.Parameters.Add(new SqlParameter("@TotalContribution", sss.TotalContribution[i]));
                    cmd.Parameters.Add(new SqlParameter("@TotalContributionForSEVMOFW", sss.TotalContributionForSEVMOFW[i]));
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                MessageBox.Show("Record Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
