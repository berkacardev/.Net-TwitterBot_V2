using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProcessHistoryDal
    {
        int Add(ProcessHistory processHistory);
        bool Update(ProcessHistory processHistory);
        bool Delete(ProcessHistory processHistory);
        List<ProcessHistory> List();
    }
}
