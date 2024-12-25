using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Abstract
{
    public interface ITwitterAccountToFollow
    {
        int AccountToFollowId { get; set; }
        string AccountToFollowUserName { get; set; }
        DateTime AccountToFollowDate { get; set; }
        bool AccountToFollowStatus { get; set; }
    }
}
