﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rankPanel;
    public Image rankimg;
    public Text rankNumTxt;
    public Text userName;
    public Text cupCountTxt;
    public Text countDownTxt;

    private int countDownValue;
    private float freshSpeed = 0;
    void Start()
    {
        rankPanel.SetActive(false);
        StreamReader streamReader = new StreamReader(Application.dataPath + "/Data/ranklist.json");
        string str = streamReader.ReadToEnd();
        var simpleJson = JSON.Parse(str);
        // Debug.Log("json数据" + simpleJson["list"][0]["uid"]);
        DataManager.CreateInstance().JsonNode = simpleJson["list"];
        countDownValue = simpleJson["countDown"];

    }

    public void OnOpenRank()
    {

        JSONNode jsonNode = DataManager.CreateInstance().JsonNode;
        JSONNode newData = new JSONArray();
        for (int i = 0; i < jsonNode.Count; i++)
        {   
            if (jsonNode[i]["uid"] == DataManager.CreateInstance().mySelfId)
            {
                if (i < 3)
                {
                    rankimg.gameObject.SetActive(true);
                    rankNumTxt.gameObject.SetActive(false);
                    rankimg.sprite = Resources.Load("ranking/rank_" + (i + 1) , typeof(Sprite)) as Sprite;
                    rankimg.rectTransform.sizeDelta = new Vector2(rankimg.sprite.rect.width,rankimg.sprite.rect.height);
                }
                else
                {
                    rankimg.gameObject.SetActive(false);
                    rankNumTxt.gameObject.SetActive(true);
                    rankNumTxt.text = i + 1 + "";
                }
                userName.text = jsonNode[i]["nickName"];
                cupCountTxt.text = jsonNode[i]["trophy"];
            }
            
        }

        // DataManager.CreateInstance().JsonNode = newData;
        

        rankPanel.SetActive(true);
    }

    public void onHideRank()
    {
        rankPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        freshSpeed += Time.deltaTime;
        if (freshSpeed >= 1.0f)
        {
            freshSpeed = 0;
            countDownValue--;
            this.countDownTxt.text = "Ends in:" + countDownValue + "秒";
        }
    }
}