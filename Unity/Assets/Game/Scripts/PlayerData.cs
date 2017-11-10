using Game.Scripts.Helpers;
using System;
using UnityEngine;

namespace Game.Scripts
{
    class PlayerData
    {
        private string token = "";
        private string playerId = "";
        private Guid secret;
        private int credits = Constants.Game.STARTING_GAME_CREDITS;

        private static PlayerData instance;

        public static PlayerData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerData();
                }
                return instance;
            }
        }

        public PlayerData()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public void Initialize()
        {
            var playerPrefHelper = PlayerPrefHelper.Instance;

            if (playerPrefHelper == null )
            {
                Debug.LogError("PlayerData::Initialize - Unable to get PlayerPrefHelper instance.  NULL returned.");
                return;
            }

            if (playerPrefHelper.HasKey( Constants.Game.PLAYER_CREDITS ))
            {
                credits = playerPrefHelper.GetInt( Constants.Game.PLAYER_CREDITS );
            }
            else
            {
                credits = Constants.Game.STARTING_GAME_CREDITS;
                playerPrefHelper.SetInt( Constants.Game.PLAYER_CREDITS, credits );
            }
        }

        public string Token { get; set; }

        public string PlayerId { get; set; }

        public Guid Secret { get; set; }

        public int Credits { 
            get 
            {
                var playerPrefHelper = PlayerPrefHelper.Instance;

                if (playerPrefHelper == null)
                {
                    Debug.LogError("PlayerData::Credits Property - Unable to get PlayerPrefHelper instance.  NULL returned.");
                    return 0;
                }

                return playerPrefHelper.GetInt(Constants.Game.PLAYER_CREDITS); 
            } 
            set { credits = value; } }
    }
}
