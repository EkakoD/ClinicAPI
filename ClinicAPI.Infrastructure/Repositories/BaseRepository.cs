using System.Data;
using System.Data.SqlClient;
using ClinicAPI.Infrastructure.Models;

namespace ClinicAPI.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class

    {
        //private ConfigurationManager _config;
        string _connectionString => "Server=localhost;Database=Clinic;User Id=sa;Password=reallyStrongPwd123;";
        public BaseRepository()
        {
            //config = config;
        }
        public void Create(string tableName, string procedureName, dynamic model)
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
                            // Access the results here
                            int column1Value = reader.GetInt32(0);
                            string column2Value = reader.GetString(1);

                            Console.WriteLine($"Column1: {column1Value}, Column2: {column2Value}");
                        }
                    }
                }
            }
        }

        public async Task<TempCodeModel> GetTempCode(string email, string code)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("GetTempCode", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@code", code);

                    using (var reader = command.ExecuteReader())
                    {

                        var tempCode = new TempCodeModel
                        {
                            Code = Convert.ToString(reader["Code"]),
                            CreateDate = Convert.ToDateTime(reader["CreateDate"]),
                            Id = Convert.ToInt32(reader["Id"]),
                            Email = Convert.ToString(reader["Email"]),

                        };

                        return tempCode;
                    }
                }
            }
        }
    }
}