using System;

namespace Game.Scripts.Backend.Model
{
    [Serializable]
    public class UserData
    {
        public int id;
        public String username;
        public String fname;
        public String lname;
        public String email;

        public UserData()
        {

        }
    }
}
