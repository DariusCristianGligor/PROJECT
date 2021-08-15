using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class WriteWithOracle : IInterfaceWrite
    {
        public WriteWithOracle()
        { 
        }
        public void Write(string name, string mail, string address, string password)
        {
          
                Console.WriteLine($@"We wrote it, with Oracle{name}:
{mail},
{password},
{address},");
            
        }
    }
}
