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
        public MainView view;

        private int _countDownValue;
        void Awake()
        {
            ReadJson();
        }
        
        public void ReadJson()
        {
            StreamReader streamReader = new StreamReader(string.Concat(Application.dataPath, "/Data/ranklist.json"));
            string str = streamReader.ReadToEnd();
            var simpleJson = JSON.Parse(str);
            List<JsonModel> list = new List<JsonModel>();
            for (int i = 0; i < simpleJson["list"].Count; i++)
            {
                JsonModel jsonModel = new JsonModel(simpleJson["list"][i]["uid"], simpleJson["list"][i]["nickName"],
                    simpleJson["list"][i]["avatar"],
                    simpleJson["list"][i]["trophy"]
                );
                list.Add(jsonModel);
            }

            list.Sort((a, b) => { return Convert.ToInt32(b.trophy) - Convert.ToInt32(a.trophy); });

            MainModel.CreateInstance().JsonList = list;
            MainModel.CreateInstance().CountDownValue = simpleJson["countDown"];
        }


        public void RenderRankInfo()
        {
            List<JsonModel> json = MainModel.CreateInstance().JsonList;
            for (int i = 0; i < json.Count; i++)
            {
                if (json[i].id == DataManager.CreateInstance().mySelfId)
                {
                    if (i < 3)
                    {
                        view.OnChangeRankStatus(true, json);
                    }
                    else
                    {
                        view.OnChangeRankStatus(false, json);
                    }

                }
            }
            
            StopCoroutine("StartCutDown");
            StartCoroutine("StartCutDown");
        }
        
        IEnumerator StartCutDown()
        {
            while (_countDownValue > 0)
            {
                _countDownValue--;
                view.UpdateCountDownTxt(_countDownValue);
                yield return new WaitForSeconds(1.0f);
            }
        }

        public int GetCountDownValue()
        {
            return MainModel.CreateInstance().CountDownValue;
        }
    }
}
