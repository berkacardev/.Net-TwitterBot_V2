using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterfaceWF.DependencyResolvers.Ninject;

namespace UserInterfaceWF.Utilities
{
    public class NinjectInstanceFactory
    {
        public static T GetInstance<T>()
        {
            IKernel kernel = new StandardKernel(new UserInterfaceModule());
            return kernel.Get<T>();
        }
    }
}
