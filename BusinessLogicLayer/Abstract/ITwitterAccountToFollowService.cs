using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface ITwitterAccountToFollowService
    {
        List<TwitterAccountToFollow> List();
        bool Add(TwitterAccountToFollow twitterAccountToFollow);
        bool Add(List<TwitterAccountToFollow> twitterAccountToFollow);
        bool UpdateAsFollowed(TwitterAccountToFollow twitterAccountToFollow);
        bool Update(TwitterAccountToFollow twitterAccountToFollow);
        bool Delete(TwitterAccountToFollow twitterAccountToFollow);
        int CountOfAllAccount();
    }
}
