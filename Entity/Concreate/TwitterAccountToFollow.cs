using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
    public class TwitterAccountToFollow : ITwitterAccountToFollow
    {
        public TwitterAccountToFollow()
        {

        }
        public TwitterAccountToFollow(string accountToFollowUserName)
        {
            this.AccountToFollowUserName = accountToFollowUserName;
            this.AccountToFollowStatus = true;
            this.AccountToFollowDate = DateTime.Now;
        }
        public override string ToString()
        {
            return "@"+this.AccountToFollowUserName;
        }
        [Key] public int AccountToFollowId { get; set; }
        public string AccountToFollowUserName { get; set; }
        public DateTime AccountToFollowDate { get; set; }
        public bool AccountToFollowStatus { get; set; }
    }
}
