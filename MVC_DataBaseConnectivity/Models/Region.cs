using System;
using System.Data.SqlClient;

namespace MVC_DataBaseConnectivity.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        //Get All
        public List<Region> GetAll()
        {
            try
            {
                SqlConnection _connection = DatabaseConnection.Connection();
                var regions = new List<Region>();
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "select * from regions";
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Region region = new Region();
                    region.Id = reader.GetInt32(0);
                    region.Name = reader.GetString(1);
                    regions.Add(region);
                }
                reader.Close();
                _connection.Close();
                return regions;
            }
            catch
            {
                return new List<Region>();
            }
        }

        //Get By ID Region
        public Region? GetById(int id)
        {
            try
            {
                SqlConnection _connection = DatabaseConnection.Connection();
                _connection.Open();
                var region = new Region();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "select * from regions where id = @id";

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = id;
                cmd.Parameters.Add(pId);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    region.Id = reader.GetInt32(0);
                    region.Name = reader.GetString(1);
                }
                reader.Close();
                _connection.Close();
                return region;
            }
            catch
            {
                return null;
            }
        }

        //Insert Region
        public int Insert(Region region)
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "insert into regions (name) values (@name);";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = region.Name;
                cmd.Parameters.Add(pName);

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

        //Update Region
        public int Update(Region region)
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "update regions set name = @name where id = @id;";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = region.Name;
                cmd.Parameters.Add(pName);

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = region.Id;
                cmd.Parameters.Add(pId);

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

        //Delete Region
        public int Delete(Region region)
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "delete from regions where id = @id;";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = region.Id;
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
