using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface ITweetService
    {
        bool Add(Tweet tweet);
        bool Update(Tweet tweet);
        bool Delete(Tweet tweet);
        int CountOfTweet();
        List<Tweet> List();
    }
}
