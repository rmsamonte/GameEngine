using Game.Scripts.Backend.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Backend.Services
{
    public class UserDataService : IService
    {
        private string GET_URL = Constants.Server.BASE_URL + "users.php";

        public UserDataService()
        {

        }

        public IEnumerator PostData(System.Object obj)
        {
            if(obj != null)
            {
                var userData = obj as UserData;
            }            

            yield return null;
        }

        public IEnumerator GetData(Action<string> callback)
        {
            List<UserData> userList = new List<UserData>();

            var www = new WWW(GET_URL, null, Utilities.GetWwwHeader());                

            while(!www.isDone && string.IsNullOrEmpty(www.error))
            {
                yield return www;
            }

            if(callback != null)
            {
                callback(www.text);
            }
        }
    }
}
