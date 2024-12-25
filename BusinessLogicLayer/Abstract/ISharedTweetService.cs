using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface ISharedTweetService
    {
        bool Add(SharedTweet sharedTweet);
        bool Update(SharedTweet sharedTweet);
        bool Delete(SharedTweet sharedTweet);
        List<SharedTweet> List();
    }
}
