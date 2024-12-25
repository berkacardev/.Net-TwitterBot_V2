using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Utilities;
using DataAccessLayer.Abstract;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concreate
{
    public class ProcessHistoryManager : IProcessHistoryService
    {
        IProcessHistoryDal _processHistoryDal;
        public ProcessHistoryManager()
        {
            _processHistoryDal = NinjectInstanceFactory.GetInstance<IProcessHistoryDal>();
        }
        public int Add(ProcessHistory processHistory)
        {
            int result = _processHistoryDal.Add(processHistory);
            return result;
        }

        public bool Delete(ProcessHistory processHistory)
        {
            bool result = _processHistoryDal.Delete(processHistory);
            return result;
        }

        public List<ProcessHistory> List()
        {
            List<ProcessHistory> processHistories = _processHistoryDal.List();
            return processHistories;
        }

        public bool Update(ProcessHistory processHistory)
        {
            bool result = _processHistoryDal.Update(processHistory);
            return result;
        }
    }
}
