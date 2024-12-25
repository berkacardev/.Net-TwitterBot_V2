using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface ITwitterAccountService
    {
        List<TwitterAccount> List();
        int CountrOfAllAccount();
        bool Add(TwitterAccount twitterAccount);
        bool Update(TwitterAccount twitterAccount);
        bool Delete(TwitterAccount twitterAccount);
        bool AccountWillShareTweet(TwitterAccount twitterAccount, int willBeSharedTweetCount, int timeIntervalAsMinute = -1, string hourIntervalFirst = null, string hourIntervalLast = null);
    }
}
