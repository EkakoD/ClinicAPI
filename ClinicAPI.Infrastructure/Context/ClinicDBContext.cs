using System;
using System.Data;
using System.Data.SqlClient;

namespace ClinicAPI.Infrastructure.Context
{
    public class ClinicDBContext : IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection _connection;

        public ClinicDBContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void OpenConnection()
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        public SqlCommand CreateCommand(string sql, CommandType commandType = CommandType.Text)
        {
            var command = _connection.CreateCommand();
            command.CommandText = sql;
            command.CommandType = commandType;
            return command;
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}

