using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMPS.classes
{
    class Admin
    {
        #region connection database and load data
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private DataSet dt;
        public DataSet DataSet
        {
            get { return dataSet; }
            set { dataSet = value; }
        }
        public DataSet Dt
        {
            get { return dt; }
            set { dt = value; }
        }
        public Admin()
        {
            LoadData();

        }
        private void LoadData()
        {
            //set up connection
            string connectionString = @"Data Source=EHSAN-PC\EHSAN;Initial Catalog=amps;Integrated Security=True";
            connection = new SqlConnection(connectionString);

            //set up command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "aprocedureSelectUsers";

            dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;

            //set up dataSet for table
            dataSet = new DataSet();
            dt = new DataSet();

            //dataAdapter.Fill(dataSet, "Users");

            command.CommandText = "bprocedureSelectDepartment";
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(dataSet, "Department");

            command.CommandText = "cprocedureJoinPositionDepartment";
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(dataSet, "JoinPositionDepartment");

            command.CommandText = "dprocedureSelectSSS";
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(dataSet, "SSS");

            //command.CommandText = "eprocedureSelectPhilHealth";
            //dataAdapter.SelectCommand = command;
            //dataAdapter.Fill(dataSet, "PhilHealth");

            //command.CommandText = "fprocedureSelectPagIbig";
            //dataAdapter.SelectCommand = command;
            //dataAdapter.Fill(dataSet, "PagIbig");

            //command.CommandText = "gprocedureSelectTax";
            //dataAdapter.SelectCommand = command;
            //dataAdapter.Fill(dataSet, "Tax");

            //command.CommandText = "hprocedureSelectHoliday";
            //dataAdapter.SelectCommand = command;
            //dataAdapter.Fill(dataSet, "Holiday");

        }
        #endregion
        #region Department Data
        public void GetCountDepartment(Counts counts)
        {
            SqlCommand command = new SqlCommand();
            Object returnValue;
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "bprocedureCountDepartment";
            command.Connection = connection;
            connection.Open();
            returnValue = command.ExecuteScalar();
            connection.Close();
            counts.Countss = returnValue.ToString();
        }
        public void GetLastIDDepartment(Counts counts)
        {
            SqlCommand command = new SqlCommand();
            Object returnValue;
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "bprocedureLastIDDepartment";
            command.Connection = connection;
            connection.Open();
            returnValue = command.ExecuteScalar();
            connection.Close();
            counts.LastID = returnValue.ToString();
        }
        public void AddRow(Departments department)
        {
            //get dataTable tableCourse
            DataTable dataTable = dataSet.Tables["Department"];

            //create a new dataRow
            DataRow dataRow = dataTable.NewRow();

            //assign values from course object
            dataRow["DepartmentID"] = department.DepartmentID;
            dataRow["DepartmentName"] = department.DepartmentName;

            //add the new dataRow to dataTable
            dataTable.Rows.Add(dataRow);

            AddRecord(department);
        }

        private void AddRecord(Departments department)
        {
            //set up command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            //set up commandType
            command.CommandType = CommandType.StoredProcedure;

            //set up procedure name
            command.CommandText = "bprocedureInsertDepartment";
            dataAdapter.InsertCommand = command;

            //set up parameters
            command.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);
            command.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);

            //update tableCourse from the dataSet
            dataAdapter.Update(dataSet, "Department");
        }

        public void EditRow(Departments department, int index)
        {
            //get selectedRow from the dataTable, tableCourse
            DataRow selectedRow = dataSet.Tables["Department"].Rows[index];

            //replace values from course object
            selectedRow["DepartmentName"] = department.DepartmentName;

            EditRecord(department, index);
        }

        private void EditRecord(Departments department, int index)
        {
            //set up command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            //set up commandType
            command.CommandType = CommandType.StoredProcedure;

            //set up procedure name
            command.CommandText = "bprocedureUpdateDepartment";
            dataAdapter.UpdateCommand = command;

            //set up parameters
            command.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);
            command.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);

            //update tableCourse from the dataSet
            dataAdapter.Update(dataSet, "Department");
        }

        public void DeleteRow(Departments department, int index)
        {
            //get selectedRow from the dataTable, tableCourse
            DataRow selectedRow = dataSet.Tables["Department"].Rows[index];

            //delete selected row from the dataSet
            selectedRow.Delete();

            DeleteRecord(department, index);
        }

        private void DeleteRecord(Departments department, int index)
        {
            //set up command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            //set up commandType
            command.CommandType = CommandType.StoredProcedure;

            //set up procedure name
            command.CommandText = "bprocedureDeleteDepartment";
            dataAdapter.DeleteCommand = command;

            //set up parameters
            command.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);

            //update tableCourse from the dataSet
            dataAdapter.Update(dataSet, "Department");
        }
        public void SearchRecordDepartment(string input)
        {
            dataSet.Clear();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "bprocedureSearchDepartment";
            command.Parameters.AddWithValue("@Input", "%" + input + "%");
            dataAdapter.SelectCommand = command;

            dataAdapter.Fill(dataSet, "Department");
        }
        #endregion
        #region Position Data
        public void GetCountPosition(Counts counts)
        {
            SqlCommand command = new SqlCommand();
            Object returnValue;
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "cprocedureCountPosition";
            command.Connection = connection;
            connection.Open();
            returnValue = command.ExecuteScalar();
            connection.Close();
            counts.Countss = returnValue.ToString();
        }
        public void GetLastIDPosition(Counts counts)
        {
            SqlCommand command = new SqlCommand();
            Object returnValue;
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "cprocedureLastIDPosition";
            command.Connection = connection;
            connection.Open();
            returnValue = command.ExecuteScalar();
            connection.Close();
            counts.LastID = returnValue.ToString();
        }
        public void AddRow(Positions positions)
        {
            DataTable dataTable = dataSet.Tables["JoinPositionDepartment"];
            DataRow dataRow = dataTable.NewRow();
            dataRow["PositionID"] = positions.PositionID;
            dataRow["PositionName"] = positions.PositionName;
            dataRow["Salary"] = positions.Salary;
            dataRow["DepartmentName"] = positions.Department.DepartmentName;
            dataTable.Rows.Add(dataRow);
            AddRecord(positions);
        }

        private void AddRecord(Positions positions)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "cprocedureInsertPosition";
            dataAdapter.InsertCommand = command;

            command.Parameters.AddWithValue("@PositionID", positions.PositionID);
            command.Parameters.AddWithValue("@PositionName", positions.PositionName);
            command.Parameters.AddWithValue("@Salary", positions.Salary);
            command.Parameters.AddWithValue("@DepartmentID", positions.Department.DepartmentID);
            dataAdapter.Update(dataSet, "JoinPositionDepartment");
        }

        public void EditRow(Positions positions, int index)
        {
            DataRow selectedRow = dataSet.Tables["JoinPositionDepartment"].Rows[index];
            selectedRow["PositionID"] = positions.PositionID;
            selectedRow["PositionName"] = positions.PositionName;
            selectedRow["Salary"] = positions.Salary;
            selectedRow["DepartmentName"] = positions.Department.DepartmentName;

            EditRecord(positions, index);
        }

        private void EditRecord(Positions positions, int index)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "cprocedureUpdatePosition";
            dataAdapter.UpdateCommand = command;

            command.Parameters.AddWithValue("@PositionID", positions.PositionID);
            command.Parameters.AddWithValue("@PositionName", positions.PositionName);
            command.Parameters.AddWithValue("@Salary", positions.Salary);
            command.Parameters.AddWithValue("@DepartmentID", positions.Department.DepartmentID);
            dataAdapter.Update(dataSet, "JoinPositionDepartment");
        }

        public void DeleteRow(Positions positions, int index)
        {
            DataRow selectedRow = dataSet.Tables["JoinPositionDepartment"].Rows[index];
            selectedRow.Delete();

            DeleteRecord(positions, index);
        }

        private void DeleteRecord(Positions position, int index)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "cprocedureDeletePosition";
            dataAdapter.DeleteCommand = command;

            command.Parameters.AddWithValue("@PositionID", position.PositionID);
            dataAdapter.Update(dataSet, "JoinPositionDepartment");
        }
        public void SearchRecordPosition(string input)
        {
            dataSet.Clear();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "cprocedureSearchPosition";
            command.Parameters.AddWithValue("@Input", "%" + input + "%");
            dataAdapter.SelectCommand = command;

            dataAdapter.Fill(dataSet, "JoinPositionDepartment");
        }
        #endregion
        #region SSS Data
        public void GetCountSSS(Counts counts)
        {
            SqlCommand command = new SqlCommand();
            Object returnValue;
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "dprocedureCountSSS";
            command.Connection = connection;
            connection.Open();
            returnValue = command.ExecuteScalar();
            connection.Close();
            counts.Countss = returnValue.ToString();
        }
        public void GetLastIDSSS(Counts counts)
        {
            SqlCommand command = new SqlCommand();
            Object returnValue;
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "dprocedureLastIDSSS";
            command.Connection = connection;
            connection.Open();
            returnValue = command.ExecuteScalar();
            connection.Close();
            counts.LastID = returnValue.ToString();
        }
        public void DeleteSSS()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("dprocedureDeletetSSS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void SearchRecordSSS(string input)
        {
            dataSet.Clear();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "dprocedureSearchSSS";
            command.Parameters.AddWithValue("@Input", "%" + input + "%");
            dataAdapter.SelectCommand = command;

            dataAdapter.Fill(dataSet, "SSS");
        }
        #endregion
        #region PhilHealth Data
        public void GetCountPhilHealth(Counts counts)
        {
            SqlCommand command = new SqlCommand();
            Object returnValue;
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "eprocedureCountPhilHealth";
            command.Connection = connection;
            connection.Open();
            returnValue = command.ExecuteScalar();
            connection.Close();
            counts.Countss = returnValue.ToString();
        }
        public void GetLastIDPhilHealth(Counts counts)
        {
            SqlCommand command = new SqlCommand();
            Object returnValue;
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "eprocedureLastIDPhilHealth";
            command.Connection = connection;
            connection.Open();
            returnValue = command.ExecuteScalar();
            connection.Close();
            counts.LastID = returnValue.ToString();
        }
        public void DeletePhilHealth()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("eprocedureDeletetPhilHealth", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void SearchRecordPhilHealth(string input)
        {
            dataSet.Clear();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "eprocedureSearchPhilHealth";
            command.Parameters.AddWithValue("@Input", "%" + input + "%");
            dataAdapter.SelectCommand = command;

            dataAdapter.Fill(dataSet, "PhilHealth");
        }
        #endregion
        #region PagIbig Data
        public void GetCountPagIbig(Counts counts)
        {
            SqlCommand command = new SqlCommand();
            Object returnValue;
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "fprocedureCountPagIbig";
            command.Connection = connection;
            connection.Open();
            returnValue = command.ExecuteScalar();
            connection.Close();
            counts.Countss = returnValue.ToString();
        }
        public void GetLastIDPagIbig(Counts counts)
        {
            SqlCommand command = new SqlCommand();
            Object returnValue;
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "fprocedureLastIDPagIbig";
            command.Connection = connection;
            connection.Open();
            returnValue = command.ExecuteScalar();
            connection.Close();
            counts.LastID = returnValue.ToString();
        }
        public void DeletePagIbig()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("fprocedureDeletetPagIbig", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void SearchRecordPagIbig(string input)
        {
            dataSet.Clear();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "fprocedureSearchPagIbig";
            command.Parameters.AddWithValue("@Input", "%" + input + "%");
            dataAdapter.SelectCommand = command;

            dataAdapter.Fill(dataSet, "PagIbig");
        }
        #endregion
    }
}
