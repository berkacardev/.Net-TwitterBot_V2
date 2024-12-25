using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ITweetSharedTimeDal
    {
        bool Add(TweetSharedTime tweetSharedTime);
        bool Delete(TweetSharedTime tweetSharedTime);
        List<TweetSharedTime> List();
    }
}
