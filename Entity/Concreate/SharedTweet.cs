using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
    public class SharedTweet : ISharedTweet
    {
        public int SharedTweetId { get; set; }
        public int TweetId { get; set; }
        public int TwitterAccountId { get; set; }
        public DateTime ShareDateTime { get; set; }
    }
}
