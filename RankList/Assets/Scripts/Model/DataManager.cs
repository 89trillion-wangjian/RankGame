using System.Collections.Generic;
using SimpleJSON;

namespace Model
{
    public class DataManager
    {

        private static DataManager singleton;

        public string MySelfId = "3716954261";

        public List<JsonModel> JsonList;

        public JSONNode JsonNode { set; get; }
        private DataManager()
        {
        }

        public static DataManager CreateInstance()
        {
            return singleton ?? (singleton = new DataManager());
        }
    }
}