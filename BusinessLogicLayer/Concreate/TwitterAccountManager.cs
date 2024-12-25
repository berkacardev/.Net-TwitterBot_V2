using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Utilities;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.EntityFramework;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concreate
{
    public class TwitterAccountManager : ITwitterAccountService
    {
        ITwitterAccountDal _twitterAccountDal;
        ISharedTweetService _sharedTweetService;
        public TwitterAccountManager()
        {
            _twitterAccountDal = NinjectInstanceFactory.GetInstance<ITwitterAccountDal>();
            _sharedTweetService = NinjectInstanceFactory.GetInstance<ISharedTweetService>();
        }

        public bool AccountWillShareTweet(TwitterAccount twitterAccount, int willBeSharedTweetCount, int timeIntervalAsMinute = -1, string hourIntervalFirst = null, string hourIntervalLast = null)
        {
            int twitterAccountId = twitterAccount.AccountId;
            List<SharedTweet> sharedAllTweets = _sharedTweetService.List().Where(u => u.TwitterAccountId == twitterAccountId).ToList();
            List<SharedTweet> sharedTodayTweets = sharedAllTweets.Where(u => u.ShareDateTime.Year == DateTime.Now.Year && u.ShareDateTime.Month == DateTime.Now.Month && u.ShareDateTime.Day == DateTime.Now.Day).ToList();
            int sharedTodayTweetNumber = sharedTodayTweets.Count;
            if(hourIntervalFirst != null && hourIntervalLast != null)
            {
                int hourIntervalFirstAfterProcess = Helper.ConvertFromStringToIntForHourInfo(hourIntervalFirst);
                int hourIntervalLastAfterProcess = Helper.ConvertFromStringToIntForHourInfo(hourIntervalLast);
                if((hourIntervalFirstAfterProcess > hourIntervalLastAfterProcess))
                {

                }

                if(DateTime.Now.Hour>= hourIntervalFirstAfterProcess && DateTime.Now.Hour <= hourIntervalLastAfterProcess)
                {
                    if (sharedTodayTweetNumber > 0)
                    {
                        SharedTweet sharedTweet = sharedTodayTweets[sharedTodayTweets.Count - 1];
                        DateTime sharedTweetDateTime = sharedTweet.ShareDateTime;
                        int passedTimeAsMinute = Helper.CalculateMinuteFromDateTime(sharedTweetDateTime);
                        if (timeIntervalAsMinute > 0)
                        {
                            if (willBeSharedTweetCount > sharedTodayTweetNumber && passedTimeAsMinute >= timeIntervalAsMinute)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    if (willBeSharedTweetCount > sharedTodayTweetNumber)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (sharedTodayTweetNumber > 0)
                {
                    SharedTweet sharedTweet = sharedTodayTweets[sharedTodayTweets.Count - 1];
                    DateTime sharedTweetDateTime = sharedTweet.ShareDateTime;
                    int passedTimeAsMinute = Helper.CalculateMinuteFromDateTime(sharedTweetDateTime);
                    if (timeIntervalAsMinute > 0)
                    {
                        if (willBeSharedTweetCount > sharedTodayTweetNumber && passedTimeAsMinute >= timeIntervalAsMinute)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                if (willBeSharedTweetCount > sharedTodayTweetNumber)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Add(TwitterAccount twitterAccount)
        {
            twitterAccount.AccountDate = DateTime.Now;
            twitterAccount.AccountStatus = true;
            bool result = _twitterAccountDal.Add(twitterAccount);
            return result;
        }

        public int CountrOfAllAccount()
        {
            int result = _twitterAccountDal.CountrOfAllAccount();
            return result;
        }

        public bool Delete(TwitterAccount twitterAccount)
        {
            bool result = _twitterAccountDal.Delete(twitterAccount);
            return result;
        }

        public List<TwitterAccount> List()
        {
            List<TwitterAccount> result = _twitterAccountDal.List();
            return result;
        }

        public bool Update(TwitterAccount twitterAccount)
        {
            bool result = _twitterAccountDal.Update(twitterAccount);
            return result;
        }
    }
}
