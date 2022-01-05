using System;
using System.Collections.Generic;
using System.IO;
using Entity;
using Model;
using SimpleJSON;
using UnityEngine;
using Utils;
using View;
using EventType = Entity.EventType;

namespace Controller
{
    public class RankController : MonoBehaviour
    {
        [SerializeField] private RankView view;

        public static RankController Singleton;

        public void Awake()
        {
            Singleton = this;
            EventCenter.AddListener<string>(EventType.ShowToast, ShowToast);
            ReadJsonData();
        }

        private void ReadJsonData()
        {
            string jsonPath = $"{Application.dataPath}/Data/ranklist.json";
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

            list.Sort((a, b) => Convert.ToInt32(b.Trophy) - Convert.ToInt32(a.Trophy));

            RankModel.CreateInstance().JsonList = list;
            RankModel.CreateInstance().CountDownValue = simpleJson["countDown"];
        }

        public void OpenRank()
        {
            view.OpenRankPanel();
        }

        /**
         * 提示框
         */
        private void ShowToast(string toastTxt)
        {
            view.ShowToast(toastTxt);
        }
    }
}