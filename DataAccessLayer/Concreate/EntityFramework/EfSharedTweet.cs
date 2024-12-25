using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.EntityFramework.Context;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate.EntityFramework
{
    public class EfSharedTweet : ISharedTweetDal
    {
        EfContext efContext;
        public EfSharedTweet()
        {
            efContext = new EfContext();
        }
        public bool Add(SharedTweet sharedTweet)
        {
            try
            {
                efContext.SharedTweet.Add(sharedTweet);
                efContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(SharedTweet sharedTweet)
        {
            try
            {
                efContext.SharedTweet.Remove(sharedTweet);
                efContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<SharedTweet> List()
        {
            List<SharedTweet> sharedTweets = efContext.SharedTweet.ToList();
            return sharedTweets;
        }

        public bool Update(SharedTweet sharedTweet)
        {
            try
            {
                int sharedTweetId = sharedTweet.SharedTweetId;
                SharedTweet _sharedTweet = efContext.SharedTweet.Find(sharedTweetId);
                _sharedTweet.TweetId = sharedTweet.SharedTweetId;
                _sharedTweet.TwitterAccountId = sharedTweet.TwitterAccountId;
                _sharedTweet.TweetId = sharedTweet.TweetId;
                efContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
