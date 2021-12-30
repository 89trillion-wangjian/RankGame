using UnityEngine;
using Utils;
using EventType = Model.EventType;

namespace View
{
    public class RankItemCtrl : MonoBehaviour
    {

        public static RankItemCtrl Singleton;

        public ToastView toastView;

        private MyListItemModel itemData;

        public void Awake()
        {
            Singleton = this;
        }


        public void ShowText()
        {
            EventCenter.PostEvent(EventType.ShowToast, $"user: {itemData.NickName}   Rank: {itemData.Ranking}");
        }

        public void SetData(MyListItemModel model)
        {
            this.itemData = model;
        }
    }
}