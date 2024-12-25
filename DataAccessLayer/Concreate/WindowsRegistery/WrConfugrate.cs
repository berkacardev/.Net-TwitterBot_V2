using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Entity.Constants;

namespace DataAccessLayer.Concreate.WindowsRegistery
{
    public class WrConfugrate : IConfugrateDal
    {
        RegistryKey registryKey;
        public int GetMaxValue()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            int maxValue = Convert.ToInt32(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_MAXVALUE));
            return maxValue;
        }

        public int GetMinValue()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            int minValue = Convert.ToInt32(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_MINVALUE));
            return minValue;
            
        }

        public void SetMaxValue(int minValue)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_MAXVALUE, minValue);
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_MAXVALUE, minValue);
                }
            }
        }

        public void SetMinValue(int minValue)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_MINVALUE, minValue);
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_MINVALUE, minValue);
                }
            }
        }
        private bool ExistDirectery()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN,true);
            if (registryKey != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CreateDirectory()
        {
            try
            {
                registryKey = Registry.CurrentUser.CreateSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN,true);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Modems GetModem()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            Modems modem = (Modems)Convert.ToInt32(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_MODEM));
            return modem;
        }

        public void SetModem(Modems modem)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_MODEM, (int)modem);
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_MODEM, (int)modem);
                }
            }
        }

        public bool GetRebootModeStatus()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            bool status = Convert.ToBoolean(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_REBOOT_MODEM_STATUS));
            return status;
        }

        public void SetRebootModeStatus(bool status)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_REBOOT_MODEM_STATUS, Convert.ToInt32(status));
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_REBOOT_MODEM_STATUS, Convert.ToInt32(status));
                }
            }
        }

        public int GetFollowingAccountFirstNumberValue()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            int result = Convert.ToInt32(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_ACCOUNT_FIRST_NUMBER));
            return result;
        }

        public int GetFollowingAccountSecondNumberValue()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            int result = Convert.ToInt32(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_ACCOUNT_SECOND_NUMBER));
            return result;
        }
        public void SetFollowingAccountFirstNumberValue(int value)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_ACCOUNT_FIRST_NUMBER, Convert.ToInt32(value));
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_ACCOUNT_FIRST_NUMBER, Convert.ToInt32(value));
                }
            }
        }

        public void SetFollowingAccountSecondNumberValue(int value)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_ACCOUNT_SECOND_NUMBER, Convert.ToInt32(value));
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_ACCOUNT_SECOND_NUMBER, Convert.ToInt32(value));
                }
            }
        }

        public void SetReplayFollowing(bool status)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_ACCOUNT_REPLAY_STATUS, Convert.ToInt32(status));
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_ACCOUNT_SECOND_NUMBER, Convert.ToInt32(status));
                }
            }
        }

        public bool GetReplayFollowing()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            bool result = Convert.ToBoolean(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_ACCOUNT_REPLAY_STATUS));
            return result;
        }

        public void SetReresetStatus(bool status)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_ACCOUNT_MODEM_RERESET_STATUS, Convert.ToInt32(status));
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_ACCOUNT_MODEM_RERESET_STATUS, Convert.ToInt32(status));
                }
            }
        }

        public bool GetReresetStatus()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            bool result = Convert.ToBoolean(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_ACCOUNT_MODEM_RERESET_STATUS));
            return result;
        }

        public void SetReresetTime(int timeAsMinute)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_ACCOUNT_MODEM_RERESET_TIME, timeAsMinute);
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_ACCOUNT_MODEM_RERESET_TIME, timeAsMinute);
                }
            }
        }

        public int GetReresetTime()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            int result = Convert.ToInt32(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_ACCOUNT_MODEM_RERESET_TIME));
            return result;
        }

        public void SetShareTweetStatus(bool status)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_STATUS, status);
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_STATUS, status);
                }
            }
        }

        public bool GetShareTweetStatus()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            bool result = Convert.ToBoolean(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_STATUS));
            return result;
        }

        public void SetShareTweetNumber(int number)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_NUMBER, number);
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_NUMBER, number);
                }
            }
        }

        public int GetShareTweetNumber()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            int result = Convert.ToInt32(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_NUMBER));
            return result;
        }

        public void SetShareTweetInSpecificTimeStatus(bool status)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_IN_SPECIFIC_TIME_STATUS, status);
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_IN_SPECIFIC_TIME_STATUS, status);
                }
            }
        }

        public bool GetShareTweetInSpecificTimeStatus()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            bool result = Convert.ToBoolean(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_IN_SPECIFIC_TIME_STATUS));
            return result;
        }
        public void SetTweetTextIsMediaNameStatus(bool status)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_TWEET_TEXT_IS_MEDIAFILENAME_STATUS, status);
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_TWEET_TEXT_IS_MEDIAFILENAME_STATUS, status);
                }
            }
        }

        public bool GetTweetTextIsMediaNameStatus()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            bool result = Convert.ToBoolean(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_TWEET_TEXT_IS_MEDIAFILENAME_STATUS));
            return result;
        }

        public void SetWaitProcessAsMinuteStatus(bool status)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_PROCESS_WAIT_ASMINUTE_STATUS, status);
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_PROCESS_WAIT_ASMINUTE_STATUS, status);
                }
            }
        }

        public bool GetWaitProcessAsMinuteStatus()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            bool result = Convert.ToBoolean(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_PROCESS_WAIT_ASMINUTE_STATUS));
            return result;
        }

        public void SetWaitProcessAsMinute(int minute)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_PROCESS_WAIT_ASMINUTE_TIME, minute);
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_PROCESS_WAIT_ASMINUTE_TIME, minute);
                }
            }
        }

        public int GetWaitProcessAsMinute()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            int result = Convert.ToInt32(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_NAME_FOLLOWING_PROCESS_WAIT_ASMINUTE_TIME));
            return result;
        }

        public void SetShareTweetWaitStatus(bool status)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_WAITING_TIME_STATUS, status);
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_WAITING_TIME_STATUS, status);
                }
            }
        }

        public bool GetShareTweetWaitStatus()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            bool result = Convert.ToBoolean(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_WAITING_TIME_STATUS));
            return result;
        }

        public void SetShareTweetWaitTime(int minute)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_WAITING_TIME, minute);
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_WAITING_TIME, minute);
                }
            }
        }
        public int GetShareTweetWaitTime()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            int result = Convert.ToInt32(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_WAITING_TIME));
            return result;
        }

        public void SetShareTweetIfItIsInHoursStatus(bool result)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_CONVENIENT_TIME_STATUS, result);
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_CONVENIENT_TIME_STATUS, result);
                }
            }
        }

        public bool GetShareTweetIfItIsInHoursStatus()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            bool result = Convert.ToBoolean(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_CONVENIENT_TIME_STATUS));
            return result;
        }

        public void SetShareTweetIfItIsInHoursFirstHours(int hour)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_CONVENIENT_FIRST_TIME, hour);
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_CONVENIENT_FIRST_TIME, hour);
                }
            }
        }

        public int GetShareTweetIfItIsInHoursFirstHours()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            int result = Convert.ToInt32(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_CONVENIENT_FIRST_TIME));
            return result;
        }

        public void SetShareTweetIfItIsInHoursSecondHours(int hour)
        {
            if (ExistDirectery())
            {
                registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_CONVENIENT_LAST_TIME, hour);
            }
            else
            {
                if (CreateDirectory())
                {
                    registryKey.SetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_CONVENIENT_LAST_TIME, hour);
                }
            }
        }

        public int GetShareTweetIfItIsInHoursSecondHours()
        {
            registryKey = Registry.CurrentUser.OpenSubKey(Directories.WINDOWSREGESTIRY_DIRECTORY_MAIN);
            int result = Convert.ToInt32(registryKey.GetValue(Directories.WINDOWSREGESTIRY_VARIABLE_SHARE_TWEET_CONVENIENT_LAST_TIME));
            return result;
        }
    }
}
