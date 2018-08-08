using AMPS.classes;
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
    public partial class Department : Form
    {
        private Admin admin;
        private Departments department;
        private Counts counts;
        public Department()
        {
            InitializeComponent();
            admin = new Admin();
            department = new Departments();
            counts = new Counts();
        }

        private void Department_Load(object sender, EventArgs e)
        {
            dataGridViewDepartment.DataSource = admin.DataSet.Tables["Department"];
            dataGridViewDepartment.ClearSelection();
            GenerateID();
        }
        #region set auto number
        private void GenerateID()
        {
            admin.GetCountDepartment(counts);
            if (Convert.ToInt32(counts.Countss) == 0)
            {
                string newID = "DEPARTMENT-10001";
                textBoxDepartmentID.Text = newID.ToString();

            }
            else
            {
                admin.GetLastIDDepartment(counts);
                string id = counts.LastID.Substring(11, 5);
                int increment = Convert.ToInt32(id) + 1;
                string newIDs = "DEPARTMENT-" + increment;
                textBoxDepartmentID.Text = newIDs.ToString();

            }
        }
        #endregion
        #region Validation Methods

        private void ClearControls()
        {
            textBoxDepartmentID.Clear();
            textBoxDepartmentName.Clear();
            //textBoxDepartmentID.Focus();
            errorProvider1.Clear();

        }

        private bool ValidateControls()
        {
            //|| !System.Text.RegularExpressions.Regex.IsMatch(textBoxDepartmentName.Text, "^[a-zA-Z]+$")
            //System.Text.RegularExpressions.Regex.IsMatch(textBoxDepartmentName.Text, "^\\£?[+-]?[\\d,]*\\.?\\d{0,2}$")
            if (textBoxDepartmentName.Text == "")
            {
                //MessageBox.Show(textBoxDepartmentName + "Please fill out empty fields.", "Empty fields.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                errorProvider1.SetError(textBoxDepartmentName, "Please fill out empty fields");
                textBoxDepartmentName.Focus();
                return false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxDepartmentName.Text, "^[a-zA-Z]+$"))
            {
                //MessageBox.Show("Please Input Correct Format only character will be accepted.", "Input Correct Format.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                errorProvider1.SetError(textBoxDepartmentName, "Please Input Correct Format only character will be accepted");
                textBoxDepartmentName.Focus();
                return false;
            }
            errorProvider1.Clear();
            return true;

        }
        #endregion
        #region Tranfer Data
        private void TransferToObject()
        {

            //assign values from the controls to the object
            department.DepartmentID = textBoxDepartmentID.Text;
            department.DepartmentName = textBoxDepartmentName.Text;
        }

        private void TransferToControls()
        {
            //set up selectedRow from the dataGridView
            DataGridViewRow selectedRow = dataGridViewDepartment.SelectedRows[0];
            //assign values from the selectedRow to the controls
            textBoxDepartmentID.Text = selectedRow.Cells["DepartmentID"].Value.ToString();
            textBoxDepartmentName.Text = selectedRow.Cells["DepartmentName"].Value.ToString();
        }
        #endregion

        private void dataGridViewDepartment_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewDepartment.SelectedRows.Count > 0)
            {
                buttonAdd.Enabled = false;
                buttonEdit.Enabled = true;
                buttonDelete.Enabled = true;
                TransferToControls();
            }
            else
            {
                MessageBox.Show("No Record Have been selected", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string search;
            search = textBoxSearch.Text;
            admin.SearchRecordDepartment(search);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string search;
            search = textBoxSearch.Text;
            admin.SearchRecordDepartment(search);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                TransferToObject();
                admin.AddRow(department);
                MessageBox.Show("Record Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearControls();
                GenerateID();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewDepartment.SelectedRows.Count >= 0)
            {
                if (ValidateControls())
                {
                    TransferToObject();

                    //get selectedIndex from the dataGridView
                    int selectedIndex = dataGridViewDepartment.SelectedRows[0].Index;

                    admin.EditRow(department, selectedIndex);
                    MessageBox.Show("Record Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearControls();
                    buttonAdd.Enabled = true;
                    buttonEdit.Enabled = false;
                    buttonDelete.Enabled = false;
                    dataGridViewDepartment.ClearSelection();
                    GenerateID();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Records.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dataGridViewDepartment.SelectedRows.Count >= 0)
                {
                    if (ValidateControls())
                    {
                        TransferToObject();
                        int selectedIndex = dataGridViewDepartment.SelectedRows[0].Index;
                        admin.DeleteRow(department, selectedIndex);
                        MessageBox.Show("Record Delete", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearControls();
                        buttonAdd.Enabled = true;
                        buttonEdit.Enabled = false;
                        buttonDelete.Enabled = false;
                        dataGridViewDepartment.ClearSelection();
                        GenerateID();
                    }
                }
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = true;
            buttonEdit.Enabled = false;
            buttonDelete.Enabled = false;
            dataGridViewDepartment.ClearSelection();
            ClearControls();
            GenerateID();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        

        private void textBoxDepartmentName_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxDepartmentName.Text == "")
            {
                errorProvider1.SetError(textBoxDepartmentName, "Please fill out empty fields");
                textBoxDepartmentName.Focus();

            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxDepartmentName.Text, "^[a-zA-Z ]+$"))
            {
                errorProvider1.SetError(textBoxDepartmentName, "Please fill Correct Formant");
                textBoxDepartmentName.Focus();

            }
            else
            {
                errorProvider1.Clear();
            }
            
        }
    }
}
