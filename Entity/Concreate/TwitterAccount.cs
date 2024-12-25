using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
    public class TwitterAccount : ITwitterAccount
    {
        public TwitterAccount()
        {
                
        }
        public TwitterAccount(string userName, string userPassword, string userEmailAddress = null, string userPhoneNumber = null)
        {
            this.AccountUserName = userName;
            this.AccountPassword = userPassword;
            this.AccountEmailAddress = userEmailAddress;
            this.AccountPhoneNumber = userPhoneNumber;
        }
        public override string ToString()
        {
            string accountInfo = AccountUserName + "  |  " + AccountPassword;
            if (this.AccountEmailAddress != null && this.AccountEmailAddress != string.Empty)
            {
                accountInfo = accountInfo + " | " + AccountEmailAddress;
            }
            if(this.AccountPhoneNumber != null && this.AccountPhoneNumber !=string.Empty)
            {
                accountInfo = accountInfo + " | " + AccountPhoneNumber;
            }
            return accountInfo;
        }
        [Key] public int AccountId { get; set; }
        public string AccountUserName { get; set; }
        public string AccountPassword { get; set; }
        public string AccountEmailAddress { get; set; }
        public string AccountPhoneNumber { get; set; }
        public DateTime AccountDate { get; set; }
        public bool AccountStatus { get; set; }
    }
}
