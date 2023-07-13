using MVC_DataBaseConnectivity.Models;
using System;
using System.Data.SqlClient;

namespace MVC_DataBaseConnectivity.Models
{
    public class LocationModel
    {
        
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? Postal { get; set; }
        public string City { get; set; }
        public string? State { get; set; }
        public string? CountryId { get; set; }
        
        //GET ALL
        public List<LocationModel> GetAll()
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            try
            {
                List<LocationModel> locations = new List<LocationModel>();
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "select * from locations";
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LocationModel location = new LocationModel();

                    location.Id = reader.GetInt32(0);
                    location.Street = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    location.Postal = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    location.City = reader.GetString(3);
                    location.State = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    location.CountryId = reader.IsDBNull(5) ? "" : reader.GetString(5);
                    locations.Add(location);
                }
                reader.Close();
                _connection.Close();
                return locations;
            }
            catch
            {
                return new List<LocationModel>();
            }
        }

        //Get By ID
        public LocationModel? GetById(int id)
        {
            try
            {
                SqlConnection _connection = DatabaseConnection.Connection();
                _connection.Open();
                LocationModel location = new LocationModel();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "select * from locations where id = @id";

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = id;
                cmd.Parameters.Add(pId);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    location.Id = reader.GetInt32(0);
                    location.Street = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    location.Postal = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    location.City = reader.GetString(3);
                    location.State = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    location.CountryId = reader.IsDBNull(5) ? "" : reader.GetString(5);
                }
                reader.Close();
                _connection.Close();
                return location;
            }
            catch
            {
                return null;
            }
        }

        //Insert
        public int Insert(LocationModel location)
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "insert into locations (id, street_address, postal_code, city, state_province, country_id) " +
                "values (@id, @street, @postal, @city, @state, @countryId);";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = location.Id;
                cmd.Parameters.Add(pId);

                SqlParameter pStreet = new SqlParameter();
                pStreet.ParameterName = "@street";
                pStreet.SqlDbType = System.Data.SqlDbType.VarChar;
                pStreet.Value = location.Street;
                cmd.Parameters.Add(pStreet);

                SqlParameter pPostal = new SqlParameter();
                pPostal.ParameterName = "@postal";
                pPostal.SqlDbType = System.Data.SqlDbType.VarChar;
                pPostal.Value = location.Postal;
                cmd.Parameters.Add(pPostal);

                SqlParameter pCity = new SqlParameter();
                pCity.ParameterName = "@city";
                pCity.SqlDbType = System.Data.SqlDbType.VarChar;
                pCity.Value = location.City;
                cmd.Parameters.Add(pCity);

                SqlParameter pState = new SqlParameter();
                pState.ParameterName = "@state";
                pState.SqlDbType = System.Data.SqlDbType.VarChar;
                pState.Value = location.State;
                cmd.Parameters.Add(pState);

                SqlParameter pCountryId = new SqlParameter();
                pCountryId.ParameterName = "@countryId";
                pCountryId.SqlDbType = System.Data.SqlDbType.Char;
                pCountryId.Value = location.CountryId;
                cmd.Parameters.Add(pCountryId);

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
        public int Update(LocationModel location)
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "update locations set street_address = @street, postal_code = @postal, city = @city, state_province = @state, country_id = @countryId " +
                "where id = @id;";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = location.Id;
                cmd.Parameters.Add(pId);

                SqlParameter pStreet = new SqlParameter();
                pStreet.ParameterName = "@street";
                pStreet.SqlDbType = System.Data.SqlDbType.VarChar;
                pStreet.Value = location.Street;
                cmd.Parameters.Add(pStreet);

                SqlParameter pPostal = new SqlParameter();
                pPostal.ParameterName = "@postal";
                pPostal.SqlDbType = System.Data.SqlDbType.VarChar;
                pPostal.Value = location.Postal;
                cmd.Parameters.Add(pPostal);

                SqlParameter pCity = new SqlParameter();
                pCity.ParameterName = "@city";
                pCity.SqlDbType = System.Data.SqlDbType.VarChar;
                pCity.Value = location.City;
                cmd.Parameters.Add(pCity);

                SqlParameter pState = new SqlParameter();
                pState.ParameterName = "@state";
                pState.SqlDbType = System.Data.SqlDbType.VarChar;
                pState.Value = location.State;
                cmd.Parameters.Add(pState);

                SqlParameter pCountryId = new SqlParameter();
                pCountryId.ParameterName = "@countryId";
                pCountryId.SqlDbType = System.Data.SqlDbType.Char;
                pCountryId.Value = location.CountryId;
                cmd.Parameters.Add(pCountryId);

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
        public int Delete(LocationModel location)
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "delete from locations where id = @id;";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = location.Id;
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
