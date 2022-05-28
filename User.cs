using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_work
{
    public class User
    {
        int id;
        string userName;
        bool isAdmin;

        public User(int id_, string userName_, bool isAdmin_)
        {
            id = id_;
            userName = userName_;
            isAdmin = isAdmin_;
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }
        }

        public bool IsAdmin
        {
            get
            {
                return isAdmin;
            }
        }
    }
}
