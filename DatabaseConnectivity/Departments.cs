using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection.PortableExecutable;

namespace DatabaseConnectivity
{
    public class Departments
    {
        private static SqlConnection _connection = DatabaseConnection.Connection();

        //Get All
        public static void GetDepartments()
        {
            try
            {
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "select * from departments";
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write("ID : " + reader.GetInt32(0));

                    Console.Write(", Name : " + reader.GetString(1));

                    Console.Write(", Location ID : " + reader.GetInt32(2));

                    int managerId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                    string managerIdString = "";
                    if (managerId == 0)
                    {
                        managerIdString = "EMPTY";
                    }
                    else
                    {
                        managerIdString = managerId.ToString();
                    }
                    Console.WriteLine(", Manager ID : " + managerIdString);
                }
                reader.Close();
                _connection.Close();
            }
            catch
            {
                Console.WriteLine("Error connection to database");
            }
        }

        //Insert
        public static void SetDepartments(int departmentId, string name, int locationId, int managerId)
        {
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
                pId.Value = departmentId;
                cmd.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = name;
                cmd.Parameters.Add(pName);

                SqlParameter pLocId = new SqlParameter();
                pLocId.ParameterName = "@locationId";
                pLocId.SqlDbType = System.Data.SqlDbType.Int;
                pLocId.Value = locationId;
                cmd.Parameters.Add(pLocId);

                SqlParameter pManId = new SqlParameter();
                pManId.ParameterName = "@managerId";
                pManId.SqlDbType = System.Data.SqlDbType.Int;
                pManId.Value = managerId;
                cmd.Parameters.Add(pManId);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Insert Success");
                    transaction.Commit();
                }
                else
                {
                    Console.WriteLine("Insert Failed");
                }
                _connection.Close();
            }
            catch
            {
                //mengembalikan ke status awal sebelum diinsert
                transaction.Rollback();
                Console.WriteLine("Error connection to database");
            }
        }

        //Update
        public static void UpdateDepartments(int departmentId, string name, int locationId, int managerId)
        {
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
                pId.Value = departmentId;
                cmd.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = name;
                cmd.Parameters.Add(pName);

                SqlParameter pLocId = new SqlParameter();
                pLocId.ParameterName = "@locationId";
                pLocId.SqlDbType = System.Data.SqlDbType.Int;
                pLocId.Value = locationId;
                cmd.Parameters.Add(pLocId);

                SqlParameter pManId = new SqlParameter();
                pManId.ParameterName = "@managerId";
                pManId.SqlDbType = System.Data.SqlDbType.Int;
                pManId.Value = managerId;
                cmd.Parameters.Add(pManId);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Update Success");
                    transaction.Commit();
                }
                else
                {
                    Console.WriteLine("Update Failed");
                }
                _connection.Close();
            }
            catch
            {
                //mengembalikan ke status awal sebelum diupdate
                transaction.Rollback();
                Console.WriteLine("Error connection to database");
            }
        }

        //Delete
        public static void DeleteDepartments(int idDepartments)
        {
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
                pId.Value = idDepartments;
                cmd.Parameters.Add(pId);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Delete Success");
                    transaction.Commit();
                }
                else
                {
                    Console.WriteLine("Delete Failed");
                }
                _connection.Close();
            }
            catch
            {
                //mengembalikan ke status awal sebelum didelete
                transaction.Rollback();
                Console.WriteLine("Error connection to database");
            }
        }

        //Get By ID
        public static void GetByIdDepartments(int idJobs)
        {
            try
            {
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "select * from departments where id = @id";

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = idJobs;
                cmd.Parameters.Add(pId);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("FOUND");
                    Console.Write("ID : " + reader.GetInt32(0));

                    Console.Write(", Name : " + reader.GetString(1));

                    Console.Write(", Location ID : " + reader.GetInt32(2));

                    int managerId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                    string managerIdString = "";
                    if (managerId == 0)
                    {
                        managerIdString = "EMPTY";
                    }
                    else
                    {
                        managerIdString = managerId.ToString();
                    }
                    Console.WriteLine(", Manager ID : " + managerIdString);
                }
                reader.Close();
                _connection.Close();
            }
            catch
            {
                Console.WriteLine("Error connection to database");
            }
        }
    }
}
