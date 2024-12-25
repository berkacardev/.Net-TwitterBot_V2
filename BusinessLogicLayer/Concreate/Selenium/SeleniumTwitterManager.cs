using BusinessLogicLayer.Abstract;
using Entity.Concreate;
using Entity.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concreate.Selenium
{
    public class SeleniumTwitterManager : ITwitterService
    {
        IWebDriver _webDriver;
        public SeleniumTwitterManager()
        {
            ChromeDriverService chromeDriverService = HideSeleniumConsoleSet();
            _webDriver = new ChromeDriver(chromeDriverService);
        }
        private ChromeDriverService HideSeleniumConsoleSet()
        {
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            return chromeDriverService;
        }
        private bool DocumentIsReady(IWebDriver webDriver, int timeoutSec = 20)
        {
            System.Threading.Thread.Sleep(3000);
            IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)webDriver;
            WebDriverWait wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, timeoutSec));
            try
            {
                wait.Until(u => javascriptExecutor.ExecuteScript(SeleniumCommand.TWITTER_JS_DOCUMENTISREADY_COMMAND).ToString() == SeleniumCommand.TWITTER_JS_DOCUMENTISREADY_STATUS);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void Login(TwitterAccount twitterAccount)
        {
            string accountUserName = twitterAccount.AccountUserName;
            string accountPassword = twitterAccount.AccountPassword;
            _webDriver.Navigate().GoToUrl(UrlAddresses.TWITTER_MAIN_LOGIN_URL);
            System.Threading.Thread.Sleep(5000);
            if (DocumentIsReady(_webDriver) == true)
            {
                _webDriver.FindElement(By.Name(SeleniumCommand.TWITTER_LOGIN_USERNAME_TEXT_ELEMENT_BYNAME)).SendKeys(accountUserName);
                _webDriver.FindElement(By.XPath(SeleniumCommand.TWITTER_LOGIN_CONTINUE_BUTTON_ELEMENT_BYXPATH)).Click();
            }
            if (DocumentIsReady(_webDriver) == true)
            {
                _webDriver.FindElement(By.Name(SeleniumCommand.TWITTER_LOGIN_USERPASSWORD_TEXT_ELEMENT_BYNAME)).SendKeys(accountPassword);
                _webDriver.FindElement(By.XPath(SeleniumCommand.TWITTER_LOGIN_LOGIN_BUTTON_ELEMENT_BYXPATH)).Click();
            }
        }
        public bool Follow(TwitterAccountToFollow twitterAccountToFollow, int minValue, int maxValue)
        {
            Random random = new Random();
            int extraTimeToFollowProcess = random.Next(minValue, maxValue);
            string accountToFollowUserName = twitterAccountToFollow.AccountToFollowUserName;
            _webDriver.Navigate().GoToUrl(UrlAddresses.TWITTER_MAIN_URL + accountToFollowUserName);
            if (DocumentIsReady(_webDriver) == true && Helper.IsConnected())
            {
                System.Threading.Thread.Sleep(2000 + extraTimeToFollowProcess);
                _webDriver.FindElement(By.XPath(SeleniumCommand.TWITTER_FOLLOW_FOLLOW_BUTTON_ELEMENT_BYXPATH)).Click();
                System.Threading.Thread.Sleep(2500);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsLogin()
        {
            System.Threading.Thread.Sleep(2000);
            string url = _webDriver.Url;
            if (url == UrlAddresses.TWITTER_MAIN_HOME_PAGE_URL)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool FollowingAccountExistOrBlocked(TwitterAccountToFollow twitterAccountToFollow)
        {
            string accountToFollowUserName = twitterAccountToFollow.AccountToFollowUserName;
            _webDriver.Navigate().GoToUrl(UrlAddresses.TWITTER_MAIN_URL + accountToFollowUserName);
            if (DocumentIsReady(_webDriver) == true)
            {
                System.Threading.Thread.Sleep(2200);
                List<IWebElement> webElements = _webDriver.FindElements(By.XPath(SeleniumCommand.TWITTER_ACCOUNT_STATUS_ELEMENT_BYXPATH)).ToList();
                foreach (var item in webElements)
                {
                    if (item.Text == SeleniumCommand.TWITTER_ACCOUNT_STATUS_NOEXIST_TR || item.Text == SeleniumCommand.TWITTER_ACCOUNT_STATUS_NOEXIST_EN || item.Text == SeleniumCommand.TWITTER_ACCOUNT_STATUS_BLOCKED_TR || item.Text == SeleniumCommand.TWITTER_ACCOUNT_STATUS_BLOCKED_EN)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public void LogOut()
        {
            List<Cookie> cookies = _webDriver.Manage().Cookies.AllCookies.ToList();
            _webDriver.Quit();
        }
        public TwitterAccountSituations TwitterAccountStatus()
        {
            while (true)
            {
                if (DocumentIsReady(_webDriver))
                {
                    break;
                }
            }
            string status = string.Empty;
            try
            {
                status = _webDriver.FindElement(By.XPath(SeleniumCommand.TWITTER_YOUR_ACCOUNT_STATUS_ELEMENT_BYPATH)).Text;
            }
            catch
            {
                status = _webDriver.FindElement(By.XPath(SeleniumCommand.TWITTER_YOUR_ACCOUNT_STATUS_INLOGIN_ELEMENT_BYPATH)).Text;
                if (status == SeleniumCommand.TWITTER_ACCOUNT_STATUS_REQUIRE_INFO_ABOOT_ACCOUNT_TR)
                {
                    try
                    {
                        foreach (var item in _webDriver.FindElements(By.XPath(SeleniumCommand.TWITTER_YOUR_ACCOUNT_STATUS_INLOGIN_THING_REQUIRE_PHONE_NUMBER_ELEMENT_BYPATH)))
                        {
                            string result = item.Text;
                            if (result.Contains(SeleniumCommand.TWITTER_ACCOUNT_STATUS_REQUIRE_INFO_ABOOT_ACCOUNT_REQUIRE_PHONE_NUMBER_TR))
                            {
                                status = SeleniumCommand.TWITTER_ACCOUNT_STATUS_REQUIRE_INFO_ABOOT_ACCOUNT_REQUIRE_PHONE_NUMBER_TR;
                                break;
                            }
                        }
                        foreach (var item in _webDriver.FindElements(By.XPath(SeleniumCommand.TWITTER_YOUR_ACCOUNT_STATUS_INLOGIN_THING_REQUIRE_PHONE_NUMBER_ELEMENT_BYPATH)))
                        {
                            string result = item.Text;
                            if (result.Contains(SeleniumCommand.TWITTER_ACCOUNT_STATUS_REQUIRE_INFO_ABOOT_ACCOUNT_REQUIRE_EMAIL_ADRESS_TR))
                            {
                                status = SeleniumCommand.TWITTER_ACCOUNT_STATUS_REQUIRE_INFO_ABOOT_ACCOUNT_REQUIRE_EMAIL_ADRESS_TR;
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
            string pageUrl = _webDriver.Url;
            if (status == SeleniumCommand.TWITTER_YOUR_ACCOUNT_STATUS_BLOCKED_TR && pageUrl == UrlAddresses.TWITTER_BLOCKED_ACCOUNT_URL)
            {
                return TwitterAccountSituations.Blocked;
            }
            else if (status == SeleniumCommand.TWITTER_YOUR_ACCOUNT_STATUS_REQUIRE_CHANGING_PASSWORD_TR)
            {
                return TwitterAccountSituations.TwitterLoginErrorRequireChangingPassword;
            }
            else if (status == SeleniumCommand.TWITTER_ACCOUNT_STATUS_REQUIRE_INFO_ABOOT_ACCOUNT_REQUIRE_PHONE_NUMBER_TR)
            {
                return TwitterAccountSituations.NeedPhoneNumber;
            }
            else if(status == SeleniumCommand.TWITTER_ACCOUNT_STATUS_REQUIRE_INFO_ABOOT_ACCOUNT_REQUIRE_EMAIL_ADRESS_TR)
            {
                return TwitterAccountSituations.NeedEmailAdress;
            }
            else
            {
                return TwitterAccountSituations.Undefined;
            }
        }

        public bool ShareTweet(Tweet tweet)
        {
            string tweetText = tweet.TweetText;
            string tweetMediaPath = tweet.TweetMediaPath;
            try
            {
                System.Threading.Thread.Sleep(120);
                _webDriver.Navigate().GoToUrl(UrlAddresses.TWITTER_MAIN_HOME_PAGE_URL);
                System.Threading.Thread.Sleep(150);
                if (_webDriver.Url != UrlAddresses.TWITTER_MAIN_HOME_PAGE_URL)
                {
                    _webDriver.Navigate().GoToUrl(UrlAddresses.TWITTER_MAIN_URL);
                }
                if (DocumentIsReady(_webDriver) == true)
                {
                    _webDriver.FindElement(By.XPath(SeleniumCommand.TWITTER_SHARE_TWEET_TEXT_ELEMENT_BYXPATH)).Click();
                    System.Threading.Thread.Sleep(1000);
                    if (tweetText != string.Empty && tweet.TweetText != null)
                    {
                        _webDriver.FindElement(By.XPath(SeleniumCommand.TWITTER_SHARE_TWEET_TEXT_ELEMENT_BYXPATH)).SendKeys(tweetText);
                    }
                    if (tweetMediaPath != string.Empty)
                    {
                        if (File.Exists(tweetMediaPath))
                        {
                            System.Threading.Thread.Sleep(100);
                            _webDriver.FindElement(By.XPath(SeleniumCommand.TWITTER_SHARE_TWEETMEDIA_FILE_ELEMENT_BYXPATH)).SendKeys(tweetMediaPath);
                            System.Threading.Thread.Sleep(10000);
                        }
                    }
                    System.Threading.Thread.Sleep(100);
                    _webDriver.FindElement(By.XPath(SeleniumCommand.TWITTER_SHARE_TWEET_BUTTON_ELEMENT_BYXPATH)).Click();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TweetIsShared(bool isHaveMedia)
        {

            if (isHaveMedia)
            {
                try
                {
                    string result = _webDriver.FindElement(By.XPath(SeleniumCommand.TWITTER_SHARE_TWEETMEDIA_FILE_IMAGE_ELEMENT_BYXPATH)).ToString();
                    return false;
                }
                catch
                {
                    return true;
                }
            }
            else
            {
                try
                {
                    string webElementText = _webDriver.FindElement(By.XPath(SeleniumCommand.TWITTER_SHARE_TWEET_TEXT_SPAN_ELEMENT_BYXPATH_TWEET_TEXT_ELEMENT)).ToString();
                    return false;
                }
                catch
                {
                    return true;
                }
            }
        }      
        public bool ChangeAccountPassword(TwitterAccount twitterAccount)
        {
            //try
            //{
            //    if(DocumentIsReady(_webDriver) && Helper.IsConnected())
            //    {
            //        _webDriver.FindElement(By.XPath(SeleniumCommand.TWITTER_ACCOUNT_CHANGE_PASSWORD_IN_REQUIRE_CHANGING_PASSWORD_BUTTON_ELEMENT_BYXPATH)).Click();
            //    }
            //    return true;
            //}
            //catch
            //{
            //    return true;
            //}
            return true;
        }

        public bool SendPhonNumberToVerifyInLogin(TwitterAccount twitterAccount)
        {
            if (DocumentIsReady(_webDriver) && Helper.IsConnected())
            {
                try
                {
                    string phoneNumber = twitterAccount.AccountPhoneNumber;
                    if (phoneNumber != null && phoneNumber != string.Empty)
                    {
                        _webDriver.FindElement(By.XPath(SeleniumCommand.TWITTER_YOUR_ACCOUNT_TEXT_INLOGIN_THING_REQUIRE_PHONE_NUMBER_ELEMENT_BYPATH)).SendKeys(phoneNumber);
                        System.Threading.Thread.Sleep(500);
                        _webDriver.FindElement(By.XPath(SeleniumCommand.TWITTER_YOUR_ACCOUNT_BUTTON_INLOGIN_THING_REQUIRE_PHONE_NUMBER_ELEMENT_BYPATH)).Click();
                        System.Threading.Thread.Sleep(1000);
                        if(_webDriver.Url == UrlAddresses.TWITTER_MAIN_HOME_PAGE_URL)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            return false;
        }
        public bool SendMailAdressToVerifyInLogin(TwitterAccount twitterAccount)
        {
            if (DocumentIsReady(_webDriver) && Helper.IsConnected())
            {
                try
                {
                    string mailAdress = twitterAccount.AccountEmailAddress;
                    if (mailAdress != null && mailAdress != string.Empty)
                    {
                        _webDriver.FindElement(By.XPath(SeleniumCommand.TWITTER_YOUR_ACCOUNT_TEXT_INLOGIN_THING_REQUIRE_PHONE_NUMBER_ELEMENT_BYPATH)).SendKeys(mailAdress);
                        System.Threading.Thread.Sleep(500);
                        _webDriver.FindElement(By.XPath(SeleniumCommand.TWITTER_YOUR_ACCOUNT_BUTTON_INLOGIN_THING_REQUIRE_PHONE_NUMBER_ELEMENT_BYPATH)).Click();
                        System.Threading.Thread.Sleep(1000);
                        if (_webDriver.Url == UrlAddresses.TWITTER_MAIN_HOME_PAGE_URL)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw ex;

                }
            }
            return false;
        }
    }
}
