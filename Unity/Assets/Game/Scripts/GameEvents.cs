using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    public class TimedEvent
    {
        public float StartTime;
        public float EndTime;
        public float Duration;
        public Action Callback;
        public bool Repeat;
    }

    public class GameEvents : IDisposable
    {
        private int registeredEventIdCounter = 0;

        public delegate void FrameUpdateHandler(float deltaTime);
        public event FrameUpdateHandler FrameUpdate;
        public event FrameUpdateHandler PhysicsUpdate;

        public delegate void GameTimeUpdateHandler(float gameTime);
        public event GameTimeUpdateHandler GameTimeUpdate;

        public float GameTime { get; set; }

        void IDisposable.Dispose()
        {
            
        }
    }
}
