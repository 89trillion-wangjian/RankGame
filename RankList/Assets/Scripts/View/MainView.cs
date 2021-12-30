using UnityEngine;
using Utils;
using EventType = Model.EventType;

namespace View
{
    public class MainView : MonoBehaviour
    {
        [SerializeField] private GameObject rankPanelItem;

        [SerializeField] private ToastView toast;

        public void Awake()
        {
            EventCenter.AddListener<string>(EventType.ShowToast, ShowToast);
        }

        public void OpenRank()
        {
            Instantiate(rankPanelItem, this.transform, false);
        }
        
        /**
         * 提示框
         */
        private void ShowToast(string toastTxt)
        {
            toast.ShowText(toastTxt);
        }
    }
}