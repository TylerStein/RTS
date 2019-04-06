using DBLite;
using System.Collections.Generic;

namespace DBLite {
    public class DBLite
    {
        public string DBName {
            get {
                return _dbName;
            }
        }


        private string _dbName;
        private Dictionary<string, DBLiteTable> _tables;

        public DBLite(string DatabaseName, string[] Tables) {
            _dbName = DatabaseName;
            _tables = new Dictionary<string, DBLiteTable>();
            foreach (string tableName in Tables) {
                _tables.Add(tableName, new DBLiteTable(tableName));
            }
        }

        public DBLite(string DatabaseName) {
            _dbName = DatabaseName;
            _tables = new Dictionary<string, DBLiteTable>();
        }

        public DBLiteTable GetTable(string tableName) {
            return _tables[tableName];
        }

        public void AddTable(string tableName) {
            _tables.Add(tableName, new DBLiteTable(tableName));
        }

        public void TryGetFromTable<T>(string table, object property, ref T value) {
            if (_tables.ContainsKey(table)) {
                _tables[table].TryGetValue(property, ref value);
            }
        }

        public T GetFromTableSafe<T>(string table, object property) {
            return _tables[table].GetValueSafe<T>(property);
        }

        public bool AddToTableSafe<T>(string table, object property, T value) {
            return _tables[table].AddValueSafe(property, value);
        }

        public void UpsertToTable<T>(string table, object property, T value) {
            _tables[table].UpsertValue(property, value);
        }
    }
}