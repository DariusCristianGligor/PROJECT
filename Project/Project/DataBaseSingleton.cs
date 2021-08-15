using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public sealed  class DataBaseSingleton
    {
        private static DataBaseSingleton obj;
        private int numberOfUsers;
        private static object locker = new object();
        

        public static DataBaseSingleton GetDataBaseSingleton()
        {

            if (obj == null)
            { 
            lock(locker)
                {
                    if (obj == null)
                    {
                        obj = new DataBaseSingleton();
                    }

                }
            
            }
            return obj;
        }
        public void Add()
        {      //the paarameter must be a user;
            //write in database the parametere;
            numberOfUsers = numberOfUsers++;
        }
        public int Added()
        {
            return numberOfUsers;
        }
    }
}
