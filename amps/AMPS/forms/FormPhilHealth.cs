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
    public partial class FormPhilHealth : Form
    {
        private Admin admin;
        private PhilHealth philHealth;
        private Counts counts;
        private SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=amps;Persist Security Info=True;User ID=sa;Password=janry");
        
        public FormPhilHealth()
        {
            InitializeComponent();
            philHealth = new PhilHealth();
            counts = new Counts();
            admin = new Admin();
        }
        #region generate ID
        private void GenerateID()
        {
            admin.GetCountPhilHealth(counts);
            if (Convert.ToInt32(counts.Countss) == 0)
            {
                string newID = "PHILHEALTH-10001";
                philHealth.PhilHealthSalaryBracetNo = newID.ToString();

            }
            else
            {
                admin.GetLastIDPhilHealth(counts);
                string id = counts.LastID.Substring(11, 5);
                int increment = Convert.ToInt32(id) + 1;
                string newIDs = "PHILHEALTH-" + increment;
                philHealth.PhilHealthSalaryBracetNo = newIDs.ToString();

            }
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
                    dataGridViewPhilHealth.DataSource = dsSource;
                    this.dataGridViewPhilHealth.AllowUserToAddRows = false;
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
            philHealth.SalaryRangeFrom = new decimal[dataGridViewPhilHealth.Rows.Count];
            philHealth.SalaryRangeTo = new decimal[dataGridViewPhilHealth.Rows.Count];
            philHealth.SalaryBase = new decimal[dataGridViewPhilHealth.Rows.Count];
            philHealth.EmployeeShare = new decimal[dataGridViewPhilHealth.Rows.Count];
            philHealth.EmployerShare = new decimal[dataGridViewPhilHealth.Rows.Count];
            philHealth.TotalMonthlyPremium = new decimal[dataGridViewPhilHealth.Rows.Count];
            for (int i = 0; i < dataGridViewPhilHealth.Rows.Count; i++)
            {
                philHealth.SalaryRangeFrom[i] = decimal.Parse(dataGridViewPhilHealth.Rows[i].Cells["SalaryRangeFrom"].Value.ToString());
                philHealth.SalaryRangeTo[i] = decimal.Parse(dataGridViewPhilHealth.Rows[i].Cells["SalaryRangeTo"].Value.ToString());
                philHealth.SalaryBase[i] = decimal.Parse(dataGridViewPhilHealth.Rows[i].Cells["SalaryBase"].Value.ToString());
                philHealth.EmployeeShare[i] = decimal.Parse(dataGridViewPhilHealth.Rows[i].Cells["EmployeeShare"].Value.ToString());
                philHealth.EmployerShare[i] = decimal.Parse(dataGridViewPhilHealth.Rows[i].Cells["EmployerShare"].Value.ToString());
                philHealth.TotalMonthlyPremium[i] = decimal.Parse(dataGridViewPhilHealth.Rows[i].Cells["TotalMonthlyPremium"].Value.ToString());
            }
            admin.DeletePhilHealth();
            for (int i = 0; i < dataGridViewPhilHealth.Rows.Count; i++)
            {
                GenerateID();
                connection.Open();
                SqlCommand cmd = new SqlCommand("eprocedureInsertPhilHealth", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PhilHealthSalaryBracetNo", philHealth.PhilHealthSalaryBracetNo));
                cmd.Parameters.Add(new SqlParameter("@SalaryRangeFrom", philHealth.SalaryRangeFrom[i]));
                cmd.Parameters.Add(new SqlParameter("@SalaryRangeTo", philHealth.SalaryRangeTo[i]));
                cmd.Parameters.Add(new SqlParameter("@SalaryBase", philHealth.SalaryBase[i]));
                cmd.Parameters.Add(new SqlParameter("@EmployeeShare", philHealth.EmployeeShare[i]));
                cmd.Parameters.Add(new SqlParameter("@EmployerShare", philHealth.EmployerShare[i]));
                cmd.Parameters.Add(new SqlParameter("@TotalMonthlyPremium", philHealth.TotalMonthlyPremium[i]));
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            MessageBox.Show("Record Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
