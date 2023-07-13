using System;
using System.Data.SqlClient;

namespace MVC_DataBaseConnectivity.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string? Lname { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime HireDate { get; set; }
        public int? Salary { get; set; }
        public decimal? Comission { get; set; }
        public int? ManagerId { get; set; }
        public string JobId { get; set; }
        public int DepartmentId { get; set; }

        //Get All
        public List<EmployeeModel> GetAll()
        {
            try
            {
                List<EmployeeModel> employees = new List<EmployeeModel>();
                SqlConnection _connection = DatabaseConnection.Connection();
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "select * from employees";
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeModel employee = new EmployeeModel();
                    employee.Id = reader.GetInt32(0);
                    employee.Fname = reader.GetString(1);
                    employee.Lname = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    employee.Email = reader.GetString(3);
                    employee.Phone = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    employee.HireDate = reader.GetDateTime(5);
                    employee.Salary = reader.IsDBNull(6) ? -1 : reader.GetInt32(6);
                    employee.Comission = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7);
                    employee.ManagerId = reader.IsDBNull(8) ? -1 : reader.GetInt32(8);
                    employee.JobId = reader.GetString(9);
                    employee.DepartmentId = reader.GetInt32(10);
                    employees.Add(employee);
                }
                reader.Close();
                _connection.Close();

