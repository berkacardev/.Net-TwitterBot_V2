using BusinessLogicLayer.DependencyResolvers.Ninject;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Utilities
{
    public class NinjectInstanceFactory
    {
        public static T GetInstance<T>()
        {
            IKernel kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }
    }
}
