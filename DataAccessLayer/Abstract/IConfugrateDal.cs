using Entity.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IConfugrateDal
    {
        int GetMinValue();
        void SetMinValue(int minValue);
        int GetMaxValue();
        void SetMaxValue(int minValue);
        Modems GetModem();
        void SetModem(Modems modem);
        bool GetRebootModeStatus();
        void SetRebootModeStatus(bool status);
        int GetFollowingAccountFirstNumberValue();
        int GetFollowingAccountSecondNumberValue();
        void SetFollowingAccountFirstNumberValue(int value);
        void SetFollowingAccountSecondNumberValue(int value);
        void SetReplayFollowing(bool status);
        bool GetReplayFollowing();
        void SetReresetStatus(bool status);
        bool GetReresetStatus();
        void SetReresetTime(int timeAsMinute);
        int GetReresetTime();
        void SetShareTweetStatus(bool status);
        bool GetShareTweetStatus();
        void SetShareTweetNumber(int number);
        int GetShareTweetNumber();
        void SetShareTweetInSpecificTimeStatus(bool status);
        bool GetShareTweetInSpecificTimeStatus();
        void SetTweetTextIsMediaNameStatus(bool status);
        bool GetTweetTextIsMediaNameStatus();
        void SetWaitProcessAsMinuteStatus(bool status);
        bool GetWaitProcessAsMinuteStatus();
        void SetWaitProcessAsMinute(int minute);
        int GetWaitProcessAsMinute();
        void SetShareTweetWaitStatus(bool status);
        bool GetShareTweetWaitStatus();
        void SetShareTweetWaitTime(int minute);
        int GetShareTweetWaitTime();
        void SetShareTweetIfItIsInHoursStatus(bool result);
        bool GetShareTweetIfItIsInHoursStatus();
        void SetShareTweetIfItIsInHoursFirstHours(int hour);
        int GetShareTweetIfItIsInHoursFirstHours();
        void SetShareTweetIfItIsInHoursSecondHours(int hour);
        int GetShareTweetIfItIsInHoursSecondHours();
    }
}
