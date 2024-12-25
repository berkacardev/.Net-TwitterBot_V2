using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
    public class ProcessHistory : IProcessHistory
    {
        [Key]
        public int ProcessId { get; set; }
        public int NumberOfLastAccount { get; set; }
        public int NumberOfFollowingAccount { get; set; }
        public DateTime ProcessDateTime { get; set; }
        public bool ProcessStatus { get; set; }
    }
}
