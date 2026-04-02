using Dapper;
using MusicDAL.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MusicDAL.Data
{
    public class DataAccess : IDataAccess
    {
        // this method will return a list of type T - only used for queries
        public async Task<IEnumerable<T>> GetDataQ<T, P>(string query, P parameters, string connectionId = "default")
        {
            IDbConnection connection = new SqlConnection(AppSettings.Instance.ConnectString);

            return await connection.QueryAsync<T>(query, parameters);
        }

        // Updated method to support both stored procedures and SQL queries
        public async Task<IEnumerable<T>> GetData<T, P>(string storedProcedure, P parameters, string connectionId = "default")
        {
            using (IDbConnection connection = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        // I need this for the Browse page.
        public IEnumerable<T> GetBrowseData<T, P>(string storedProcedure, P parameters, string connectionId = "default")
        {
            using (IDbConnection connection = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                return connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        // New method for single objects using QueryFirstOrDefaultAsync
        public async Task<T> GetDataFirstOrDefault<T, P>(string storedProcedure, P parameters, string connectionId = "default")
        {
            using (IDbConnection connection = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                return await connection.QueryFirstOrDefaultAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public T GetFirstOrDefault<T, P>(string storedProcedure, P parameters, string connectionId = "default")
        {
            using (IDbConnection connection = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                return connection.QueryFirstOrDefault<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        //This method will not return anything - only used for queries
        public async Task SaveDataQ<P>(string query, P parameters, string connectionId = "default")
        {
            IDbConnection connection = new SqlConnection(AppSettings.Instance.ConnectString);
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task SaveData<P>(string storedProcedure, P parameters, string connectionId = "default")
        {
            IDbConnection connection = new SqlConnection(AppSettings.Instance.ConnectString);

            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> SaveDataReturnId(string storedProcedure, DynamicParameters parameters, string connectionId = "default")
        {
            using (IDbConnection connection = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                // Get the output parameter value
                return parameters.Get<int>("@Result");
            }
        }

        public async Task<int> GetCountOrId<P>(string storedProcedure, P parameters, string connectionId = "default")
        {
            IDbConnection connection = new SqlConnection(AppSettings.Instance.ConnectString);

            int result = await connection.ExecuteScalarAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<int> GetCountOrIdQ<P>(string query, P parameters, string connectionId = "default")
        {
            IDbConnection connection = new SqlConnection(AppSettings.Instance.ConnectString);

            int result = await connection.ExecuteScalarAsync<int>(query, parameters);
            return result;
        }

        public async Task<decimal> GetCostQ<P>(string query, P parameters, string connectionId = "default")
        {
            IDbConnection connection = new SqlConnection(AppSettings.Instance.ConnectString);

            decimal result = await connection.ExecuteScalarAsync<decimal>(query, parameters);
            return result;
        }

        public async Task<string> GetText<P>(string storedProcedure, P parameters, string connectionId = "default")
        {
            IDbConnection connection = new SqlConnection(AppSettings.Instance.ConnectString);

            string result = (string)await connection.ExecuteScalarAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public string GetTextField<P>(string storedProcedure, P parameters, string connectionId = "default")
        {
            IDbConnection connection = new SqlConnection(AppSettings.Instance.ConnectString);

            string result = (string)connection.ExecuteScalar(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

    }
}
