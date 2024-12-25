using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Constants
{
    public enum LogStatus
    {
        UndefinedError,

        InternetConnected,
        NoInternetConnected,
        ModemIsRebooting,
        ModemISRerebooting,

        TwitterLoginError,
        TwitterLoginSuccessful,
        TwitterLoginErrorRequireChangingPassword,
        TwitterLoginErrorAccountBlocked,
        TwitterLoginErrorRequirePhoneNumber,
        TwitterLoginErrorRequireEmail,
        TwitterLoginSendMobilePhoneError,
        TwitterLoginSendMobilePhoneSuccessful,
        TwitterLoginSendEmailAdressError,
        TwitterLoginSendEmailAdressSuccessful,

        TwitterAccountFollowingSuccessful,
        TwitterAccountFollowingError,
        TwitterAccountFollowingErrorThereIsNoAccount,

        TweetSharingError,
        TweetSharingSuccessful,
        TweetSharingErrorTweetPoolCanBeEmpty
    }
}
