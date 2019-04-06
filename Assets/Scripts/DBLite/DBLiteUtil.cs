using DBLite;

namespace DBLite {
    [System.Serializable]
    public enum DBLiteOperator { EQ, LT, GT, LTE, GTE, NE }

    [System.Serializable]
    public class DBLiteQuery {
        public string property;
        public DBLiteOperator op = DBLiteOperator.EQ;
        public object value;
    }
}