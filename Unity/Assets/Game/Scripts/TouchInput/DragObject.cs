using UnityEngine;

using Game.Scripts.Level;

namespace Game.Scripts.TouchInput
{
    public class DragObject : Entity
    {
        public static string PREFAB_PATH = "Data/Prefabs/Entities/DragObjectCube";

        private GameObject root;

        public DragObject() : base (PREFAB_PATH)
        {
            root = UnityUtils.CreateGameObject(PREFAB_PATH);
        }

        public void UpdateDrag(float gametime)
        {

        }
    }
}
