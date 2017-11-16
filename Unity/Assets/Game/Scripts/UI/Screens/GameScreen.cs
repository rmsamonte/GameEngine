﻿using Game.Scripts.Backend.Services;
using Game.Scripts.MonoBehavior;
using Game.Scripts.Backend.Model;
using System.Collections.Generic;

namespace Game.Scripts.UI.Screens
{
    public class GameScreen : BaseScreen
    {
        public const string PREFAB_PATH = "Data/UI/Prefabs/GameScreen/ui_game_screen";        

        public GameScreen()
            : base(PREFAB_PATH)
        {
        }

        public override string ScreenName
        {
            get { return "GameScreen"; }
        }

        public override string Layer
        {
            get { return Constants.Layers.GAME; }
        }

        public override void OnLoaded()
        {
            base.OnLoaded();

            var screenManager = Service.Get<ScreenManager>();
            if (screenManager != null)
            {
                screenManager.FadeOut(TestUserProfiles);
            }
        }

        public override void Close(object modalResult)
        {
            base.Close(modalResult);

            var titleScreen = new TitleScreen();
            var screenManager = Service.Get<ScreenManager>();
            if (screenManager != null)
            {
                screenManager.AddScreen(titleScreen);
            }                       
        }

        private void InitializeButtons()
        {            
        }   
        
        private void TestUserProfiles()
        {
            UserDataService userDataService = new UserDataService();

            var core = Service.Get<Core>();
            if(core != null)
            {
                core.GameStartCoroutine(userDataService.GetData(() => 
                {
                }));
            }
        }
    }
}

