using Gaten.Net.Windows.Msq;

using MySql.Data.MySqlClient;

using System.Data;

namespace Gaten.Net.Network.MySql
{
    public class MySqlManager : IDisposable
    {
        private bool disposedValue;
        private MySqlConnection connection = default!;

        public List<MySqlTable> Tables { get; set; } = new List<MySqlTable>();

        public MySqlManager()
        {

        }

        public MySqlManager(string database, bool isSsl = false)
        {
            try
            {
                MySqlInfo.Initialize();

                Tables = new List<MySqlTable>();

                string connectionString =
                $"Server={MySqlInfo.ServerIp};" +
                $" Port={MySqlInfo.Port};" +
                $" Database={database};" +
                $" Uid={MySqlInfo.Id};" +
                $" Pwd={MySqlInfo.Password};" +
                $" SslMode={(isSsl ? "Required" : "None")};";

                connection = new MySqlConnection(connectionString);
                connection.Open();

                Initialize();
            }
            catch
            {
                throw;
            }
        }

        public MySqlManager(string serverIp, string port, string id, string password, string database, bool isSsl = false)
        {
            try
            {
                Tables = new List<MySqlTable>();

                string connectionString =
                $"Server={serverIp};" +
                $" Port={port};" +
                $" Database={database};" +
                $" Uid={id};" +
                $" Pwd={password};" +
                $" SslMode={(isSsl ? "Required" : "None")};";

                connection = new MySqlConnection(connectionString);
                connection.Open();

                Initialize();
            }
            catch
            {
                throw;
            }
        }

        void Initialize()
        {
            GetTableInfo();
        }

        void GetTableInfo()
        {
            var schema = connection.GetSchema("Tables");
            foreach (DataRow row in schema.Rows)
            {
                string tableName = row[2].ToString() ?? string.Empty;
                var columnNames = new List<string>();

                using (MySqlDataReader reader = new MySqlCommand("SELECT * FROM " + tableName, connection).ExecuteReader(CommandBehavior.SchemaOnly))
                {
                    var schemaTable = reader.GetSchemaTable();

                    foreach (DataRow tableRow in schemaTable.Rows)
                    {
                        string columnName = tableRow[0].ToString() ?? string.Empty;
                        columnNames.Add(columnName);
                    }
                }

                Tables.Add(new MySqlTable(tableName, columnNames));
            }
        }

        public bool Insert(string tableName, params string[] data)
        {
            string dataString = "'" + string.Join("','", data) + "'";
            string queryString = $"INSERT INTO {GetTable(tableName).InsertString} VALUES({dataString})";

            return new MySqlCommand(queryString, connection).ExecuteNonQuery() == 1;
        }

        public string Insert(string tableName, Dictionary<string, string> data)
        {
            string keyString = string.Join(',', data.Keys);
            string valueString = string.Join(',', data.Values);

            string commandString = $"INSERT INTO {tableName}({keyString}) VALUES({valueString})";

            string str = string.Empty;

            try
            {
                MySqlCommand command = new MySqlCommand(commandString, connection);

                if (command.ExecuteNonQuery() == 1)
                {
                    return string.Empty;
                }
                else
                {
                    return "Fail Insert.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool Delete(string tableName, string whereColumn, string whereValue)
        {
            string queryString = $"DELETE FROM {tableName} WHERE {whereColumn} = '{whereValue}'";

            return new MySqlCommand(queryString, connection).ExecuteNonQuery() == 1;
        }

        public bool Update(string tableName, string setColumn, string setValue, string whereColumn, string whereValue)
        {
            string queryString = $"UPDATE {tableName} SET {setColumn} = '{setValue}' WHERE {whereColumn} = '{whereValue}'";

            return new MySqlCommand(queryString, connection).ExecuteNonQuery() == 1;
        }

        public DataTable SelectTable(string tableName)
        {
            DataTable dataTable = new DataTable();

            string queryString = $"SELECT * FROM {tableName}";
            using (MySqlDataReader reader = new MySqlCommand(queryString, connection).ExecuteReader())
            {
                dataTable.Load(reader);
            }

            return dataTable;
        }

        public DataTable Select(string queryString)
        {
            DataTable dataTable = new DataTable();

            using (MySqlDataReader reader = new MySqlCommand(queryString, connection).ExecuteReader())
            {
                dataTable.Load(reader);
            }

            return dataTable;
        }

        public List<Dictionary<string, string>> SelectByTableName(string tableName, string additional = "")
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

            //string commandString =
            //    $"SELECT {(string.IsNullOrEmpty(fieldNameString) ? "*" : fieldNameString)}" +
            //    $" FROM {tableName}" +
            //    $"{(string.IsNullOrEmpty(whereString) ? "" : " WHERE" + whereString)}" +
            //    $"{(string.IsNullOrEmpty(orderByString) ? "" : " ORDER BY" + orderByString)}";

            string queryString = $"SELECT * FROM {tableName} {additional}";

            string str = string.Empty;

            try
            {
                using (MySqlDataReader reader = new MySqlCommand(queryString, connection).ExecuteReader())
                {
                    var columns = new List<string>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columns.Add(reader.GetName(i));
                    }

                    while (reader.Read())
                    {
                        Dictionary<string, string> row = new Dictionary<string, string>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row.Add(columns[i], reader.GetString(i));
                        }
                        result.Add(row);
                    }
                }

                return result;
            }
            catch
            {
                throw;
            }
        }

        MySqlTable GetTable(string name)
        {
            return Tables.Find(t => t.Name.Equals(name)) ?? default!;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                disposedValue = true;
                connection.Close();
            }
        }

        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
