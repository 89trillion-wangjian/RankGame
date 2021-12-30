using System;
using System.Collections.Generic;
using System.IO;
using Model;
using SimpleJSON;
using UnityEngine;
using View;

namespace Controller
{
    public class MainController : MonoBehaviour
    {
        public MainView mainView;

        private int countDownValue = 0;

        public static MainController Singleton;

        void Awake()
        {
            ReadJson();
            Singleton = this;
        }

        /// <summary>
        /// 读取json
        /// </summary>
        public void ReadJson()
        {
            string jsonPath = string.Concat(Application.dataPath, "/Data/ranklist.json");
            string str = new StreamReader(jsonPath).ReadToEnd();
            var simpleJson = JSON.Parse(str);
            var list = new List<JsonModel>();
            for (int i = 0; i < simpleJson["list"].Count; i++)
            {
                var jsonModel = new JsonModel(simpleJson["list"][i]["uid"], simpleJson["list"][i]["nickName"],
                    simpleJson["list"][i]["avatar"],
                    simpleJson["list"][i]["trophy"]
                );
                list.Add(jsonModel);
            }

            list.Sort((a, b) => Convert.ToInt32(b.trophy) - Convert.ToInt32(a.trophy));

            MainModel.CreateInstance().JsonList = list;
            MainModel.CreateInstance().CountDownValue = simpleJson["countDown"];
            countDownValue = simpleJson["countDown"];
        }

        public int GetCountDown()
        {
            return countDownValue;
        }
    }
}