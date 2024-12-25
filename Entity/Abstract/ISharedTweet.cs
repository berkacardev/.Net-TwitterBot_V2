using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Abstract
{
    public interface ISharedTweet
    {
        int SharedTweetId { get; set; }
        int TweetId { get; set; }
        int TwitterAccountId { get; set; }
        DateTime ShareDateTime { get; set; }
    }
}
