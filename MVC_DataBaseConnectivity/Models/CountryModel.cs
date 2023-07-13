using System;
using System.Data.SqlClient;

namespace MVC_DataBaseConnectivity.Models
{
    public class CountryModel
    {
        
        public string Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }

        private static SqlConnection _connection = DatabaseConnection.Connection();

        public List<CountryModel> GetAll()
        {
            try
            {
                List<CountryModel> countries = new List<CountryModel>();
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "select * from countries";
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CountryModel country = new CountryModel();
                    country.Id = reader.GetString(0);
                    country.Name = reader.GetString(1);
                    country.RegionId = reader.GetInt32(2);
                    countries.Add(country);
                }
                reader.Close();
                _connection.Close();
                return countries;
            }
            catch
            {
                return new List<CountryModel>();
            }
        }

        public CountryModel? GetById(string id)
        {
            try
            {
                CountryModel country = new CountryModel();
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "select * from countries where id = @id";

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Char;
                pId.Value = id;
                cmd.Parameters.Add(pId);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    country.Id = reader.GetString(0);
                    country.Name = reader.GetString(1);
                    country.RegionId = reader.GetInt32(2);
                }
                reader.Close();
                _connection.Close();

                return country;
            }
            catch
            {
                return null;
            }
        }

        //Insert
        public int Insert(CountryModel country)
        {
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "insert into countries (id, name, region_id) values (@id, @name, @region_id);";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Char;
                pId.Value = country.Id;
                cmd.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = country.Name;
                cmd.Parameters.Add(pName);

                SqlParameter pRegionId = new SqlParameter();
                pRegionId.ParameterName = "@region_id";
                pRegionId.SqlDbType = System.Data.SqlDbType.Int;
                pRegionId.Value = country.RegionId;
                cmd.Parameters.Add(pRegionId);

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
        public int Update(CountryModel country)
        {
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "update countries set name = @name, region_id = @regionId where id = @id;";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = country.Name;
                cmd.Parameters.Add(pName);

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Char;
                pId.Value = country.Id;
                cmd.Parameters.Add(pId);

                SqlParameter pRegionId = new SqlParameter();
                pRegionId.ParameterName = "@regionId";
                pRegionId.SqlDbType = System.Data.SqlDbType.Int;
                pRegionId.Value = country.RegionId;
                cmd.Parameters.Add(pRegionId);

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
        public int Delete(CountryModel country)
        {
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "delete from countries where id = @id;";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Char;
                pId.Value = country.Id;
                cmd.Parameters.Add(pId);

                int result = cmd.ExecuteNonQuery();
                transaction.Commit();

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
