using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.EntityFramework.Context;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate.EntityFramework
{
    public class EfProcessHistory : IProcessHistoryDal
    {
        EfContext efContext;
        public EfProcessHistory()
        {
            efContext = new EfContext();
        }
        public int Add(ProcessHistory processHistory)
        {
            try
            {
                efContext.ProcessHistory.Add(processHistory);
                efContext.SaveChanges();
                int result = processHistory.ProcessId;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public bool Delete(ProcessHistory processHistory)
        {
            try
            {
                efContext.ProcessHistory.Remove(processHistory);
                efContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ProcessHistory> List()
        {
            List<ProcessHistory> processHistories = efContext.ProcessHistory.Where(u => u.ProcessStatus == true).ToList();
            processHistories.Reverse();
            return processHistories;
        }

        public bool Update(ProcessHistory processHistory)
        {
            try
            {
                int proccesId = processHistory.ProcessId;
                ProcessHistory _processHistory = efContext.ProcessHistory.Find(proccesId);

                efContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
