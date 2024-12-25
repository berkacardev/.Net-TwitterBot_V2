using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Utilities;
using DataAccessLayer.Abstract;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concreate
{
    public class TweetSharedTimeManager : ITweetSharedTimeService
    {
        ITweetSharedTimeDal _tweetSharedTimeDal;
        public TweetSharedTimeManager()
        {
            _tweetSharedTimeDal = NinjectInstanceFactory.GetInstance<ITweetSharedTimeDal>();
        }
        public bool Add(TweetSharedTime tweetSharedTime)
        {
            bool result = _tweetSharedTimeDal.Add(tweetSharedTime);
            return result;
        }

        public bool Delete(TweetSharedTime tweetSharedTime)
        {
            bool result = _tweetSharedTimeDal.Delete(tweetSharedTime);
            return result;
        }

        public List<TweetSharedTime> List()
        {
            List<TweetSharedTime> tweetSharedTimes = _tweetSharedTimeDal.List();
            return tweetSharedTimes;
        }
    }
}
