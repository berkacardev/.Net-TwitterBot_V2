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
    public class SharedTweetManager : ISharedTweetService
    {
        ISharedTweetDal _sharedTweetDal;
        public SharedTweetManager()
        {
            _sharedTweetDal = NinjectInstanceFactory.GetInstance<ISharedTweetDal>();
        }
        public bool Add(SharedTweet sharedTweet)
        {
            bool result = _sharedTweetDal.Add(sharedTweet);
            return result;
        }

        public bool Delete(SharedTweet sharedTweet)
        {
            bool result = _sharedTweetDal.Delete(sharedTweet);
            return result;
        }

        public List<SharedTweet> List()
        {
            List<SharedTweet> sharedTweets = _sharedTweetDal.List();
            return sharedTweets;
        }

        public bool Update(SharedTweet sharedTweet)
        {
            bool result = _sharedTweetDal.Update(sharedTweet);
            return result;
        }
    }
}
