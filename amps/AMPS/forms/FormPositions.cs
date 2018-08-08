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
    public partial class FormPositions : Form
    {
        private Admin admin;
        private Positions positions;
        private Counts counts;
        public FormPositions()
        {
            InitializeComponent();
            admin = new Admin();
            positions = new Positions();
            counts = new Counts();
        }

        private void FormPositions_Load(object sender, EventArgs e)
        {
            dataGridViewPosition.DataSource = admin.DataSet.Tables["JoinPositionDepartment"];
            comboBoxDepartment.DataSource = admin.DataSet.Tables["Department"];
            //display course description
            comboBoxDepartment.DisplayMember = "DepartmentName";

            //assign CourseCode as the value
            comboBoxDepartment.ValueMember = "DepartmentID";
            GeneratID();
            dataGridViewPosition.ClearSelection();
        }
        #region generate ID
        private void GeneratID()
        {
            admin.GetCountPosition(counts);
            if (Convert.ToInt32(counts.Countss) == 0)
            {
                string newID = "POSITION-10001";
                textBoxPositionID.Text = newID.ToString();

            }
            else
            {
                admin.GetLastIDPosition(counts);
                string id = counts.LastID.Substring(9, 5);
                int increment = Convert.ToInt32(id) + 1;
                string newIDs = "POSITION-" + increment;
                textBoxPositionID.Text = newIDs.ToString();

            }
        }
        #endregion
        #region Validation Methods

        private void ClearControls()
        {
            textBoxPositionID.Clear();
            textBoxPositionName.Clear();
            textBoxSalary.Clear();
            comboBoxDepartment.Text = "Select One";
        }

        private bool ValidateControls()
        {
            if (textBoxPositionName.Text == "")
            {
                errorProvider1.SetError(textBoxPositionName, "Please fill out empty fields");
                textBoxPositionName.Focus();
                return false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxPositionName.Text, "^[a-zA-Z]+$"))
            {
                errorProvider1.SetError(textBoxPositionName, "Please fill out Correct format");
                textBoxPositionName.Focus();
                return false;
            }

            if (comboBoxDepartment.Text == "Select One")
            {
                MessageBox.Show("Please fill out empty fields.", "Empty fields.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBoxDepartment.Focus();
                return false;
            }

            if (textBoxSalary.Text == "0" || textBoxSalary.Text == "")
            {
                errorProvider1.SetError(textBoxSalary, "Please fill out empty field(s) Empty fields.");
                textBoxSalary.Focus();
                return false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxSalary.Text, "^\\£?[+-]?[\\d,]*\\.?\\d{0,2}$"))
            {
                errorProvider1.SetError(textBoxSalary, "Please Input Correct Format only number will be accepted.");
                textBoxSalary.Focus();
                return false;
            }
            errorProvider1.Clear();
            return true;
        }
        #endregion
        #region Transfer Data

        private void TransferToObject()
        {

            //assign values from the controls to the object
            positions.PositionID = textBoxPositionID.Text;
            positions.PositionName = textBoxPositionName.Text;
            positions.Salary = Int32.Parse(textBoxSalary.Text);
            positions.Department.DepartmentID = comboBoxDepartment.SelectedValue.ToString();
            positions.Department.DepartmentName = comboBoxDepartment.Text;
        }

        private void TransferToControls()
        {
            //set up selectedRow from the dataGridView
            DataGridViewRow selectedRow = dataGridViewPosition.SelectedRows[0];

            //assign values from the selectedRow to the controls
            textBoxPositionID.Text = selectedRow.Cells["PositionID"].Value.ToString();
            textBoxPositionName.Text = selectedRow.Cells["PositionName"].Value.ToString();
            textBoxSalary.Text = selectedRow.Cells["Salary"].Value.ToString();
            comboBoxDepartment.Text = selectedRow.Cells["DepartmentName"].Value.ToString();
        }
        #endregion
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string search;
            search = textBoxSearch.Text;
            admin.SearchRecordPosition(search);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string search;
            search = textBoxSearch.Text;
            admin.SearchRecordPosition(search);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                TransferToObject();
                admin.AddRow(positions);
                MessageBox.Show("Record Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearControls();
                GeneratID();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewPosition.SelectedRows.Count >= 0)
            {
                if (ValidateControls())
                {
                    TransferToObject();
                    int selectedIndex = dataGridViewPosition.SelectedRows[0].Index;
                    admin.EditRow(positions, selectedIndex);
                    MessageBox.Show("Record Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearControls();
                    buttonAdd.Enabled = true;
                    buttonEdit.Enabled = false;
                    buttonDelete.Enabled = false;
                    GeneratID();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Records.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dataGridViewPosition.SelectedRows.Count >= 0)
                {
                    if (ValidateControls())
                    {
                        TransferToObject();
                        int selectedIndex = dataGridViewPosition.SelectedRows[0].Index;
                        admin.DeleteRow(positions, selectedIndex);
                        ClearControls();
                        buttonAdd.Enabled = true;
                        buttonEdit.Enabled = false;
                        buttonDelete.Enabled = false;
                        GeneratID();
                    }
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = true;
            buttonEdit.Enabled = false;
            buttonDelete.Enabled = false;
            dataGridViewPosition.ClearSelection();
            ClearControls();
            GeneratID();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = true;
            buttonEdit.Enabled = false;
            buttonDelete.Enabled = false;
            dataGridViewPosition.ClearSelection();
            ClearControls();
            GeneratID();
        }

        private void dataGridViewPosition_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewPosition.SelectedRows.Count >= 0)
            {
                buttonAdd.Enabled = false;
                buttonEdit.Enabled = true;
                buttonDelete.Enabled = true;
                TransferToControls();
            }
        }

        private void textBoxPositionName_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxPositionName.Text == "")
            {
                errorProvider1.SetError(textBoxPositionName, "Please fill out empty fields");
                textBoxPositionName.Focus();
               
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxPositionName.Text, "^[a-zA-Z]+$"))
            {
                errorProvider1.SetError(textBoxPositionName, "Please fill out Correct format");
                textBoxPositionName.Focus();

            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBoxSalary_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxSalary.Text == "0" || textBoxSalary.Text == "")
            {
                errorProvider1.SetError(textBoxSalary, "Please fill out empty fields");
                textBoxSalary.Focus();
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxSalary.Text, "^\\£?[+-]?[\\d,]*\\.?\\d{0,2}$"))
            {
                errorProvider1.SetError(textBoxSalary, "Please Input Correct Format only number will be accepted.");
                textBoxSalary.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void comboBoxDepartment_Validating(object sender, CancelEventArgs e)
        {
            if (comboBoxDepartment.Text == "Select One")
            {
                errorProvider1.SetError(comboBoxDepartment,"Please fill out empty fields.");
                comboBoxDepartment.Focus();
            }
        }

        private void comboBoxDepartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
