using Game.Scripts.Helpers;
using Game.Scripts.MonoBehavior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game.Scripts.Monetization
{
    class TimedBonusManager
    {
        private DateTime bonusStartTime;
        private DateTime bonusEndTime;

        private bool timeStarted = false;
        private string formattedTime = "";

        private bool readyToCollect = false;

        private static TimedBonusManager instance;

        public static TimedBonusManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TimedBonusManager();
                }
                return instance;
            }
        }

        public TimedBonusManager()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public bool ReadyToCollect
        {
            get { return readyToCollect; }
        }

        public void InitializeNextTimedBonus()
        {
            readyToCollect = false;
            var playerPrefHelper = PlayerPrefHelper.Instance;

            if ( playerPrefHelper != null && !playerPrefHelper.HasTimedBonus() )
            {                
                bonusStartTime = DateTime.Now;
                bonusEndTime = bonusStartTime.AddMinutes((double)Constants.Game.NEXT_TIMED_BONUS);
                playerPrefHelper.SetNextTimedBonus(bonusEndTime.ToString());
            }
            else
            {
                if (playerPrefHelper != null )
                {
                    bonusEndTime = Convert.ToDateTime(playerPrefHelper.GetTimedBonusEndTime());
                }                
            }

            Core.Instance.FrameUpdate += Update;
        }

        public void SetNextTimeBonus()
        {
            readyToCollect = false;

            var playerPrefHelper = PlayerPrefHelper.Instance;

            bonusStartTime = DateTime.Now;
            bonusEndTime = bonusStartTime.AddMinutes((double)Constants.Game.NEXT_TIMED_BONUS);

            if (playerPrefHelper != null )
            {
                playerPrefHelper.SetNextTimedBonus(bonusEndTime.ToString());
            }

            Core.Instance.FrameUpdate += Update;
        }

        public void ResumeTimedBonus(string time)
        {
            bonusEndTime = Convert.ToDateTime(time);
        }

        public void Update(float deltaTime)
        {
            DateTime now = DateTime.Now;

            if (now >= bonusEndTime)
            {
                readyToCollect = true;
                Core.Instance.FrameUpdate -= Update;
                return;
            }

            TimeSpan currentTime = bonusEndTime.Subtract(now);
            formattedTime = String.Format("{0:0}:{1:00}", currentTime.Minutes, currentTime.Seconds);

            return;
        }

        public string GetFormattedTime()
        {
            if( readyToCollect )
            {
                formattedTime = "COLLECT!";
            }

            return formattedTime;
        }
    }
}
