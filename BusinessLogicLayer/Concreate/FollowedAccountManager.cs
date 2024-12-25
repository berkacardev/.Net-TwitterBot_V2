using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Utilities;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.EntityFramework;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concreate
{
    public class FollowedAccountManager : IFollowedAccountService
    {
        IFollowedAccountDal _followedAccountDal;
        public FollowedAccountManager()
        {
            _followedAccountDal = NinjectInstanceFactory.GetInstance<IFollowedAccountDal>();
        }
        public bool Add(FollowedAccount followedAccount)
        {
            bool result = _followedAccountDal.Add(followedAccount);
            return result;
        }

        public bool Delete(FollowedAccount followedAccount)
        {
            bool result = _followedAccountDal.Delete(followedAccount);
            return result;
        }

        public bool IsAccountFollowed(TwitterAccountToFollow twitterAccountToFollow)
        {
            bool result = _followedAccountDal.IsAccountFollowed(twitterAccountToFollow);
            return result;
        }

        public List<FollowedAccount> List()
        {
            List<FollowedAccount> result = _followedAccountDal.List();
            return result;
        }

        public bool Update(FollowedAccount followedAccount)
        {
            bool result = _followedAccountDal.Update(followedAccount);
            return result;
        }
    }
}
