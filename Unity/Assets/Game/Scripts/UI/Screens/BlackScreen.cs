using UnityEngine;
using System;
using System.Collections;
using System.Timers;

namespace Game.Scripts.UI.Screens
{
    public class BlackScreen : BaseScreen
    {
        public const string PREFAB_PATH = "Data/UI/Prefabs/BlackScreen/ui_black_screen";

        public BlackScreen() : base(PREFAB_PATH)
        {
            
        }

        public override string ScreenName
        {
            get { return "BlackScreen"; }
        }

        public override string Layer
        {
            get { return Constants.Layers.BLACKSCREEN; }
        }

        public override void OnLoaded()
        {
            transitionIndex.Add("Fade Out", 0);
            transitionIndex.Add("Fade In", 1);
        }

        public override void Close(object modalResult)
        {
            Disable();
        }

        public void FadeOut()
        {
            //Enable();
            ScreenAnimator.Play("Fade Out");
        }

        public void FadeIn()
        {
            //Enable();
            ScreenAnimator.Play("Fade In");
        }

        public void Disable()
        {
            Root.SetActive(false);
        }

        public void Enable()
        {
            Root.SetActive(true);
        }
    }
}


