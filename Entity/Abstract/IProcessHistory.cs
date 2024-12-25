using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Abstract
{
    public interface IProcessHistory
    {
        int ProcessId { get; set; }
        int NumberOfLastAccount { get; set; }
        int NumberOfFollowingAccount { get; set; }
        DateTime ProcessDateTime { get; set; }
        bool ProcessStatus { get; set; }
    }
}
