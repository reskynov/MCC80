using System;
using System.Data.SqlClient;

namespace MVC_DataBaseConnectivity.Models
{
    public class Job
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int? MinSalary { get; set; }
        public int? MaxSalary { get; set; }

        //Get All
        public List<Job> GetAll()
        {
            try
            {
                SqlConnection _connection = DatabaseConnection.Connection();
                List<Job> jobs = new List<Job>();
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "select * from jobs order by cast(id as int) ASC";
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Job job = new Job();
                    job.Id = reader.GetString(0);
                    job.Title = reader.GetString(1);
                    job.MinSalary = reader.GetInt32(2);
                    job.MaxSalary = reader.GetInt32(3);
                    jobs.Add(job);
                }
                reader.Close();
                _connection.Close();
                return jobs;
            }
            catch
            {
                return new List<Job>();
            }
        }

        //Get By ID
        public Job? GetById(string id)
        {
            try
            {
                SqlConnection _connection = DatabaseConnection.Connection();
                Job job = new Job();
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "select * from jobs where id = @id";

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = id;
                cmd.Parameters.Add(pId);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    job.Id = reader.GetString(0);
                    job.Title = reader.GetString(1);
                    job.MinSalary = reader.IsDBNull(2) ? -1 : reader.GetInt32(2);
                    job.MaxSalary = reader.IsDBNull(3) ? -1 : reader.GetInt32(3);
                }
                reader.Close();
                _connection.Close();

                return job;
            }
            catch
            {
                return null;
            }
        }

        //Insert
        public int Insert(Job job)
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "insert into jobs (id, title, min_salary, max_salary) " +
                "values (@id, @title, @min, @max);";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Char;
                pId.Value = job.Id;
                cmd.Parameters.Add(pId);

                SqlParameter pTitle = new SqlParameter();
                pTitle.ParameterName = "@title";
                pTitle.SqlDbType = System.Data.SqlDbType.VarChar;
                pTitle.Value = job.Title;
                cmd.Parameters.Add(pTitle);

                SqlParameter pMin = new SqlParameter();
                pMin.ParameterName = "@min";
                pMin.SqlDbType = System.Data.SqlDbType.Int;
                pMin.Value = job.MinSalary;
                cmd.Parameters.Add(pMin);

                SqlParameter pMax = new SqlParameter();
                pMax.ParameterName = "@max";
                pMax.SqlDbType = System.Data.SqlDbType.Int;
                pMax.Value = job.MaxSalary;
                cmd.Parameters.Add(pMax);

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
        public int Update(Job job)
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "update jobs set title = @title, min_salary = @min, max_salary = @max " +
                "where id = @id;";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Char;
                pId.Value = job.Id;
                cmd.Parameters.Add(pId);

                SqlParameter pTitle = new SqlParameter();
                pTitle.ParameterName = "@title";
                pTitle.SqlDbType = System.Data.SqlDbType.VarChar;
                pTitle.Value = job.Title;
                cmd.Parameters.Add(pTitle);

                SqlParameter pMin = new SqlParameter();
                pMin.ParameterName = "@min";
                pMin.SqlDbType = System.Data.SqlDbType.Int;
                pMin.Value = job.MinSalary;
                cmd.Parameters.Add(pMin);

                SqlParameter pMax = new SqlParameter();
                pMax.ParameterName = "@max";
                pMax.SqlDbType = System.Data.SqlDbType.Int;
                pMax.Value = job.MaxSalary;
                cmd.Parameters.Add(pMax);

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
        public int Delete(Job job)
        {
            SqlConnection _connection = DatabaseConnection.Connection();
            _connection.Open();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "delete from jobs where id = @id;";

            SqlTransaction transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = job.Id;
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
