using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
    public class TweetSharedTime : ITweetSharedTime
    {
        public override string ToString()
        {
            return "Saat: " + this.TweetSharedFirstTime + " - " + "Saat: " + this.TweetSharedSecondTime+" Arasında "+ this.TweetNumberToShare.ToString()+" Adet Tweet Atılacak";
        }
        public int TweetSharedTimeId { get; set; }
        public string TweetSharedFirstTime { get; set; }
        public string TweetSharedSecondTime { get; set; }
        public int TweetNumberToShare { get; set; }
    }
}
