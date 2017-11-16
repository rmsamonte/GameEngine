using Game.Scripts.Backend.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Backend.Services
{
    public class UserDataService
    {
        private string GET_URL = Constants.Server.BASE_URL + "users.php";

        public UserDataService()
        {

        }

        public IEnumerator GetData(Action callback)
        {
            List<UserData> userList = new List<UserData>();

            var www = new WWW(GET_URL, null, Utilities.GetWwwHeader());                

            while(!www.isDone && string.IsNullOrEmpty(www.error))
            {
                yield return www;
            }

            if(string.IsNullOrEmpty(www.error))
            {
                //TODO: Parse www.text...
            }

            if(callback != null)
            {
                callback();
            }
        }
    }
}
