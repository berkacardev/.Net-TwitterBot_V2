using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Concreate.Selenium;
using Entity.Concreate;
using Entity.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concreate
{
    public class TwitterProcessManager : ITwitterProcessService
    {
        IModemService _modemService;
        ITwitterAccountService _twitterAccountService;
        IProcessHistoryService _processHistoryService;
        ITwitterService _twitterService;
        private DateTime modemResetTime { get; set; }
        public TwitterProcessManager()
        {
            modemResetTime = DateTime.MinValue;


            _twitterAccountService = new TwitterAccountManager();
            _processHistoryService = new ProcessHistoryManager();
            _twitterService = new SeleniumTwitterManager();
        }
        public void RebootModem(Modems modem)
        {
            modemResetTime = DateTime.Now;
            switch (modem)
            {
                case Modems.Keenetic: _modemService = new KeeneticModemManager(); break;
                case Modems.TpLink: _modemService = new TpLinkModemManager(); break;
                case Modems.Android_Mobile: _modemService = new MobileAndroidModemManager(); break;
                default: _modemService = null; break;
            }
            _modemService.Reboot();
            throw new Exception("Modem Resetlendi");
        }

        public void ReRebootModem(Modems modem, int reRebootTimeAsMinute)
        {
            int passedTimeAsMinute = 0;
            if (DateTime.Now.Hour - modemResetTime.Hour > 0)
            {
                passedTimeAsMinute = 60 - modemResetTime.Minute + DateTime.Now.Minute;
            }
            else
            {
                passedTimeAsMinute = DateTime.Now.Minute - modemResetTime.Minute;
            }

            if (passedTimeAsMinute >= reRebootTimeAsMinute)
            {
                RebootModem(modem);
            }
        }

        public bool InternetIsConnected()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(10000);
                if (Helper.IsConnected())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public ProcessHistory CrateProcessHistory()
        {
            ProcessHistory lastProcessHistory = null;
            List<ProcessHistory> processHistories = _processHistoryService.List().Where(u => u.ProcessStatus == true).ToList();
            if (processHistories.Count > 0)
            {
                lastProcessHistory = processHistories[processHistories.Count - 1];
            }
            else
            {
                _processHistoryService = new ProcessHistoryManager();
                int proccessId = _processHistoryService.Add(new ProcessHistory() { ProcessDateTime = DateTime.Now, ProcessStatus = true });
                lastProcessHistory = _processHistoryService.List().Find(u => u.ProcessId == proccessId);
            }
            return lastProcessHistory;
        }
        public int DetermineAccountCountToFollow(int minValue, int maxValue)
        {
            int countToFollowAccount = new Random().Next(minValue, maxValue);
            return countToFollowAccount;
        }
        public void StartToProcess(int minValue, int maxValue, int countOfTwitterAccount, bool modemRerebootStatus, int modemRerebootTime, bool isReplay)
        {
            List<TwitterAccount> twitterAccounts = _twitterAccountService.List();
            ProcessHistory processHistory = CrateProcessHistory();

            int countToFollowAccount = DetermineAccountCountToFollow(minValue, maxValue);
            while (true)
            {
                int j = 0;
                if (processHistory.NumberOfLastAccount != 0)
                {
                    j = processHistory.NumberOfLastAccount;
                }
                for (int i = j; i < countOfTwitterAccount; i++)
                {

                }
                if (isReplay == true)
                {
                    continue;
                }
                else
                {
                    throw new Exception("İşlem Bitti");
                }
            }
        }
        public void LoginAndFollow(int countToFollowAccount)
        {
            //    List<TwitterAccount>
            //    while (true)
            //    {
            //        if (InternetIsConnected())
            //        {
            //            break;
            //        }

        }
    }
}