                return employees;
            }
            catch
            {
                return new List<EmployeeModel>();
            }
        }


        //Get By ID
        public EmployeeModel? GetById(int id)
        {
            try
            {
                EmployeeModel employee = new EmployeeModel();
                SqlConnection _connection = DatabaseConnection.Connection();
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "select * from employees where id = @id";

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = id;
                cmd.Parameters.Add(pId);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employee.Id = reader.GetInt32(0);
                    employee.Fname = reader.GetString(1);
                    employee.Lname = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    employee.Email = reader.GetString(3);
                    employee.Phone = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    employee.HireDate = reader.GetDateTime(5);
                    employee.Salary = reader.IsDBNull(6) ? -1 : reader.GetInt32(6);
                    employee.Comission = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7);
                    employee.ManagerId = reader.IsDBNull(8) ? -1 : reader.GetInt32(8);
                    employee.JobId = reader.GetString(9);
                    employee.DepartmentId = reader.GetInt32(10);
                }
                reader.Close();
                _connection.Close();

                return employee;
            }
            catch
            {
                return null;
            }
        }

        //Insert
        public int Insert(EmployeeModel employee)
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "insert into employees (id, first_name, last_name, email, phone_number, hire_date, salary, comission_pct, manager_id, job_id, department_id) " +
                "values (@id, @fname, @lname, @email, @phone, @hire, @salary, @commis, @managerId, @jobId, @departmentId);";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = employee.Id;
                cmd.Parameters.Add(pId);

                SqlParameter pFName = new SqlParameter();
                pFName.ParameterName = "@fname";
                pFName.SqlDbType = System.Data.SqlDbType.VarChar;
                pFName.Value = employee.Fname;
                cmd.Parameters.Add(pFName);

                SqlParameter pLName = new SqlParameter();
                pLName.ParameterName = "@lname";
                pLName.SqlDbType = System.Data.SqlDbType.VarChar;
                pLName.Value = employee.Lname;
                cmd.Parameters.Add(pLName);

                SqlParameter pEmail = new SqlParameter();
                pEmail.ParameterName = "@email";
                pEmail.SqlDbType = System.Data.SqlDbType.VarChar;
                pEmail.Value = employee.Email;
                cmd.Parameters.Add(pEmail);

                SqlParameter pPhone = new SqlParameter();
                pPhone.ParameterName = "@phone";
                pPhone.SqlDbType = System.Data.SqlDbType.VarChar;
                pPhone.Value = employee.Phone;
                cmd.Parameters.Add(pPhone);

                SqlParameter pHire = new SqlParameter();
                pHire.ParameterName = "@hire";
                pHire.SqlDbType = System.Data.SqlDbType.DateTime;
                pHire.Value = DateTime.Now;
                cmd.Parameters.Add(pHire);

                SqlParameter pSalary = new SqlParameter();
                pSalary.ParameterName = "@salary";
                pSalary.SqlDbType = System.Data.SqlDbType.Int;
                pSalary.Value = employee.Salary;
                cmd.Parameters.Add(pSalary);

                SqlParameter pCommis = new SqlParameter();
                pCommis.ParameterName = "@commis";
                pCommis.SqlDbType = System.Data.SqlDbType.Decimal;
                pCommis.Value = employee.Comission;
                cmd.Parameters.Add(pCommis);

                SqlParameter pManId = new SqlParameter();
                pManId.ParameterName = "@managerId";
                pManId.SqlDbType = System.Data.SqlDbType.Int;
                pManId.Value = employee.ManagerId;
                cmd.Parameters.Add(pManId);

                SqlParameter pJobId = new SqlParameter();
                pJobId.ParameterName = "@jobId";
                pJobId.SqlDbType = System.Data.SqlDbType.Int;
                pJobId.Value = employee.JobId;
                cmd.Parameters.Add(pJobId);

                SqlParameter pDeId = new SqlParameter();
                pDeId.ParameterName = "@departmentId";
                pDeId.SqlDbType = System.Data.SqlDbType.Int;
                pDeId.Value = employee.DepartmentId;
                cmd.Parameters.Add(pDeId);

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
        public int Update(EmployeeModel employee)
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "update employees set first_name = @fname, last_name = @lname, email = @email, phone_number = @phone, salary = @salary, comission_pct = @commis, manager_id = @managerId, job_id = @jobId, department_id = @departmentId " +
            "where id = @id;";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = employee.Id;
                cmd.Parameters.Add(pId);

                SqlParameter pFName = new SqlParameter();
                pFName.ParameterName = "@fname";
                pFName.SqlDbType = System.Data.SqlDbType.VarChar;
                pFName.Value = employee.Fname;
                cmd.Parameters.Add(pFName);

                SqlParameter pLName = new SqlParameter();
                pLName.ParameterName = "@lname";
                pLName.SqlDbType = System.Data.SqlDbType.VarChar;
                pLName.Value = employee.Lname;
                cmd.Parameters.Add(pLName);

                SqlParameter pEmail = new SqlParameter();
                pEmail.ParameterName = "@email";
                pEmail.SqlDbType = System.Data.SqlDbType.VarChar;
                pEmail.Value = employee.Email;
                cmd.Parameters.Add(pEmail);

                SqlParameter pPhone = new SqlParameter();
                pPhone.ParameterName = "@phone";
                pPhone.SqlDbType = System.Data.SqlDbType.VarChar;
                pPhone.Value = employee.Phone;
                cmd.Parameters.Add(pPhone);

                SqlParameter pHire = new SqlParameter();
                pHire.ParameterName = "@hire";
                pHire.SqlDbType = System.Data.SqlDbType.DateTime;
                pHire.Value = DateTime.Now;
                cmd.Parameters.Add(pHire);

                SqlParameter pSalary = new SqlParameter();
                pSalary.ParameterName = "@salary";
                pSalary.SqlDbType = System.Data.SqlDbType.Int;
                pSalary.Value = employee.Salary;
                cmd.Parameters.Add(pSalary);

                SqlParameter pCommis = new SqlParameter();
                pCommis.ParameterName = "@commis";
                pCommis.SqlDbType = System.Data.SqlDbType.Decimal;
                pCommis.Value = employee.Comission;
                cmd.Parameters.Add(pCommis);

                SqlParameter pManId = new SqlParameter();
                pManId.ParameterName = "@managerId";
                pManId.SqlDbType = System.Data.SqlDbType.Int;
                pManId.Value = employee.ManagerId;
                cmd.Parameters.Add(pManId);

                SqlParameter pJobId = new SqlParameter();
                pJobId.ParameterName = "@jobId";
                pJobId.SqlDbType = System.Data.SqlDbType.Int;
                pJobId.Value = employee.JobId;
                cmd.Parameters.Add(pJobId);

                SqlParameter pDeId = new SqlParameter();
                pDeId.ParameterName = "@departmentId";
                pDeId.SqlDbType = System.Data.SqlDbType.Int;
                pDeId.Value = employee.DepartmentId;
                cmd.Parameters.Add(pDeId);

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
        public int Delete(EmployeeModel employee)
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "delete from employees where id = @id;";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = employee.Id;
                cmd.Parameters.Add(pId);

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
