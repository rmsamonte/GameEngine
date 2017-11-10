using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Timers;
using Game.Scripts.Helpers;
using Game.Scripts.MonoBehavior;

namespace Game.Scripts.UI.Screens
{
    public class OptionsScreen : BaseScreen
    {
        public const string PREFAB_PATH = "Data/UI/Prefabs/OptionsScreen/ui_options_screen";

        private const string UI_CLOSE_BUTTON = "Close Button";

        private bool transitioning = false;

        public OptionsScreen()
            : base(PREFAB_PATH)
        {
            
        }

        public override string ScreenName
        {
            get { return "OptionsScreen"; }
        }

        public override string Layer
        {
            get { return Constants.Layers.POPUP; }
        }

        public override void OnLoaded()
        {
            base.OnLoaded();

            var closeButton = GetElement(UI_CLOSE_BUTTON).GetComponent<Button>();
            closeButton.onClick.AddListener(CloseScreen);

            if (screenAnimator != null)
            {
                screenAnimator.SetTrigger("DoShow");
            }
        }

        public void CloseScreen()
        {
            if (screenAnimator != null)
            {
                screenAnimator.SetTrigger("DoHide");
            }

            var core = Core.Instance;
            core.GameStartCoroutine(core.Wait(0.5f, () =>
            {
                base.Close(null);
            }));
        }
    }
}

