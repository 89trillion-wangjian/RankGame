using UnityEngine;

namespace View
{
    public class RankItemCtrl : MonoBehaviour
    {
        public RankItemCtrl rankItemCtrl;

        public static RankItemCtrl Singleton;

        public ToastView toastView;

        private MyListItemModel itemData;

        public void Awake()
        {
            Singleton = rankItemCtrl;
        }


        public void ShowText()
        {
            toastView.ShowText("User: " + itemData.NickName + "    Rank: " + itemData.Ranking);
        }

        public void SetData(MyListItemModel model)
        {
            this.itemData = model;
        }
    }
}