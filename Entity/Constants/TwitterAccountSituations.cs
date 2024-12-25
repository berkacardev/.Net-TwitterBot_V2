using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Constants
{
    public enum TwitterAccountSituations
    {
        Undefined,
        Blocked,
        NeedPhoneNumber,
        NeedEmailAdress,
        TwitterLoginErrorRequireChangingPassword,
        LoginSuccessful,
        LoginError
    }
}
