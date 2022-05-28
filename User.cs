using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_work
{
    public class User
    {
        string userName;
        bool isAdmin;

        public User(string userName_, bool isAdmin_)
        {
            userName = userName_;
            isAdmin = isAdmin_;
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
