using UnityEngine;
using System.Collections;

namespace Game.Scripts
{
    public interface IModule
    {
        void Attach();
        void Detach();
    }
}

