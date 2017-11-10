using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Timers;
using Game.Scripts.Helpers;
using Game.Scripts.UI.Widgets;

namespace Game.Scripts.UI.Screens
{
    public class TitleScreen : BaseScreen
    {
        public const string PREFAB_PATH = "Data/UI/Prefabs/TitleScreen/ui_title_screen";

        private const string UI_PLAY_BUTTON = "play_button";
        private const string UI_TEST_ADS_BUTTON = "ad_test_button";
        private const string UI_DEBUG_TEXT = "debug_text";
        private const string UI_SOUND_BUTTON = "Sound Icon";

        private bool transitioning = false;

        private Text debugText;
        private ToggleButton soundIcon;

        public TitleScreen() : base ( PREFAB_PATH )
        {
            
        }

        public override string ScreenName
        {
            get { return "TestScreen"; }
        }

        public override string Layer
        {
            get { return Constants.Layers.WINDOW; }
        }

        public override void OnLoaded()
        {
            base.OnLoaded();

            var screenManager = Service.Get<ScreenManager>();
            if (screenManager != null)
            {
                screenManager.FadeOut(null);
            }            

            Button buttonScript;

            var playButton = UnityUtils.FindChildByName( root, UI_PLAY_BUTTON );

            if (playButton != null)
            {
                buttonScript = playButton.GetComponent<Button>();

                if (buttonScript != null)
                {
                    buttonScript.onClick.AddListener(OnPlayPressed);
                }                
            }            

            var soundButton = UnityUtils.FindChildByName(root, UI_SOUND_BUTTON);

            if (soundButton != null)
            {
                var playerPrefHelper = PlayerPrefHelper.Instance;

                soundIcon = new ToggleButton(soundButton);
                soundIcon.Toggle(playerPrefHelper.GetSoundFXPreference());

                soundIcon.Intialize(OnSoundIconPressed, "HOLD_BUTTON");
            }

            var debugTextObj = GetElement(UI_DEBUG_TEXT);
            debugText = debugTextObj.GetComponent<Text>();
            debugText.text = String.Empty;
        }

        public override void Close(object modalResult)
        {
            if( (bool)modalResult == false )
            {
                return;
            }

            base.Close(modalResult);

            var gameScreen = new GameScreen();
            
            var screenManager = Service.Get<ScreenManager>();
            if (screenManager != null)
            {
                screenManager.AddScreen(gameScreen);
            }
        }

        private void OnSoundIconPressed()
        {
            soundIcon.Toggled = !soundIcon.Toggled;

            var playerPrefHelper = PlayerPrefHelper.Instance;

            playerPrefHelper.SetSoundFXPreference(soundIcon.Toggled == true ? 1 : 0);
        }

        private void OnPlayPressed()
        {
            if (transitioning)
            {
                return;
            }            

            var playerPrefHelper = PlayerPrefHelper.Instance;
            var playerData = PlayerData.Instance;

            ScreenAnimator.Play("hide");
            transitioning = true;
            var screenManager = Service.Get<ScreenManager>();
            if (screenManager != null)
            {
                screenManager.FadeIn(() =>
                {
                    Close(true);
                });
            }            
        }

        public void SetDebugText(string msg)
        {
            debugText.text = msg;
        }
    }
}

