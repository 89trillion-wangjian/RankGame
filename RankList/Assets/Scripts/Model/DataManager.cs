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

        public static DataManager CreateInstance()
        {
            if (_singleton == null)
            {
                _singleton = new DataManager();
            }

            return _singleton;
        }

        public List<JsonModel> JsonList;

        public JSONNode JsonNode { set; get; }
    }
}