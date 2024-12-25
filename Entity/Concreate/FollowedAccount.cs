using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
    public class FollowedAccount
    {
        [Key] public int Id { get; set; }
        public int FollowingAccountId { get; set; }
        public int FollowedAccountId { get; set; }
        public DateTime FollowingDate { get; set; }
    }
}
