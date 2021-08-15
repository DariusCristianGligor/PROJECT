using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class User: IUUser
    {
        public Guid IdUser { get; }
        public string Name { set; get; }
        public string Mail { set; get; }
        public List<Review> reviews { set; get; }
        public string Address { set; get; }

        public string Password { set; get;}

        private readonly IInterfaceWrite _writeSomewhere;

       public User(string name, string mail, string address,string password, IInterfaceWrite writeSomewhere)
        {

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name is null");
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("mail is null");
            if(string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("password is null");
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("address is null");
            Password = password;
            Name = name;
            IdUser = new Guid();
            Mail = mail;
            Address = address;
            _writeSomewhere = writeSomewhere;
        }
        public void WriteInDataBaze()
        {
            _writeSomewhere.Write(Name,Mail,Address,Password);
        }
        public void addReview(Review review)
        {
            reviews.Add(review);
        }
        public bool checkReview(Review rev)
        {
            if (reviews.Contains(rev))
                return true;
            return false;
        
        }
        public override string ToString()
        {
            return $"Name:{Name} :: mail :{Mail} :: {Address}";
        }
    }
}

