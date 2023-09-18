using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
    }
}