using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class WriteWithSqlServer : IInterfaceWrite
    {
        public WriteWithSqlServer()
        { 
        
        }
        public void Write(string name, string mail, string address, string password)
        {
            Console.WriteLine($@"We wrote it, with SQLLLLLLLLLLL:{name}:
{mail},
{password},
{address},");
        }
    }
}
