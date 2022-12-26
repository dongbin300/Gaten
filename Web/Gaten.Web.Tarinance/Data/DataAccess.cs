using Dapper;

using Gaten.Net.Collections;
using Gaten.Net.Windows.Msq;

using MySql.Data.MySqlClient;

using System.Data;
using System.Reflection;

namespace Gaten.Web.Tarinance.Data
{
    public class DataAccess
    {
        public string ConnectionString = string.Empty;

        public void Initialize()
        {
            MySqlInfo.Initialize();

            ConnectionString =
             $"Server={MySqlInfo.ServerIp};" +
             $" Port={MySqlInfo.Port};" +
             $" Database=TARINANCE;" +
             $" Uid={MySqlInfo.Id};" +
             $" Pwd={MySqlInfo.Password};";
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            var rows = await connection.QueryAsync<T>(sql, parameters);

            return rows.ToList();
        }

        public Task SaveData<T>(string sql, T parameters)
        {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            return connection.ExecuteAsync(sql, parameters);
        }

        public async Task<List<string>> GetColumnName(string tableName)
        {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            var sql = $"describe {tableName}";
            var data = await connection.QueryAsync(sql);

            List<string> result = new List<string>();
            foreach (IDictionary<string, object> row in data)
            {
                result.Add(row.Values.ElementAt(0).ToString() ?? "");
            }

            return result;
        }

        public async Task<List<T>> Select<T>(string tableName)
        {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            var sql = $"select * from {tableName}";
            var rows = await connection.QueryAsync<T>(sql);

            return rows.ToList();
        }

        public Task Insert<T>(string tableName, T data)
        {
            var match = new Match();
            var columnNames = GetColumnName(tableName);
            match.SetKey(columnNames.Result.ToArray());

            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetField);
            var fieldNames = fields.Select(x => x.Name.Replace("k__BackingField", "").Replace("<", "").Replace(">", "")).ToList();
            foreach(var fieldName in fieldNames)
            {
                var value = typeof(T).GetProperty(fieldName)?.GetValue(data, null);
                match.SetValue(fieldName, value);
            }
            
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            var sql = $"insert into {tableName}({match.GetSerializedSampleKey()}) values({match.GetQuotedValue()})";
            return connection.ExecuteAsync(sql);
        }

        public Task Update(string tableName, string whereColumnName, string whereValue, string setColumnName, string setValue)
        {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            var sql = $"UPDATE {tableName} SET {setColumnName} = '{setValue}' WHERE {whereColumnName} = '{whereValue}'";
            return connection.ExecuteAsync(sql);
        }
    }
}
