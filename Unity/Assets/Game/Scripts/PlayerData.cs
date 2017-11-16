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

            if (playerPrefHelper == null)
            {
                Debug.LogError("PlayerData::Initialize - Unable to get PlayerPrefHelper instance.  NULL returned.");
                return;
            }
        }

        public string Token { get; set; }

        public string PlayerId { get; set; }

        public Guid Secret { get; set; }
    }
}
