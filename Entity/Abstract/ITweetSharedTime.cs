using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Abstract
{
    public interface ITweetSharedTime
    {
        int TweetSharedTimeId { get; set; }
        string TweetSharedFirstTime { get; set; }
        string TweetSharedSecondTime { get; set; }
        int TweetNumberToShare { get; set; }
    }
}
