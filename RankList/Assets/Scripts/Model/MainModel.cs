using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using UnityEngine;

namespace Model
{
    public class MainModel
    {
        private static MainModel _singleton;

        public static MainModel CreateInstance()
        {
            if (_singleton == null)
            {
                _singleton = new MainModel();
            }

            return _singleton;
        }

        public int CountDownValue { get; set; }
        public List<JsonModel> JsonList;
    }
}