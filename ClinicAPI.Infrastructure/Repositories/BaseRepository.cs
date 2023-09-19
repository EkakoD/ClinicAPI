using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using ClinicAPI.Infrastructure.Models;

namespace ClinicAPI.Infrastructure.Repositories
{
    public class BaseRepository : IBaseRepository

    {
        //private ConfigurationManager _config;
        string _connectionString => "Server=localhost;Database=Clinic;User Id=sa;Password=reallyStrongPwd123;";
        public BaseRepository()
        {
            //config = config;
        }
        public Task Create<T>(string procedureName, dynamic model) where T : class
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(procedureName, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (var property in model.GetType().GetProperties())
                        {
                            SqlParameter param = new SqlParameter("@" + property.Name, property.GetValue(model, null));
                            cmd.Parameters.Add(param);
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int column1Value = reader.GetInt32(0);
                                string column2Value = reader.GetString(1);

                            }
                        }
                    }
                }
                return Task.CompletedTask;

            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }

        public T GetSingle<T>(string procedureName, dynamic model) where T : new()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(procedureName, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var property in model.GetType().GetProperties())
                        {
                            SqlParameter param = new SqlParameter("@" + property.Name, property.GetValue(model, null));
                            cmd.Parameters.Add(param);
                        }
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                T result = new T();
                                Type type = typeof(T);

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    string fieldName = reader.GetName(i);
                                    PropertyInfo propertyInfo = type.GetProperty(fieldName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                                    if (propertyInfo != null && !reader.IsDBNull(i))
                                    {
                                        propertyInfo.SetValue(result, reader[i]);
                                    }
                                }
                                return result;
                            }
                            return default(T);

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("დაფიქრსირდა გაუთვალისწინებელი შეცდომა");
            }

        }
    }
}