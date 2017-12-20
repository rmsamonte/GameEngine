using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Scripts;

namespace Game.Scripts.Level
{
    public class Environment
    {
        protected GameObject root;
        protected RectTransform recTransform;

        protected Modules modules;

        public Environment(string asset)
        {
            modules = new Modules();

            root = UnityUtils.CreateGameObject(asset);
            recTransform = root.GetComponent<RectTransform>();
        }

        virtual public string Layer
        {
            get { return Constants.EnvironmentLayers.TERRAIN; }
        }

        public Transform transform
        {
            get { return root.transform; }
        }

        public RectTransform RectTransform
        {
            get { return recTransform; }
        }
    }
}

