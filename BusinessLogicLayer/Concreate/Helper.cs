using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net;

namespace BusinessLogicLayer.Concreate
{
    public static class Helper
    {
        public static bool IsNumber(string term)
        {
            foreach (char item in term)
            {
                if (!char.IsNumber(item))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }
        public static bool IsConnected()
        {
            try
            {
                WebClient webClient = new WebClient();
                string result = webClient.DownloadString("https://www.google.com/");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static int CalculateMinuteFromDateTime(DateTime dateTime)
        {
            long passedTimeAsSeccond = (DateTime.Now.Ticks - dateTime.Ticks) / 10000000;
            long passedTimeAsMinute = passedTimeAsSeccond / 60;
            return (int)passedTimeAsMinute;
        }
        public static int ConvertFromStringToIntForHourInfo(string hourInfo)
        {
            int result = 0;
            switch (hourInfo)
            {
                case "01": result =  1; break;
                case "02": result =  2; break;
                case "03": result =  3; break;
                case "04": result =  4; break;
                case "05": result =  5; break;
                case "06": result =  6; break;
                case "07": result =  7; break;
                case "08": result =  8; break;
                case "09": result =  9; break;
                case "10": result =  10; break;
                case "11": result =  11; break;
                case "12": result =  12; break;
                case "13": result =  13; break;
                case "14": result =  14; break;
                case "15": result =  15; break;
                case "16": result =  16; break;
                case "17": result =  17; break;
                case "18": result =  18; break;
                case "19": result =  19; break;
                case "20": result =  20; break;
                case "21": result =  21; break;
                case "22": result =  22; break;
                case "23": result =  23; break;
                case "24": result =  24; break;
                default: result = -1; break;
            }
            return result;
        }
    }
}
