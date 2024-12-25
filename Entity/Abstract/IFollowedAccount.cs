using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Abstract
{
    public interface IFollowedAccount
    {
        int Id { get; set; }
        int FollowingAccountId { get; set; }
        int FollowedAccountId { get; set; }
        DateTime FollowingDate { get; set; }
    }
}
