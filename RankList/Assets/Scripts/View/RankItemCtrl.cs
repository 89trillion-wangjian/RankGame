﻿using UnityEngine;
using UnityEngine.Serialization;

namespace View
{
    public class RankItemCtrl : MonoBehaviour
    {
        public RankItemCtrl rankItemCtrl;
        // Start is called before the first frame update
        public static RankItemCtrl Singleton;

        public void Awake()
        {
            Singleton = rankItemCtrl;
        }

        private MyListItemModel _itemData;
        [FormerlySerializedAs("toastCtrl")] public ToastView toastView;

        public void OnBtnClick()
        {
            toastView.ShowText("User: " + _itemData.NickName + "    Rank: " + _itemData.Ranking);
        }

        public void SetData(MyListItemModel model)
        {
            this._itemData = model;
        }

        // Update is called once per frame
    }
}