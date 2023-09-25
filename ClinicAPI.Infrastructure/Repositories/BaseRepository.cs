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
        public async Task<int> CreateOrUpdate<T>(string procedureName, dynamic model) where T : class
        {
            try
            {
                int id = 0;
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
                        SqlParameter outputParam = new SqlParameter("@InsertedId", SqlDbType.Int);
                        outputParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputParam);

                        cmd.ExecuteNonQuery();
                        id = (int)outputParam.Value;
                    }
                }
                return id;

            }
            catch (Exception ex)
            {
                throw new Exception("დაფიქსირდა შეცდომა ბაზასთან კავშირის დროს!");
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
                throw new Exception("დაფიქრსირდა გაუთვალისწინებელი შეცდომა", ex);
            }

        }

        public List<T> GetAll<T>(string procedureName, dynamic model) where T : new()
        {
            try
            {
                List<T> resultList = new List<T>();

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

                                resultList.Add(result);
                            }
                        }
                    }
                }

                return resultList;
            }
            catch (Exception ex)
            {
                throw new Exception("დაფიქსირდა გაუთვალისწინებელი შეცდომა", ex);
            }
        }
    }
}