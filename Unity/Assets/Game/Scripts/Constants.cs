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
            public enum GameType { JACKS_OR_BETTER }

            public static GameType gameType = GameType.JACKS_OR_BETTER;

            public const int TIMED_BONUS_AMOUNT = 15;
            public const int VIDEO_AD_BONUS_AMOUNT = 25;
            public const int PARTIAL_VIDEO_AD_AMOUNT = 5;
            public const int STARTING_GAME_CREDITS = 150;

            public const float NEXT_TIMED_BONUS = 15.0f;    //Minutes

            public const string PLAYER_CREDITS = "playerCredits";
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
            public const string CARD_FLIP = "CARD_FLIP";
            public const string CARD_DRAW = "CARD_DRAW";
            public const string HOLD_BUTTON = "HOLD_BUTTON";
            public const string WINNINGS_COUNT = "WINNINGS_COUNT";
            public const string WIN_1 = "WIN_1";
            public const string HAND_NOTIFICATION = "HAND_NOTIFICATION";
            public const string POKER_CHIP_1 = "POKER_CHIP_1";
            public const string POKER_CHIP_9 = "POKER_CHIP_9";
        }
    }
}

