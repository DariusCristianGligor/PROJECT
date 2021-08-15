using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal static class ServiceLocator
    {
        private static readonly IKernel Kernel = new StandardKernel();
        public static void RegisterAll()
        {
            Kernel.Bind<IInterfaceWrite>().To<WriteWithSqlServer>();
            Kernel.Bind<IInterfaceWrite>().To<WriteWithOracle>();
        }
        public static T Resolve<T>()
        {

            return Kernel.Get<T>();
        }
    }
}
