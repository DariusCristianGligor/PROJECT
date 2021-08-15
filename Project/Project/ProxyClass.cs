using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    //PROXYY
    interface IUser 
    {
        public void changeThePassword(string pass)
        {
            throw new NotImplementedException();
        }
    }
    class Userr :IUser
    {
        public Guid IdUser { get; }
        public string Name { set; get; }
        public string Mail { set; get; }
        public List<Review> reviews { set; get; }
        public string Address { set; get; }

        public string Password { set; get; }

        public Userr(string name, string mail, string adrress,string password)
        {
            Password = password;
            Name = name;
            IdUser = new Guid();
            Mail = mail;
            Address = adrress;
        }
        public void addReview(Review review)
        {
            reviews.Add(review);
        }
        public  void changeThePassword(string pass)
        {
            Password = pass;
        }
        public override string ToString()
        {
            return $"Name:{Name} :: mail :{Mail} :: {Address}";
        }
    }

    class ProxyU : IUser
    {
        public IUser user;
        public ProxyU(IUser user)
        {
            this.user = user;
        }
    
        public void changeThePassword(string pass)
        {

            if (pass.Length < 7)
            {
                throw new Exception($"your password{pass} is too short");
            }
            else {
                user.changeThePassword(pass);
                Console.WriteLine("We changed your password!!!");
            }
        }
    }
}
