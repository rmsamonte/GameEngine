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

        public IEnumerator GetData(Action<string> callback)
        {
            List<UserData> userList = new List<UserData>();

            var www = new WWW(GET_URL, null, Utilities.GetWwwHeader());

            while (!www.isDone && string.IsNullOrEmpty(www.error))
            {
                yield return www;
            }

            if (callback != null)
            {
                callback(www.text);
            }
        }

        public IEnumerator PostData<UserData>(UserData[] array, Action<string> callback = null)
        {
            //TODO:  Implement functionality...

            yield return null;
        }        

        public IEnumerator InsertData<UserData>(UserData[] array, Action<string> callback = null)
        {
            //TODO:  Implement functionality...

            yield return null;
        }

        public IEnumerator UpdateData<UserData>(UserData[] array, Action<string> callback = null)
        {
            //TODO:  Implement functionality...

            yield return null;
        }

        public IEnumerator DeleteData<UserData>(UserData[] array, Action<string> callback = null)
        {
            //TODO:  Implement functionality...

            yield return null;
        }
    }
}
