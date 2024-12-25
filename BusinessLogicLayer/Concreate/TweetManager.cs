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
    public class TweetManager : ITweetService
    {
        ITweetDal _tweetDal;
        public TweetManager()
        {
            _tweetDal = NinjectInstanceFactory.GetInstance<ITweetDal>();
        }
        public bool Add(Tweet tweet)
        {
            tweet.TweetStatus = true;
            tweet.TweetDate = DateTime.Now;
            bool result = _tweetDal.Add(tweet);
            return result;
        }

        public bool Delete(Tweet tweet)
        {
            bool result = _tweetDal.Delete(tweet);
            return result;
        }

        public List<Tweet> List()
        {
            List<Tweet> tweets = _tweetDal.List();
            return tweets;
        }

        public int CountOfTweet()
        {
            int result = _tweetDal.CountOfTweet();
            return result;
        }

        public bool Update(Tweet tweet)
        {
            bool result = _tweetDal.Update(tweet);
            return result;
        }
    }
}
