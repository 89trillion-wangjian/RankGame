using System.Collections.Generic;

namespace Model
{
    public class MainModel
    {
        private static MainModel singleton; 
        
        public int CountDownValue { get; set; } 
        
        public List<JsonModel> JsonList;

        public static MainModel CreateInstance()
        {
            return singleton ?? (singleton = new MainModel());
        }

    }
}