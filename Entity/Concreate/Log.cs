using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
    public class Log : ILog
    {
        public Log(string logMessage)
        {
            this.LogMessage = logMessage;
            this.LogDateTime = DateTime.Now;
        }
        public string LogMessage { get; set; }
        public DateTime LogDateTime { get; private set; }
    }
}
