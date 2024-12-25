using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface ITweetSharedTimeService
    {
        bool Add(TweetSharedTime tweetSharedTime);
        bool Delete(TweetSharedTime tweetSharedTime);
        List<TweetSharedTime> List();
    }
}
