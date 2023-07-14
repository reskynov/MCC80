using System;
using System.Data.SqlClient;
using System.Globalization;

namespace MVC_DataBaseConnectivity.Models
{
    public class History
    {

        public DateTime StartDate { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? EndDate { get; set; }
        public int DepartmentId { get; set; }
        public string JobId { get; set; }

        //Get All
        public List<History> GetAll()
        {
            try
            {
                SqlConnection _connection = DatabaseConnection.Connection();
                List<History> histories = new List<History>();
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "select * from histories";
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    History history = new History();
                    history.StartDate = reader.GetDateTime(0);
                    history.EmployeeId = reader.GetInt32(1);
                    history.EndDate = reader.IsDBNull(2) ? null : reader.GetDateTime(2);
                    history.DepartmentId = reader.GetInt32(3);
                    history.JobId = reader.GetString(4);
                    histories.Add(history);

                }
                reader.Close();
                _connection.Close();
                return histories;
            }
            catch
            {
                return new List<History>();
            }
        }

        //Get By ID
        public List<History> GetById(int id)
        {
            try
            {
                SqlConnection _connection = DatabaseConnection.Connection();
                _connection.Open();
                List<History> histories = new List<History>();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "select * from histories where employee_id = @id";

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = id;
                cmd.Parameters.Add(pId);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    History history = new History();
                    history.StartDate = reader.GetDateTime(0);
                    history.EmployeeId = reader.GetInt32(1);
                    history.EndDate = reader.IsDBNull(2) ? null : reader.GetDateTime(2);
                    history.DepartmentId = reader.GetInt32(3);
                    history.JobId = reader.GetString(4);
                    histories.Add(history);
                }
                reader.Close();
                _connection.Close();

                return histories;
            }
            catch
            {
                return new List<History>();
            }
        }

        //Insert
        public int Insert(History history)
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "insert into histories (start_date, employee_id, end_date, department_id, job_id) " +
                "values (@startDate, @employeeId, @endDate, @departmentId, @jobId);";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                DateTime startDate = DateTime.Now;
                SqlParameter pStart = new SqlParameter();
                pStart.ParameterName = "@startDate";
                pStart.SqlDbType = System.Data.SqlDbType.DateTime;
                pStart.Value = startDate;
                cmd.Parameters.Add(pStart);

                SqlParameter pEmId = new SqlParameter();
                pEmId.ParameterName = "@employeeId";
                pEmId.SqlDbType = System.Data.SqlDbType.Int;
                pEmId.Value = history.EmployeeId;
                cmd.Parameters.Add(pEmId);

                SqlParameter pEnd = new SqlParameter();
                pEnd.ParameterName = "@endDate";
                pEnd.SqlDbType = System.Data.SqlDbType.DateTime;
                bool wrongInput = true;
                pEnd.Value = history.EndDate;
                cmd.Parameters.Add(pEnd);

                SqlParameter pDeId = new SqlParameter();
                pDeId.ParameterName = "@departmentId";
                pDeId.SqlDbType = System.Data.SqlDbType.Int;
                pDeId.Value = history.DepartmentId;
                cmd.Parameters.Add(pDeId);

                SqlParameter pJobId = new SqlParameter();
                pJobId.ParameterName = "@jobId";
                pJobId.SqlDbType = System.Data.SqlDbType.Char;
                pJobId.Value = history.JobId;
                cmd.Parameters.Add(pJobId);

                int result = cmd.ExecuteNonQuery();

                transaction.Commit();
                _connection.Close();

                return result;
            }
            catch
            {
                //mengembalikan ke status awal sebelum diinsert
                transaction.Rollback();
                return -1;
            }
        }

        //Update
        public int Update(History history)
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "update histories set end_date = @endDate " +
                "where employee_id = @employeeId and job_id = @jobId and department_id = @departmentId;";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                DateTime startDate = DateTime.Now;
                SqlParameter pStart = new SqlParameter();
                pStart.ParameterName = "@startDate";
                pStart.SqlDbType = System.Data.SqlDbType.DateTime;
                pStart.Value = startDate;
                cmd.Parameters.Add(pStart);

                SqlParameter pEmId = new SqlParameter();
                pEmId.ParameterName = "@employeeId";
                pEmId.SqlDbType = System.Data.SqlDbType.Int;
                pEmId.Value = history.EmployeeId;
                cmd.Parameters.Add(pEmId);

                SqlParameter pEnd = new SqlParameter();
                pEnd.ParameterName = "@endDate";
                pEnd.SqlDbType = System.Data.SqlDbType.DateTime;
                bool wrongInput = true;
                pEnd.Value = history.EndDate;
                cmd.Parameters.Add(pEnd);

                SqlParameter pDeId = new SqlParameter();
                pDeId.ParameterName = "@departmentId";
                pDeId.SqlDbType = System.Data.SqlDbType.Int;
                pDeId.Value = history.DepartmentId;
                cmd.Parameters.Add(pDeId);

                SqlParameter pJobId = new SqlParameter();
                pJobId.ParameterName = "@jobId";
                pJobId.SqlDbType = System.Data.SqlDbType.Char;
                pJobId.Value = history.JobId;
                cmd.Parameters.Add(pJobId);

                int result = cmd.ExecuteNonQuery();

                transaction.Commit();
                _connection.Close();

                return result;
            }
            catch
            {
                //mengembalikan ke status awal sebelum diupdate
                transaction.Rollback();
                return -1;
            }
        }

        //Delete
        public int Delete(History history)
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "delete from histories where employee_id = @employeeId and job_id = @jobId and department_id = @departmentId;";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pEmId = new SqlParameter();
                pEmId.ParameterName = "@employeeId";
                pEmId.SqlDbType = System.Data.SqlDbType.Int;
                pEmId.Value = history.EmployeeId;
                cmd.Parameters.Add(pEmId);

                SqlParameter pDeId = new SqlParameter();
                pDeId.ParameterName = "@departmentId";
                pDeId.SqlDbType = System.Data.SqlDbType.Int;
                pDeId.Value = history.DepartmentId;
                cmd.Parameters.Add(pDeId);

                SqlParameter pJobId = new SqlParameter();
                pJobId.ParameterName = "@jobId";
                pJobId.SqlDbType = System.Data.SqlDbType.Char;
                pJobId.Value = history.JobId;
                cmd.Parameters.Add(pJobId);

                int result = cmd.ExecuteNonQuery();

                transaction.Commit();
                _connection.Close();

                return result;
            }
            catch
            {
                //mengembalikan ke status awal sebelum didelete
                transaction.Rollback();
                return -1;
            }
        }
    }
}
