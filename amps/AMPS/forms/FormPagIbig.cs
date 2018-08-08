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
    public partial class FormPagIbig : Form
    {
        private PagIbig pagIbig;
        private Counts counts;
        private Admin admin;
        private SqlConnection connection = new SqlConnection(@"Data Source=EHSAN-PC\EHSAN;Initial Catalog=amps;Integrated Security=True");
        public FormPagIbig()
        {
            InitializeComponent();
            pagIbig = new PagIbig();
            counts = new Counts();
            admin = new Admin();
        }
        #region set auto number
        private void GenerateID()
        {
            admin.GetCountPagIbig(counts);
            if (Convert.ToInt32(counts.Countss) == 0)
            {
                string newID = "PAGIBIG-10001";
                pagIbig.PagIbigSalaryBracetNo = newID.ToString();

            }
            else
            {
                admin.GetLastIDPagIbig(counts);
                string id = counts.LastID.Substring(8, 5);
                int increment = Convert.ToInt32(id) + 1;
                string newIDs = "PAGIBIG-" + increment;
                pagIbig.PagIbigSalaryBracetNo = newIDs.ToString();

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
                    dataGridViewPagIbig.DataSource = dsSource;
                    this.dataGridViewPagIbig.AllowUserToAddRows = false;
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
            pagIbig.EmployeeShare = new decimal[dataGridViewPagIbig.Rows.Count];
            pagIbig.EmployerShare = new decimal[dataGridViewPagIbig.Rows.Count];
            pagIbig.MonthlyCompensationFrom = new decimal[dataGridViewPagIbig.Rows.Count];
            pagIbig.MonthlyCompensationTo = new decimal[dataGridViewPagIbig.Rows.Count];
            pagIbig.TotalMonthlyContribution = new decimal[dataGridViewPagIbig.Rows.Count];
            for (int i = 0; i < dataGridViewPagIbig.Rows.Count; i++)
            {
                pagIbig.MonthlyCompensationFrom[i] = decimal.Parse(dataGridViewPagIbig.Rows[i].Cells["MonthlyCompensationFrom"].Value.ToString());
                pagIbig.MonthlyCompensationTo[i] = decimal.Parse(dataGridViewPagIbig.Rows[i].Cells["MonthlyCompensationTo"].Value.ToString());
                pagIbig.EmployeeShare[i] = decimal.Parse(dataGridViewPagIbig.Rows[i].Cells["EmployeeShare"].Value.ToString());
                pagIbig.EmployerShare[i] = decimal.Parse(dataGridViewPagIbig.Rows[i].Cells["EmployerShare"].Value.ToString());
                pagIbig.TotalMonthlyContribution[i] = decimal.Parse(dataGridViewPagIbig.Rows[i].Cells["TotalMonthlyContribution"].Value.ToString());
            }
            admin.DeletePagIbig();
            for (int i = 0; i < dataGridViewPagIbig.Rows.Count; i++)
            {
                GenerateID();
                connection.Open();
                SqlCommand cmd = new SqlCommand("fprocedureInsertPagIbig", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PagIbigSalaryBracetNo", pagIbig.PagIbigSalaryBracetNo));
                cmd.Parameters.Add(new SqlParameter("@MonthlyCompensationFrom", pagIbig.MonthlyCompensationFrom[i]));
                cmd.Parameters.Add(new SqlParameter("@MonthlyCompensationTo", pagIbig.MonthlyCompensationTo[i]));
                cmd.Parameters.Add(new SqlParameter("@EmployeeShare", pagIbig.EmployeeShare[i]));
                cmd.Parameters.Add(new SqlParameter("@EmployerShare", pagIbig.EmployerShare[i]));
                cmd.Parameters.Add(new SqlParameter("@TotalMonthlyContribution", pagIbig.TotalMonthlyContribution[i]));
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
