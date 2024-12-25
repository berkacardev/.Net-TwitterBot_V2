using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Utilities;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.WindowsRegistery;
using Entity.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concreate
{
    public class ConfugrateManager : IConfugrateService
    {
        IConfugrateDal _confugrateDal;
        public ConfugrateManager()
        {
            _confugrateDal = NinjectInstanceFactory.GetInstance<IConfugrateDal>();
        }

        public int GetFollowingAccountFirstNumberValue()
        {
            int result = _confugrateDal.GetFollowingAccountFirstNumberValue();
            return result;
        }

        public int GetFollowingAccountSecondNumberValue()
        {
            int result = _confugrateDal.GetFollowingAccountSecondNumberValue();
            return result;
        }

        public int GetMaxValue()
        {
            int result = _confugrateDal.GetMaxValue();
            return result;
        }

        public int GetMinValue()
        {
            int result = _confugrateDal.GetMinValue();
            return result;
        }

        public Modems GetModem()
        {
            Modems result = _confugrateDal.GetModem();
            return result;
        }

        public bool GetRebootModeStatus()
        {
            bool result = _confugrateDal.GetRebootModeStatus();
            return result;
        }

        public void SetMaxValue(int maxValue)
        {
            _confugrateDal.SetMaxValue(maxValue);
        }

        public void SetMinValue(int minValue)
        {
            _confugrateDal.SetMinValue(minValue);
        }

        public void SetModem(Modems modem)
        {
            _confugrateDal.SetModem(modem);
        }

        public void SetRebootModeStatus(bool status)
        {
            _confugrateDal.SetRebootModeStatus(status);
        }

        public void SetFollowingAccountFirstNumberValue(int value)
        {
            _confugrateDal.SetFollowingAccountFirstNumberValue(value);
        }

        public void SetFollowingAccountSecondNumberValue(int value)
        {
            _confugrateDal.SetFollowingAccountSecondNumberValue(value);
        }

        public void SetReplayFollowing(bool status)
        {
            _confugrateDal.SetReplayFollowing(status);
        }

        public bool GetReplayFollowing()
        {
            bool result = _confugrateDal.GetReplayFollowing();
            return result;
        }

        public void SetReresetStatus(bool status)
        {
            _confugrateDal.SetReresetStatus(status);
        }

        public bool GetReresetStatus()
        {
            bool result = _confugrateDal.GetReresetStatus();
            return result;
        }

        public void SetReresetTime(int timeAsMinute)
        {
            _confugrateDal.SetReresetTime(timeAsMinute);
        }

        public int GetReresetTime()
        {
            int result = _confugrateDal.GetReresetTime();
            return result;
        }

        public void SetShareTweetStatus(bool status)
        {
            _confugrateDal.SetShareTweetStatus(status);
        }

        public bool GetShareTweetStatus()
        {
            bool result = _confugrateDal.GetShareTweetStatus();
            return result;
        }

        public void SetShareTweetNumber(int number)
        {
            _confugrateDal.SetShareTweetNumber(number);
        }

        public int GetShareTweetNumber()
        {
            int result = _confugrateDal.GetShareTweetNumber();
            return result;
        }

        public void SetShareTweetInSpecificTimeStatus(bool status)
        {
            _confugrateDal.SetShareTweetInSpecificTimeStatus(status);
        }

        public bool GetShareTweetInSpecificTimeStatus()
        {
            bool result = _confugrateDal.GetShareTweetInSpecificTimeStatus();
            return result;
        }

        public void SetTweetTextIsMediaNameStatus(bool status)
        {
            _confugrateDal.SetTweetTextIsMediaNameStatus(status);
        }

        public bool GetTweetTextIsMediaNameStatus()
        {
            bool result = _confugrateDal.GetTweetTextIsMediaNameStatus();
            return result;
        }

        public void SetWaitProcessAsMinuteStatus(bool status)
        {
            _confugrateDal.SetWaitProcessAsMinuteStatus(status);
        }

        public bool GetWaitProcessAsMinuteStatus()
        {
            bool result = _confugrateDal.GetWaitProcessAsMinuteStatus();
            return result;
        }

        public void SetWaitProcessAsMinute(int minute)
        {
            _confugrateDal.SetWaitProcessAsMinute(minute);
        }

        public int GetWaitProcessAsMinute()
        {
            int result = _confugrateDal.GetWaitProcessAsMinute();
            return result;
        }

        public void SetShareTweetWaitStatus(bool status)
        {
            _confugrateDal.SetShareTweetWaitStatus(status);
        }

        public bool GetShareTweetWaitStatus()
        {
            bool result = _confugrateDal.GetShareTweetWaitStatus();
            return result;
        }

        public void SetShareTweetWaitTime(int minute)
        {
            _confugrateDal.SetShareTweetWaitTime(minute);
        }

        public int GetShareTweetWaitTime()
        {
            int result = _confugrateDal.GetShareTweetWaitTime();
            return result;
        }

        public void SetShareTweetIfItIsInHoursStatus(bool result)
        {
            _confugrateDal.SetShareTweetIfItIsInHoursStatus(result);
        }

        public bool GetShareTweetIfItIsInHoursStatus()
        {
            bool result = _confugrateDal.GetShareTweetIfItIsInHoursStatus();
            return result;
        }

        public void SetShareTweetIfItIsInHoursFirstHours(int hour)
        {
            _confugrateDal.SetShareTweetIfItIsInHoursFirstHours(hour);
        }

        public int GetShareTweetIfItIsInHoursFirstHours()
        {
            int result = _confugrateDal.GetShareTweetIfItIsInHoursFirstHours();
            return result;
        }

        public void SetShareTweetIfItIsInHoursSecondHours(int hour)
        {
            _confugrateDal.SetShareTweetIfItIsInHoursSecondHours(hour);
        }

        public int GetShareTweetIfItIsInHoursSecondHours()
        {
            int result = _confugrateDal.GetShareTweetIfItIsInHoursSecondHours();
            return result;
        }
    }
}
