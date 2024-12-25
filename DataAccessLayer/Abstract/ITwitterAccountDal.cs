using Entity.Abstract;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ITwitterAccountDal
    {
        List<TwitterAccount> List();
        int CountrOfAllAccount();
        bool Add(TwitterAccount twitterAccount);
        bool Update(TwitterAccount twitterAccount);
        bool Delete(TwitterAccount twitterAccount);
    }
}
