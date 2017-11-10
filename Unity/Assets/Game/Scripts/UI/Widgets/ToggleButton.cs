using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Widgets
{
    class ToggleButton : GenericButton
    {
        protected GameObject root;
        protected Button button;
        protected GameObject on;
        protected GameObject off;

        private bool toggleStatus = true;

        public ToggleButton(GameObject root) : base (root)
        {
            this.root = root;
            on = UnityUtils.FindChildByName(root, "On");
            off = UnityUtils.FindChildByName(root, "Off");
        }

        public bool Toggled
        {
            get { return toggleStatus; }
            set { 
                    toggleStatus = value;
                    Toggle(value);
                }
        }

        public virtual void Intialize( Action onPressed, string soundId = null )
        {
            button = root.GetComponent<Button>();

            if( button != null )
            {
                button.onClick.AddListener(() => 
                {
                    if(!Enabled)
                    {
                        return;
                    }

                    if( !string.IsNullOrEmpty( soundId ) )
                    {
                    }

                    if (animator != null )
                    {
                        animator.Play(pressedTransition);
                    }

                    if (onPressed != null)
                    {
                        onPressed();
                    }                     
                });
            }
        }

        public void Toggle(bool torf)
        {
            if (on != null)
            {
                on.SetActive(torf);
            }

            if (off != null)
            {
                off.SetActive(!torf);
            }

            toggleStatus = torf;
        }
    }
}
