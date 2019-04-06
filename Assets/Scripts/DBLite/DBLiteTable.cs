using System.Collections;
using Unity;
using DBLite;

namespace DBLite {
    public class DBLiteTable {
        public string TableName {
            get {
                return _tableName;
            }
        }

        private string _tableName;
        private int _valueCount;
        private object[] _values;
        private Hashtable _table;

        public DBLiteTable(string tableName) {
            _tableName = tableName;
            _table = new Hashtable();
        }

        public bool TryGetValue<T>(object property, ref T value) {
            try {
                value = (T)_table[property];
            } catch (System.Exception exception) {
                UnityEngine.Debug.LogError(exception.Message);
                return false;
            }

            return true;
        }

        public T GetValue<T>(object property) {
            return (T)_table[property];
        }

        public T GetValueSafe<T>(object property) {
            if (_table.ContainsKey(property)) return (T)_table[property];
            return (T)new object();
        }

        public void AddValue<T>(object property, T value) {
            _table.Add(property, value);
        }

        public bool AddValueSafe<T>(object property, T value) {
            if (_table.ContainsKey(property)) return false;
            _table.Add(property, value);
            return true;
        }

        public void SetValue<T>(object property, T value) {
            _table[property] = value;
        }

        public bool SetValueSafe<T>(object property, T value) {
            if (_table.ContainsKey(property)) {
                _table[property] = value;
                return true;
            }
            return false;
        }

        public void UpsertValue<T>(object property, T value) {
            if (_table.ContainsKey(property)) _table[property] = value;
            _table.Add(property, value);
        }

        public bool HasProperty(object property) {
            return _table.ContainsKey(property);
        }

        public bool HasValue<T>(T value) {
            return _table.ContainsValue(value);
        }

        public bool RemoveSafe(object property) {
            if (_table.ContainsKey(property)) {
                _table.Remove(property);
                return true;
            }
            return false;
        }

        public void Remove(object property) {
            _table.Remove(property);
        }
    }
}