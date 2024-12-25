using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IFollowedAccountDal
    {
        List<FollowedAccount> List();
        bool Add(FollowedAccount followedAccount);
        bool Update(FollowedAccount followedAccount);
        bool Delete(FollowedAccount followedAccount);
        bool IsAccountFollowed(TwitterAccountToFollow twitterAccountToFollow);
    }
}
