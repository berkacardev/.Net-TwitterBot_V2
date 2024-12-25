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
    public class EfTweetSharedTime : ITweetSharedTimeDal
    {
        EfContext efContext;
        public EfTweetSharedTime()
        {
            efContext = new EfContext();
        }
        public bool Add(TweetSharedTime tweetSharedTime)
        {
            try
            {
                efContext.TweetSharedTime.Add(tweetSharedTime);
                efContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(TweetSharedTime tweetSharedTime)
        {
            try
            {
                efContext.TweetSharedTime.Remove(tweetSharedTime);
                efContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TweetSharedTime> List()
        {
            List<TweetSharedTime> tweetSharedTimes = efContext.TweetSharedTime.ToList();
            return tweetSharedTimes;
        }
    }
}
