using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Widgets
{
    class GenericButton
    {
        protected Animator animator;
        protected Button button;
        protected GameObject root;
        protected RawImage buttonImage;

        protected string pressedTransition = "ToPressedTransition";

        private bool enabled = true;

        public GenericButton( GameObject root )
        {
            this.root = root;
        }

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public virtual void Intialize( Action onPressed, string soundId = null )
        {
            animator = root.GetComponent<Animator>();
            button = root.GetComponent<Button>();

            if( button != null && onPressed != null )
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

                    onPressed(); 
                });
            }
        }

        public void SetButtonImage(RawImage image)
        {
            if(image != null)
            {
                buttonImage = image;
            }            
        }

        public void DisableButton()
        {
            if(buttonImage != null)
            {
                var tempColor = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 0.5f);
                buttonImage.color = tempColor;
            }

            Enabled = false;
        }

        public void EnableButton()
        {
            if (buttonImage != null)
            {
                var tempColor = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 1.0f);
                buttonImage.color = tempColor;
            }

            Enabled = true;
        }
    }
}
