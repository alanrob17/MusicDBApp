using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDAL.Data
{
    public interface IDataAccess
    {
        Task<IEnumerable<T>> GetData<T, P>(string storedProcedure, P parameters, string connectionId = "default");
        IEnumerable<T> GetBrowseData<T, P>(string storedProcedure, P parameters, string connectionId = "default");
        Task<T> GetDataFirstOrDefault<T, P>(string storedProcedure, P parameters, string connectionId = "default");
        T GetFirstOrDefault<T, P>(string storedProcedure, P parameters, string connectionId = "default");
        Task SaveData<P>(string storedProcedure, P parameters, string connectionId = "default");
        Task<int> SaveDataReturnId(string storedProcedure, DynamicParameters parameters, string connectionId = "default");
        Task<int> GetCountOrId<P>(string storedProcedure, P parameters, string connectionId = "default");
        Task<int> GetCountOrIdQ<P>(string query, P parameters, string connectionId = "default");
        Task<decimal> GetCostQ<P>(string query, P parameters, string connectionId = "default");
        Task<string> GetText<P>(string storedProcedure, P parameters, string connectionId = "default");
        string GetTextField<P>(string storedProcedure, P parameters, string connectionId = "default");
    }
}
