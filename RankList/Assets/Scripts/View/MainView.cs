using System;
using System.Collections.Generic;
using Controller;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class MainView : MonoBehaviour
    {
        [SerializeField] private GameObject rankPanel;

        [SerializeField] private Image rankimg;

        [SerializeField] private Text rankNumTxt;

        [SerializeField] private Text userName;

        [SerializeField] private Text cupCountTxt;

        [SerializeField] private Text countDownTxt;

        [SerializeField] private MainController mainCtrl;

        public void OpenRank()
        {
            mainCtrl.RenderRankInfo();
            rankPanel.SetActive(true);
        }

        /// <summary>
        /// 更新排名状态/图等
        /// </summary>
        /// <param name="isTopThree">是否是前三名</param>
        /// <param name="json">玩家数据</param>
        /// <param name="ranking">排名</param>
        public void ChangeRankStatus(bool isTopThree, List<JsonModel> json, int ranking = 0)
        {
            rankimg.gameObject.SetActive(isTopThree);
            rankNumTxt.gameObject.SetActive(!isTopThree);
            if (isTopThree)
            {
                rankimg.sprite =
                    Resources.Load(string.Concat("ranking/rank_", (ranking + 1)), typeof(Sprite)) as Sprite;
                if (rankimg.sprite != null)
                    rankimg.rectTransform.sizeDelta =
                        new Vector2(rankimg.sprite.rect.width, rankimg.sprite.rect.height);
            }

            if (!isTopThree)
            {
                rankNumTxt.text = ranking + 1 + "";
            }

            userName.text = json[ranking].nickName;
            cupCountTxt.text = json[ranking].trophy;
        }

        /// <summary>
        /// 更新倒计时
        /// </summary>
        /// <param name="value"></param>
        public void UpdateCountDownTxt(int value)
        {
            this.countDownTxt.text = string.Concat("Ends in:", FormatTime(value));
        }

        public void HideRank()
        {
            rankPanel.SetActive(false);
        }

        /// <summary>
        /// 格式化时间
        /// </summary>
        /// <param name="seconds">秒</param>
        /// <returns></returns>
        private static string FormatTime(float seconds)
        {
            TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(seconds));
            string str = "";

            if (ts.Hours > 0)
            {
                str = $"{ts.Hours:00}时{ts.Minutes:00}分{ts.Seconds:00}秒";
            }

            if (ts.Hours == 0 && ts.Minutes > 0)
            {
                str = $"{ts.Minutes:00}分{ts.Seconds:00}秒";
            }

            if (ts.Hours == 0 && ts.Minutes == 0)
            {
                str = $"00:00:{ts.Seconds:00}秒";
            }

            return str;
        }
    }
}