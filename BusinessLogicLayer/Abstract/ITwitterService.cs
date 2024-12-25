using Entity.Concreate;
using Entity.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface ITwitterService
    {
        void Login(TwitterAccount twitterAccount);
        void LogOut();
        bool IsLogin();
        bool Follow(TwitterAccountToFollow twitterAccountToFollow, int minValue, int maxValue);
        bool FollowingAccountExistOrBlocked(TwitterAccountToFollow twitterAccountToFollow);
        TwitterAccountSituations TwitterAccountStatus();
        bool ShareTweet(Tweet tweet);
        bool TweetIsShared(bool isHaveMedia);
        bool ChangeAccountPassword(TwitterAccount twitterAccount);
        bool SendPhonNumberToVerifyInLogin(TwitterAccount twitterAccount);
        bool SendMailAdressToVerifyInLogin(TwitterAccount twitterAccount);
    }
}
