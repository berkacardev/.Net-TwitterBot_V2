using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Concreate;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.EntityFramework;
using DataAccessLayer.Concreate.WindowsRegistery;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfugrateDal>().To<WrConfugrate>();
            Bind<IFollowedAccountDal>().To<EfFollowedAccount>();
            Bind<ITwitterAccountDal>().To<EfTwitterAccount>();
            Bind<ITwitterAccountToFollowDal>().To<EfTwitterAccountToFollow>();
            Bind<ITweetDal>().To<EfTweet>();
            Bind<IProcessHistoryDal>().To<EfProcessHistory>();
            Bind<ISharedTweetDal>().To<EfSharedTweet>();
            Bind<ITweetSharedTimeDal>().To<EfTweetSharedTime>();
            Bind<ISharedTweetService>().To<SharedTweetManager>(); 
        }
    }
}
