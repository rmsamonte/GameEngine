using Fabric;
using Game.Scripts.Helpers;
using System;
using UnityEngine;

namespace Game.Scripts.Audio
{
    class AudioManager
    {
        public const string PREFAB_PATH = "Data/Audio/AudioManager";
        private GameObject audioManager;

        private const string MUTED = "Mute";
        private const string UNMUTED = "Unmute";

        private const string MUSIC = "Music";
        private const string GAME_SOUND = "Game";
        private const string SOUND_EFFECT = "UI";

        private AudioMixer audioMixer;

        private GroupComponent musicGroupComponent;
        private GroupComponent gameGroupComponent;
        private GroupComponent sfxGroupComponent;

        private static AudioManager instance;

        public static AudioManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AudioManager();
                }
                return instance;
            }
        }

        public AudioManager()
        {
            audioManager = UnityUtils.CreateGameObject( PREFAB_PATH );

            if (instance == null)
            {
                instance = this;
            }

            audioMixer = audioManager.GetComponent<AudioMixer>();           
        }

        public void Initialize()
        {
            if (audioMixer != null)
            {
                var groupComponentObj = audioManager.transform.Find(GAME_SOUND);
                if(groupComponentObj != null)
                {
                    gameGroupComponent = groupComponentObj.GetComponent<GroupComponent>();
                }

                groupComponentObj = audioManager.transform.Find(MUSIC);
                if (groupComponentObj != null)
                {
                    musicGroupComponent = groupComponentObj.GetComponent<GroupComponent>();
                }

                groupComponentObj = audioManager.transform.Find(SOUND_EFFECT);
                if (groupComponentObj != null)
                {
                    sfxGroupComponent = groupComponentObj.GetComponent<GroupComponent>();
                }
            }            

            var playerPrefHelper = PlayerPrefHelper.Instance;
            if( !playerPrefHelper.HasKey(Constants.GamePrefs.MUSIC_KEY) || !playerPrefHelper.HasKey(Constants.GamePrefs.SOUND_FX_KEY) )
            {
                playerPrefHelper.SetMusicPreference(1);
                playerPrefHelper.SetSoundFXPreference(1);
            }

            var musicStatus = playerPrefHelper.GetMusicPreference();
            var soundStatus = playerPrefHelper.GetSoundFXPreference();

            if (musicStatus)
            {
                LoadSnapShot(musicGroupComponent, UNMUTED, 0.0f);
            }
            else
            {
                LoadSnapShot(musicGroupComponent, MUTED, 0.0f);
            }

            if (soundStatus)
            {
                LoadSnapShot(gameGroupComponent, UNMUTED, 0.0f);
                LoadSnapShot(sfxGroupComponent, UNMUTED, 0.0f);
            }
            else
            {
                LoadSnapShot(gameGroupComponent, MUTED, 0.0f);
                LoadSnapShot(sfxGroupComponent, MUTED, 0.0f);
            }
        }

        private GroupComponent GetGroupComponent(string groupName)
        {
            var groupTransform = audioManager.transform.Find(groupName);

            if (groupTransform != null)
            {
                var groupComponent = groupTransform.GetComponent<GroupComponent>();

                if (groupComponent != null)
                {
                    return groupComponent;
                }
            }

            return null;
        }

        private void LoadSnapShot(GroupComponent group, string snapShotName, float time)
        {
            if (group == null)
            {
                Debug.LogWarning("UNABLE TO LOAD SNAPSHOT -----> LoadSnapShot: " + snapShotName);
                return;
            }

            group._audioMixerGroup.audioMixer.FindSnapshot(snapShotName).TransitionTo(time);
        }

        public void PlaySound(string eventName)
        {
            if(!String.IsNullOrEmpty(eventName))
            {
                Fabric.EventManager.Instance.PostEvent(eventName, Fabric.EventAction.PlaySound);
            }
            else
            {
                Debug.LogWarning("UNABLE TO PLAY SOUND EVENT -----> : " + eventName);
            }            
        }

        public void PlayMusic(bool status, string eventName)
        {
            if (!String.IsNullOrEmpty(eventName))
            {
                if (status)
                {
                    Fabric.EventManager.Instance.PostEvent(eventName);
                }
                else
                {
                    Fabric.EventManager.Instance.PostEvent(eventName, Fabric.EventAction.StopSound);
                }
            }
            else
            {
                Debug.LogWarning("UNABLE TO MUSIC SOUND EVENT -----> : " + eventName);
            }                
        }

        public void EnableMusic(bool val, float time = 0.35f)
        {
            if (val)
            {
                LoadSnapShot(musicGroupComponent, UNMUTED, time);
            }
            else
            {
                LoadSnapShot(musicGroupComponent, MUTED, time);
            }
        }

        public void EnableSoundEffects(bool val, float time = 0.35f)
        {
            if (val)
            {
                LoadSnapShot(sfxGroupComponent, UNMUTED, time);
                LoadSnapShot(gameGroupComponent, UNMUTED, time);
            }
            else
            {
                LoadSnapShot(sfxGroupComponent, MUTED, time);
                LoadSnapShot(gameGroupComponent, MUTED, time);
            }
        }

        public void MuteAllSounds()
        {
            EnableMusic(false, 0.0f);
            EnableSoundEffects(false, 0.0f);
        }
    }
}
