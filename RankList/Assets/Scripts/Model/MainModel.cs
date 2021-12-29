using System.Collections.Generic;

namespace Model
{
    public class MainModel
    {
        private static MainModel _singleton; 
        
        public int CountDownValue { get; set; } 
        
        public List<JsonModel> JsonList;

        public static MainModel CreateInstance()
        {
            return _singleton ?? (_singleton = new MainModel());
        }

    }
}