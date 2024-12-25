using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.EntityFramework.Context;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate.EntityFramework
{
    public class EfFollowedAccount : IFollowedAccountDal
    {
        EfContext efContext;
        public EfFollowedAccount()
        {
            efContext = new EfContext();
        }
        public bool Add(FollowedAccount followedAccount)
        {
            try
            {
                efContext.FollowedAccount.Add(followedAccount);
                efContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(FollowedAccount followedAccount)
        {
            try
            {
                efContext.FollowedAccount.Remove(followedAccount);
                efContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsAccountFollowed(TwitterAccountToFollow twitterAccountToFollow)
        {
            int twitterAccountToFollowId = twitterAccountToFollow.AccountToFollowId;
            List<FollowedAccount> followedAccounts = efContext.FollowedAccount.Where(u => u.FollowedAccountId == twitterAccountToFollowId).ToList();
            if (followedAccounts.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<FollowedAccount> List()
        {
            List<FollowedAccount> followedAccounts = efContext.FollowedAccount.ToList();
            return followedAccounts;
        }

        public bool Update(FollowedAccount followedAccount)
        {
            try
            {
                int followedAccountId = followedAccount.Id;
                FollowedAccount _followedAccount = efContext.FollowedAccount.Find(followedAccountId);
                _followedAccount.FollowedAccountId = followedAccount.FollowedAccountId;
                _followedAccount.FollowingAccountId = followedAccount.FollowingAccountId;
                _followedAccount.FollowingDate = followedAccount.FollowingDate;
                efContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
