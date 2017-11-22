using System;
using System.Collections.Generic;

namespace Game.Scripts.Level
{
    public class Entity
    {
        public Entity(string asset)
        {

        }

        virtual public string Layer
        {
            get; set;
        }
    }
}
