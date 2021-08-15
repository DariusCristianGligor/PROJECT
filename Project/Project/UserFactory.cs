using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class UserFactory
    {
        public static User CreateUser(string name, string mail, string address, string password, IInterfaceWrite writeSomewhere)
        {
            var user = new User(name,mail,address,password,writeSomewhere);
            return user;
        }

    }
}
