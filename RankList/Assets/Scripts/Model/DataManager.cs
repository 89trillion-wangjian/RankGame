using System.Collections.Generic;
using SimpleJSON;

namespace Model
{
    public class DataManager
    {
        private DataManager()
        {
        }

        private static DataManager _singleton;

        public string mySelfId = "3716954261";

        public List<JsonModel> JsonList;

        public JSONNode JsonNode { set; get; }

        public static DataManager CreateInstance()
        {
            return _singleton ?? (_singleton = new DataManager());
        }
    }
}