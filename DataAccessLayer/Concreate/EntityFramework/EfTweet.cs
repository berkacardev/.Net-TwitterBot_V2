using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.EntityFramework.Context;
using DataAccessLayer.Concreate.WindowsFile;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate.EntityFramework
{
    public class EfTweet : ITweetDal
    {
        EfContext efContext;
        IFileDal _fileDal;
        public EfTweet()
        {
            efContext = new EfContext();
            _fileDal = new WfFile();
        }
        public bool Add(Tweet tweet)
        {


            try
            {
                string newMediaFileName = string.Empty;
                if (tweet.TweetMediaPath != string.Empty)
                {
                    newMediaFileName = _fileDal.SetTweetMediaFile(tweet);
                }
                else
                {
                    tweet.TweetMediaPath = newMediaFileName;
                }
                tweet.TweetMediaPath = newMediaFileName;
                efContext.Tweet.Add(tweet);
                efContext.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception();
            }
        }



        public bool Delete(Tweet tweet)
        {
            try
            {
                efContext.Tweet.Remove(tweet);
                efContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Tweet> List()
        {
            List<Tweet> tweets = efContext.Tweet.Where(u => u.TweetStatus == true).ToList();
            return tweets;
        }

        public int CountOfTweet()
        {
            int totalTweetNumber = List().Count();
            return totalTweetNumber;
        }

        public bool Update(Tweet tweet)
        {
            try
            {
                int tweetId = tweet.TweetId;
                Tweet _tweet = efContext.Tweet.Find(tweetId);
                _tweet.TweetMediaPath = tweet.TweetMediaPath;
                _tweet.TweetStatus = tweet.TweetStatus;
                _tweet.TweetText = tweet.TweetText;
                _tweet.TweetDate = tweet.TweetDate;
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
