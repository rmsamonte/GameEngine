using UnityEngine;

namespace Game.Scripts.Level
{
    public class LevelManager
    {
        private static string PREFAB_PATH = "Data/Prefabs/GameWorld";
        public static string TERRAIN_CONTAINER = "TerrainContainer";
        public static string OBJECTS_CONTAINER = "ObjectsContainer";

        private GameObject root;
        private GameObject terrainContainer;
        private GameObject objectsContainer;

        public LevelManager()
        {
            Initialize();
        }

        private void Initialize()
        {
            root = UnityUtils.CreateGameObject(PREFAB_PATH);
            if(root != null)
            {
                terrainContainer = UnityUtils.FindChildByName(root, TERRAIN_CONTAINER);
                objectsContainer = UnityUtils.FindChildByName(root, OBJECTS_CONTAINER);

                Object.DontDestroyOnLoad(root);
            }
        }

        public void AddTerrain(Environment terrain, Vector3 position = new Vector3(), Quaternion rot = new Quaternion())
        {
            if(terrain != null && terrainContainer != null)
            {
                terrain.transform.parent = terrainContainer.transform;
                terrain.transform.position = position;
                terrain.transform.rotation = rot;
            }
        }

        public void AddGameObject(GameObject obj, Vector3 position = new Vector3(), Quaternion rot = new Quaternion())
        {
            if (obj != null && objectsContainer != null)
            {
                obj.transform.parent = objectsContainer.transform;
                obj.transform.position = position;
                obj.transform.rotation = rot;
            }
        }

        public void DestroyAllTerrain()
        {
            if (terrainContainer != null)
            {
                foreach (GameObject child in terrainContainer.transform)
                {
                    Object.Destroy(child);
                }
            }
        }

        public void DestroyAllGameObjects()
        {
            if(objectsContainer != null)
            {
                foreach(GameObject child in objectsContainer.transform)
                {
                    Object.Destroy(child);
                }
            }
        }

        public void CleanLevel()
        {
            DestroyAllGameObjects();
            DestroyAllTerrain();
        }
    }
}

