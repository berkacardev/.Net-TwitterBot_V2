using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Abstract
{
    public interface ITweet
    {
        int TweetId { get; set; }
        string TweetText { get; set; }
        string TweetMediaPath { get; set; }
        DateTime TweetDate { get; set; }
        bool TweetStatus { get; set; }

    }
}
