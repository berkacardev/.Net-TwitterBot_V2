using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Concreate;
using BusinessLogicLayer.Concreate.Selenium;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterfaceWF.DependencyResolvers.Ninject
{
    public class UserInterfaceModule : NinjectModule
    {
        public override void Load()
        {

            Bind<ITwitterAccountService>().To<TwitterAccountManager>();
            Bind<ITwitterAccountToFollowService>().To<TwitterAccountToFollowManager>();
            Bind<ITwitterService>().To<SeleniumTwitterManager>();
            Bind<IConfugrateService>().To<ConfugrateManager>();
            Bind<IFollowedAccountService>().To<FollowedAccountManager>();
            Bind<ITweetService>().To<TweetManager>();
            Bind<IProcessHistoryService>().To<ProcessHistoryManager>();
            Bind<ITweetSharedTimeService>().To<TweetSharedTimeManager>();
            Bind<ISharedTweetService>().To<SharedTweetManager>();
        }
    }
}
