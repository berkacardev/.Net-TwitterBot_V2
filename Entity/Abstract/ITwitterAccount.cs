using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Abstract
{
    public interface ITwitterAccount
    {
        int AccountId { get; set; }
        string AccountUserName { get; set; }
        string AccountPassword { get; set; }
        string AccountEmailAddress { get; set; }
        string AccountPhoneNumber { get; set; }
        DateTime AccountDate { get; set; }
    }
}
