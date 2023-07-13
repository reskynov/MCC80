using System;
using System.Data.SqlClient;

namespace MVC_DataBaseConnectivity.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int? ManagerId { get; set; }

        public List<DepartmentModel> GetAll()
        {
            try
            {
                SqlConnection _connection = DatabaseConnection.Connection();
                _connection.Open();

                List<DepartmentModel> departments = new List<DepartmentModel>();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "select * from departments";
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DepartmentModel department = new DepartmentModel();
                    department.Id = reader.GetInt32(0);
                    department.Name = reader.GetString(1);
                    department.LocationId = reader.GetInt32(2);
                    department.ManagerId = reader.IsDBNull(3) ? -1 : reader.GetInt32(3);
                    departments.Add(department);
                }
                reader.Close();
                _connection.Close();

                return departments;
            }
            catch
            {
                return new List<DepartmentModel>();
            }
        }

        //Get By ID
        public DepartmentModel? GetById(int id)
        {
            try
            {
                SqlConnection _connection = DatabaseConnection.Connection();
                _connection.Open();
                DepartmentModel department = new DepartmentModel();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "select * from departments where id = @id";

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = id;
                cmd.Parameters.Add(pId);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    department.Id = reader.GetInt32(0);
                    department.Name = reader.GetString(1);
                    department.LocationId = reader.GetInt32(2);
                    department.ManagerId = reader.IsDBNull(3) ? -1 : reader.GetInt32(3);
                }
                reader.Close();
                _connection.Close();
                return department;
            }
            catch
            {
                return null;
            }
        }

        //Insert
        public int Insert(DepartmentModel department)
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "insert into departments (id, name, location_id, manager_id) " +
                "values (@id, @name, @locationId, @managerId);";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = department.Id;
                cmd.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = department.Name;
                cmd.Parameters.Add(pName);

                SqlParameter pLocId = new SqlParameter();
                pLocId.ParameterName = "@locationId";
                pLocId.SqlDbType = System.Data.SqlDbType.Int;
                pLocId.Value = department.LocationId;
                cmd.Parameters.Add(pLocId);

                SqlParameter pManId = new SqlParameter();
                pManId.ParameterName = "@managerId";
                pManId.SqlDbType = System.Data.SqlDbType.Int;
                pManId.Value = department.ManagerId;
                cmd.Parameters.Add(pManId);

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
        public int Update(DepartmentModel department)
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "update departments set name = @name, location_id = @locationId, manager_id = @managerId " +
                "where id = @id;";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = department.Id;
                cmd.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = department.Name;
                cmd.Parameters.Add(pName);

                SqlParameter pLocId = new SqlParameter();
                pLocId.ParameterName = "@locationId";
                pLocId.SqlDbType = System.Data.SqlDbType.Int;
                pLocId.Value = department.LocationId;
                cmd.Parameters.Add(pLocId);

                SqlParameter pManId = new SqlParameter();
                pManId.ParameterName = "@managerId";
                pManId.SqlDbType = System.Data.SqlDbType.Int;
                pManId.Value = department.ManagerId;
                cmd.Parameters.Add(pManId);

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
        public int Delete(DepartmentModel department)
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "delete from departments where id = @id;";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = department.Id;
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
