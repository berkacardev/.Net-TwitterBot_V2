using DataAccessLayer.Abstract;
using Entity.Concreate;
using Entity.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate.WindowsFile
{
    public class WfFile : IFileDal
    {
        public bool FileIsExist(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string SetTweetMediaFile(Tweet tweet)
        {
            try
            {
                while (true)
                {
                    string sourceFilePath = tweet.TweetMediaPath;
                    string fileName = sourceFilePath.Split('\\')[sourceFilePath.Split('\\').Length - 1];
                    string newFilePath = Directories.FILES_TWITTERBOT_MAIN_MEDIA_FILES_DIRECTORY + fileName;
                    File.Move(sourceFilePath, newFilePath);
                    return newFilePath;
                }
            }
            catch(Exception ex)
            {
                try
                {
                    while (true)
                    {
                        string[] forFileTypeList = tweet.TweetMediaPath.Split('.');
                        int forFileTypeListCount = forFileTypeList.Length;
                        string fileType = forFileTypeList[forFileTypeListCount - 1];
                        string sourceFilePath = tweet.TweetMediaPath;
                        string newFileName = CreateNewFileName() + "." + fileType;
                        string newFilePath = Directories.FILES_TWITTERBOT_MAIN_MEDIA_FILES_DIRECTORY + newFileName;
                        File.Move(sourceFilePath, newFilePath);
                        return newFilePath;
                    }
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
        private string CreateNewFileName()
        {
            string fileName = string.Empty;
            string[] characters = new string[] { "a", "b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","r","s","t","u","v","y","z","x","w"};
            for(int i=0; i<5; i++)
            {
                System.Threading.Thread.Sleep(1);
                int number = new Random().Next(1, 10);
                System.Threading.Thread.Sleep(1);
                int numberForChracterList = new Random().Next(0, characters.Length);
                fileName = fileName + characters[numberForChracterList] + number.ToString();
            }
            return fileName;
        }
    }
}
