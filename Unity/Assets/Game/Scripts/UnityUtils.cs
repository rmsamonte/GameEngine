using UnityEngine;
using System.Collections;

public class UnityUtils
{
    public static GameObject CreateGameObject(string path)
    {
        return GameObject.Instantiate(Resources.Load(path) as GameObject);
    }

    public static GameObject FindGameObject( string name )
    {
        return GameObject.Find( name );
    }
	
    public static GameObject FindChildByName( GameObject root, string name )
    {
        if(root == null)
        {
            return null;
        }

        return root.transform.Find( name ).gameObject;
    }

    public static GameObject FindChildByNameInHierarchy(GameObject target, string name)
    {
        if( target.name == name )
        {
            return target;
        }

        return null;
    }
}
