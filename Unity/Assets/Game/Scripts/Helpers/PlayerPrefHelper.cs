using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game.Scripts.Helpers
{
    class PlayerPrefHelper
    {
        private static PlayerPrefHelper instance;

        public static PlayerPrefHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerPrefHelper();
                }
                return instance;
            }
        }

        public PlayerPrefHelper()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        public bool HasTimedBonus()
        {
            return PlayerPrefs.HasKey(Constants.GamePrefs.TIMED_BONUS_KEY);
        }

        public void SetMusicPreference(int value)
        {
            PlayerPrefs.SetInt(Constants.GamePrefs.MUSIC_KEY, value);
        }

        public void SetSoundFXPreference(int value)
        {
            PlayerPrefs.SetInt(Constants.GamePrefs.SOUND_FX_KEY, value);
        }

        public void SetNextTimedBonus(string time)
        {

            PlayerPrefs.SetString(Constants.GamePrefs.TIMED_BONUS_KEY, time);
        }

        public string GetTimedBonusEndTime()
        {
            return PlayerPrefs.GetString(Constants.GamePrefs.TIMED_BONUS_KEY);
        }

        public bool GetMusicPreference()
        {
            bool status = PlayerPrefs.GetInt(Constants.GamePrefs.MUSIC_KEY) != 0 ? true : false;
            
            return status;
        }

        public bool GetSoundFXPreference()
        {
            bool status = PlayerPrefs.GetInt(Constants.GamePrefs.SOUND_FX_KEY) != 0 ? true : false;

            return status;
        }

        public int GetInt(string key)
        {
            if( HasKey( key ) )
            {
                return PlayerPrefs.GetInt(key);
            }

            return 0;
        }

        public void SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }
    }
}
