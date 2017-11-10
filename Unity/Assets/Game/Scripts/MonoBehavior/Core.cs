using UnityEngine;
using System;
using System.Collections;
using Game.Scripts.UI.Screens;
using Game.Scripts.UI;
using Game.Scripts.Helpers;
using Game.Scripts.Audio;

namespace Game.Scripts.MonoBehavior
{
    public class Core : MonoBehaviour
    {
        public GameObject uiSystem;

        [HideInInspector]
        public static Core Instance;

        public delegate void OnCoreFrameUpdateHandler(float deltaTime);
        public event OnCoreFrameUpdateHandler FrameUpdate;

        private bool isInitialized = false;

        // Use this for initialization
        void Start()
        {
            Service.Set<Core>(this);

            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);             
            }
            else
            {
                DestroyObject(this);
                return;
            }

            if(Initialize())
            {
                LoadTitleScreen();
            }            
        }

        void Awake()
        {

        }

        private bool Initialize()
        {
            if(uiSystem != null)
            {
                var screenManager = new ScreenManager(uiSystem);
                Service.Set<ScreenManager>(screenManager);

                var playerPrefHelper = new PlayerPrefHelper();
                Service.Set<PlayerPrefHelper>(playerPrefHelper);

                var audioManager = new AudioManager();
                audioManager.Initialize();
                Service.Set<AudioManager>(audioManager);

                var blackScreen = new BlackScreen();
                screenManager.AddScreen(blackScreen);

                isInitialized = true;
            }
            else
            {
                Debug.LogError("[Core::Initialize - GameObject uiSystem is null.]");
                return false;
            }

            return true;
        }        

        private void LoadTitleScreen()
        {
            var titleScreen = new TitleScreen();
            var screenManager = Service.Get<ScreenManager>();
            if (screenManager != null)
            {
                screenManager.AddScreen(titleScreen);
            }            
        }

        // Update is called once per frame
        void Update()
        {
            if(isInitialized)
            {
                float deltaTime = Time.deltaTime;

                Update(deltaTime);
            }            
        }

        public void Update(float dt)
        {
#if UNITY_ANDROID
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
#endif
            if (FrameUpdate != null)
            {
                FrameUpdate(dt);
            }
        }

        public IEnumerator Wait( float time, Action callback )
        {
            yield return new WaitForSeconds(time);

            if( callback != null )
            {
                callback();
            }            
        }

        public void DestroyObject( GameObject obj )
        {
            GameObject.DestroyObject(obj);
        }

        public void GameStartCoroutine( IEnumerator routine )
        {
            StartCoroutine(routine);
        }
    }
}

