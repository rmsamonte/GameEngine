using UnityEngine;
using System.Collections;

namespace Game.Scripts
{
    public class Constants
    {
        public class Layers
        {
            public const string LAYERS = "Layers";
            public const string GAME = "Game";
            public const string WINDOW = "Window";
            public const string HUD = "HUD";
            public const string POPUP = "Popup";
            public const string BLACKSCREEN = "Blackscreen";
        }

        public class ScreenManager
        {
            public const float FADE_IN_TIME = 1.0f;
            public const float FADE_OUT_TIME = 1.0f;
        }

        public class Game
        {
            public const float NEXT_TIMED_BONUS = 15.0f;    //Minutes
        }

        public class Server
        {
            public const string BASE_URL = "http://www.kahunastudios.com/GameEngine/";
        }

        public class GamePrefs
        {
            public const string PLAYER_ID_KEY = "playerId";
            public const string SECRET_KEY = "secret";
            public const string TOKEN_KEY = "tokenKey";
            public const string TIMED_BONUS_KEY = "timedBonusKey";

            public const string SOUND_FX_KEY = "soundFx";
            public const string MUSIC_KEY = "music";
        }

        public class GameSounds
        {
            //The following variables corresponds to the events defined in the AudioManager prefab's "Event Manager" script
            public const string UI_GENERIC_BUTTON_PRESSED = "GENERIC_BUTTON_PRESSED";
        }
    }
}

