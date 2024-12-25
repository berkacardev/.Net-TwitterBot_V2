using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
    public class Tweet : ITweet
    {
        public override string ToString()
        {
            return this.TweetText;
        }
        public int TweetId { get; set; }
        public string TweetText { get; set; }
        public string TweetMediaPath { get; set; }
        public DateTime TweetDate { get; set; }
        public bool TweetStatus { get; set; }
    }
}
