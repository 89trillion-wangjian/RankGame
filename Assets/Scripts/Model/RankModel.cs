using System.Collections.Generic;
using Entity;

namespace Model
{
    public class RankModel
    {
        private static RankModel singleton;

        public string MySelfId = "3716954261";

        public int CountDownValue { get; set; }

        public List<JsonModel> JsonList;

        public static RankModel CreateInstance()
        {
            return singleton ?? (singleton = new RankModel());
        }
    }
}