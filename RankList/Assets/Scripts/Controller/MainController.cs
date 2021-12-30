using System;
using System.Collections;
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
        
        void Awake()
        {
            ReadJson();
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


        public void RenderRankInfo()
        {
            var json = MainModel.CreateInstance().JsonList;
            for (int i = 0; i < json.Count; i++)
            {
                if (json[i].id == DataManager.CreateInstance().MySelfId)
                {
                    mainView.ChangeRankStatus(i < 3, json);
                }
            }
            
            StopCoroutine(nameof(StartCutDown));
            StartCoroutine(nameof(StartCutDown));
        }

        private IEnumerator StartCutDown()
        {
            while (countDownValue > 0)
            {
                countDownValue--;
                mainView.UpdateCountDownTxt(countDownValue);
                yield return new WaitForSeconds(1.0f);
            }
        }

        public int GetCountDownValue()
        {
            return MainModel.CreateInstance().CountDownValue;
        }
    }
}
