using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Concreate;
using BusinessLogicLayer.Concreate.Selenium;
using Entity.Concreate;
using Entity.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterfaceWF.Utilities;
namespace UserInterfaceWF
{
    public partial class TwitterBot : Form
    {
        ITwitterAccountService _twitterAccountService;
        ITwitterAccountToFollowService _twitterAccountToFollowService;
        ITwitterService _twitterService;
        IConfugrateService _confugrateService;
        IFollowedAccountService _followedAccountService;
        IModemService _modemService;
        ITweetService _tweetService;
        IProcessHistoryService _processHistoryService;
        ISharedTweetService _sharedTweetService;
        ITweetSharedTimeService _tweetSharedTimeService;

        TwitterProcessManager twitterProcessManager;

        MainProcesses mainProcesses = new MainProcesses();
        DateTime modemResetTime = DateTime.MinValue;
        DateTime processFinishTime = DateTime.MinValue;
        DateTime tweetSharedTime = DateTime.MinValue;
        public TwitterBot()
        {
            _twitterAccountService = NinjectInstanceFactory.GetInstance<ITwitterAccountService>();
            _twitterAccountToFollowService = NinjectInstanceFactory.GetInstance<ITwitterAccountToFollowService>();
            _confugrateService = NinjectInstanceFactory.GetInstance<IConfugrateService>();
            _followedAccountService = NinjectInstanceFactory.GetInstance<IFollowedAccountService>();
            _tweetService = NinjectInstanceFactory.GetInstance<ITweetService>();
            _processHistoryService = NinjectInstanceFactory.GetInstance<IProcessHistoryService>();
            _tweetSharedTimeService = NinjectInstanceFactory.GetInstance<ITweetSharedTimeService>();
            _sharedTweetService = NinjectInstanceFactory.GetInstance<ISharedTweetService>();
            Control.CheckForIllegalCrossThreadCalls = false; // thread hatası almayı önlemek için silme !!!
            InitializeComponent();
        }
        private void TwitterBot_Load(object sender, EventArgs e)
        {
            FillTwitterAccountListBox();
            FillTwitterAccountToFollowListBox();
            FillModemList();
            FillTweetsListBox();
            SetStartingValues();
            //FillTweetSharedTimeList();
        }
        internal void AddTwitterAccount()
        {
            try
            {
                mainProcesses.AddTwitterAccount(txt_UserName, txt_UserPassword, txt_UserEmail, txt_UserPhoneNumber);
                mainProcesses.FillTwitterAccountListBox(lstbox_TwitterAccounts);
                mainProcesses.SetCountOfTwitterAccount(lbl_TwitterAccountsNumbers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        internal void DeleteTwitterAccount(object sender)
        {
            mainProcesses.DeleteTwitterAccount(sender);
            mainProcesses.FillTwitterAccountListBox(lstbox_TwitterAccounts);
            mainProcesses.SetCountOfTwitterAccount(lbl_TwitterAccountsNumbers);
        }
        internal void FillTwitterAccountListBox()
        {
            try
            {
                mainProcesses.FillTwitterAccountListBox(lstbox_TwitterAccounts);
                mainProcesses.SetCountOfTwitterAccount(lbl_TwitterAccountsNumbers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        internal void AddTwitterAccountToFollow()
        {
            try
            {
                mainProcesses.AddTwitterAccountToFollow(txt_TwitterAccountToFollow, progressBar_AddTwitterAccountsToFollow, lbl_AddTwitterAccountsToFollowRate);
                mainProcesses.FillTwitterAccountToFollowListBox(lstbox_TwitterAccountsToFollow);
                mainProcesses.SetCountOfTwitterAccountToFollow(lbl_TwitterAccountToFollowNumbers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        internal void DeleteTwitterAccountToFollow(object sender)
        {
            mainProcesses.DeleteTwitterAccountToFollow(sender);
            mainProcesses.FillTwitterAccountToFollowListBox(lstbox_TwitterAccountsToFollow);
            mainProcesses.SetCountOfTwitterAccountToFollow(lbl_TwitterAccountToFollowNumbers);
        }
        internal void FillTwitterAccountToFollowListBox()
        {
            try
            {
                mainProcesses.FillTwitterAccountToFollowListBox(lstbox_TwitterAccountsToFollow);
                mainProcesses.SetCountOfTwitterAccountToFollow(lbl_TwitterAccountToFollowNumbers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddTweet()
        {
            try
            {
                mainProcesses.AddTweet(txt_TweetText, opfd_SelectMediaFile);
                mainProcesses.FillTweetsListBox(dgw_Tweets);
                mainProcesses.SetCountOfTweet(lbl_TotalTweetNumber);
                mainProcesses.RemoveSelectedFile(btn_RemoveSelectedFile, opfd_SelectMediaFile, lbl_SelectedFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillTweetsListBox()
        {
            try
            {
                mainProcesses.FillTweetsListBox(dgw_Tweets);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SetCountOfTweet()
        {
            mainProcesses.SetCountOfTweet(lbl_TotalTweetNumber);
        }
        private void SetListboxNumbers()
        {
            mainProcesses.SetCountOfTwitterAccount(lbl_TwitterAccountsNumbers);
            mainProcesses.SetCountOfTwitterAccountToFollow(lbl_TwitterAccountToFollowNumbers);
        }
        private void SetStartingValues()
        {
            try
            {
                txt_MinValue.Text = _confugrateService.GetMinValue().ToString();
                txt_MaxValue.Text = _confugrateService.GetMaxValue().ToString();
                cmb_ModemBrandModel.SelectedIndex = (int)_confugrateService.GetModem();
                chck_AllowRebootModem.Checked = _confugrateService.GetRebootModeStatus();
                txt_Following_Account_NumberFirst.Text = _confugrateService.GetFollowingAccountFirstNumberValue().ToString();
                txt_Following_Account_NumberSecond.Text = _confugrateService.GetFollowingAccountSecondNumberValue().ToString();
                chck_FollowProcessContinue.Checked = _confugrateService.GetReplayFollowing();
                chck_ReresetModem.Checked = _confugrateService.GetReresetStatus();
                txt_ReresetModemMinute.Text = _confugrateService.GetReresetTime().ToString();
                chck_ShareTweetForAllAccount.Checked = _confugrateService.GetShareTweetStatus();
                txt_ShareTweetNumber.Text = _confugrateService.GetShareTweetNumber().ToString();
                chck_TweetTextIsSameFileName.Checked = _confugrateService.GetTweetTextIsMediaNameStatus();
                chck_FollowProcessContinueWaitingMiunte.Checked = _confugrateService.GetWaitProcessAsMinuteStatus();
                txt_FollowProcessContinueWaitingMiunte.Text = _confugrateService.GetWaitProcessAsMinute().ToString();
                chck_ShareTweetWaitMinute.Checked = _confugrateService.GetShareTweetWaitStatus();
                txt_ShareTweetWaitMinute.Text = _confugrateService.GetShareTweetWaitTime().ToString();
                chck_ShareTweetIfItIsInHours.Checked = _confugrateService.GetShareTweetIfItIsInHoursStatus();
                cmb_ShareTweetIfItIsInHoursFirstHours.SelectedIndex = _confugrateService.GetShareTweetIfItIsInHoursFirstHours();
                cmb_ShareTweetIfItIsInHoursLastHours.SelectedIndex = _confugrateService.GetShareTweetIfItIsInHoursSecondHours();
                SetListboxNumbers();
                SetCountOfTweet();
            }
            catch
            {

            }
        } //refrec
        private void FormClosingProcess()
        {
            try
            {
                if (_twitterService != null)
                {
                    _twitterService.LogOut();
                }
                int minValue = Convert.ToInt32(txt_MinValue.Text);
                int maxValue = Convert.ToInt32(txt_MaxValue.Text);
                _confugrateService.SetMinValue(minValue);
                _confugrateService.SetMaxValue(maxValue);
                Modems modem = (Modems)cmb_ModemBrandModel.SelectedIndex;
                _confugrateService.SetModem(modem);
                bool allowRebootModemStatus = chck_AllowRebootModem.Checked;
                _confugrateService.SetRebootModeStatus(allowRebootModemStatus);
                int followingAccountFirstNumber = Convert.ToInt32(txt_Following_Account_NumberFirst.Text);
                _confugrateService.SetFollowingAccountFirstNumberValue(followingAccountFirstNumber);
                int followingAccountSecondNumber = Convert.ToInt32(txt_Following_Account_NumberSecond.Text);
                _confugrateService.SetFollowingAccountSecondNumberValue(followingAccountSecondNumber);
                bool replayFollowingProecessStatus = chck_FollowProcessContinue.Checked;
                _confugrateService.SetReplayFollowing(replayFollowingProecessStatus);
                bool reresetModemStatus = chck_ReresetModem.Checked;
                _confugrateService.SetReresetStatus(reresetModemStatus);
                int reresetModemTimeAsMinute = Convert.ToInt32(txt_ReresetModemMinute.Text);
                _confugrateService.SetReresetTime(reresetModemTimeAsMinute);
                bool shareTweetStatus = chck_ShareTweetForAllAccount.Checked;
                _confugrateService.SetShareTweetStatus(shareTweetStatus);
                int shareTweetNumber = Convert.ToInt32(txt_ShareTweetNumber.Text);
                _confugrateService.SetShareTweetNumber(shareTweetNumber);
                bool tweetTextIsMediaName = chck_TweetTextIsSameFileName.Checked;
                _confugrateService.SetTweetTextIsMediaNameStatus(tweetTextIsMediaName);
                bool processWaitStatus = chck_FollowProcessContinueWaitingMiunte.Checked;
                _confugrateService.SetWaitProcessAsMinuteStatus(processWaitStatus);
                int processWaitTime = Convert.ToInt32(txt_FollowProcessContinueWaitingMiunte.Text);
                _confugrateService.SetWaitProcessAsMinute(processWaitTime);
                bool shareTweetWaitMinuteStatus = chck_ShareTweetWaitMinute.Checked;
                _confugrateService.SetShareTweetWaitStatus(shareTweetWaitMinuteStatus);
                int shareTweetWaitMinute = Convert.ToInt32(txt_ShareTweetWaitMinute.Text);
                _confugrateService.SetShareTweetWaitTime(shareTweetWaitMinute);
                bool shareTweetIfItIsInHours = chck_ShareTweetIfItIsInHours.Checked;
                _confugrateService.SetShareTweetIfItIsInHoursStatus(shareTweetIfItIsInHours);
                int shareTweetIfItIsInHoursFirstHours = cmb_ShareTweetIfItIsInHoursFirstHours.SelectedIndex;
                _confugrateService.SetShareTweetIfItIsInHoursFirstHours(shareTweetIfItIsInHoursFirstHours);
                int shareTweetIfItIsInHoursLastHours = cmb_ShareTweetIfItIsInHoursLastHours.SelectedIndex;
                _confugrateService.SetShareTweetIfItIsInHoursSecondHours(shareTweetIfItIsInHoursLastHours);
            }
            catch
            {

            }
        } //refrec
        private void FillModemList()
        {
            List<Modems> modems = Enum.GetValues(typeof(Modems)).Cast<Modems>().ToList();
            cmb_ModemBrandModel.DataSource = modems;
        }
        private void SetFollowingProcess(ProcessStatus status)
        {

            switch (status)
            {
                case ProcessStatus.OnProcess:
                    lbl_FollowingProcessStatus.Text = "İşlemde";
                    lbl_FollowingProcessStatus.ForeColor = Color.Green;
                    break;
                case ProcessStatus.ProcessIsFinish:
                    lbl_FollowingProcessStatus.Text = "Bitti";
                    lbl_FollowingProcessStatus.ForeColor = Color.Red;
                    break;
                case ProcessStatus.WaitingTime:
                    lbl_FollowingProcessStatus.Text = "Bekliyor";
                    lbl_FollowingProcessStatus.ForeColor = Color.Orange;
                    break;
            }
        }



        private TwitterAccountSituations LoginToAccount(ProcessHistory processHistory, TwitterAccount twitterAccount)
        {
            string userName = twitterAccount.AccountUserName;
            ConnectControl();
            try
            {
                ConnectControl();
                _twitterService = NinjectInstanceFactory.GetInstance<ITwitterService>();
                _twitterService.Login(twitterAccount);
                if (_twitterService.IsLogin())
                {
                    mainProcesses.LogProcess(LogStatus.TwitterLoginSuccessful, txt_MainLogs, ("--->" + userName));
                    return TwitterAccountSituations.LoginSuccessful;
                }
                else
                {
                    TwitterAccountSituations twitterAccountSituation = _twitterService.TwitterAccountStatus();
                    switch (twitterAccountSituation)
                    {
                        case TwitterAccountSituations.Blocked:
                            mainProcesses.LogProcess(LogStatus.TwitterLoginErrorAccountBlocked, txt_MainLogs, ("--->" + userName));
                            return TwitterAccountSituations.Blocked;

                        case TwitterAccountSituations.TwitterLoginErrorRequireChangingPassword:
                            mainProcesses.LogProcess(LogStatus.TwitterLoginErrorRequireChangingPassword, txt_MainLogs, ("--->" + userName));
                            return TwitterAccountSituations.TwitterLoginErrorRequireChangingPassword;

                        case TwitterAccountSituations.NeedPhoneNumber:
                            mainProcesses.LogProcess(LogStatus.TwitterLoginErrorRequirePhoneNumber, txt_MainLogs, ("--->" + userName));
                            if (_twitterService.SendPhonNumberToVerifyInLogin(twitterAccount))
                            {
                                mainProcesses.LogProcess(LogStatus.TwitterLoginSendMobilePhoneSuccessful, txt_MainLogs, ("--->" + userName));
                                System.Threading.Thread.Sleep(250);
                                return TwitterAccountSituations.LoginSuccessful;
                            }
                            else
                            {
                                mainProcesses.LogProcess(LogStatus.TwitterLoginSendMobilePhoneError, txt_MainLogs, ("--->" + userName));
                            }
                            break;

                        case TwitterAccountSituations.NeedEmailAdress:
                            if (_twitterService.SendMailAdressToVerifyInLogin(twitterAccount))
                            {
                                mainProcesses.LogProcess(LogStatus.TwitterLoginSendEmailAdressSuccessful, txt_MainLogs, ("--->" + userName));
                                System.Threading.Thread.Sleep(250);
                                return TwitterAccountSituations.LoginSuccessful;
                            }
                            else
                            {
                                mainProcesses.LogProcess(LogStatus.TwitterLoginSendEmailAdressError, txt_MainLogs, ("--->" + userName));
                            }
                            mainProcesses.LogProcess(LogStatus.TwitterLoginErrorRequireEmail, txt_MainLogs, ("--->" + userName));
                            break;
                        default: mainProcesses.LogProcess(LogStatus.TwitterLoginError, txt_MainLogs, ("--->" + userName)); break;
                    }
                    return TwitterAccountSituations.LoginError;
                }
            }
            catch
            {
                mainProcesses.LogProcess(LogStatus.TwitterLoginError, txt_MainLogs, ("--->" + userName));
                return TwitterAccountSituations.LoginError;
            }
        }
        private void Follow(ProcessHistory processHistory, int minTimeValue = 0, int maxTimeValue = 0)
        {
            int followingAccountNumer = 0; //kontrol et dışarıdan içeriye alındı hata çıkarabilir....
            ConnectControl();
            try
            {
                int firstNumberToFollowAccount = Convert.ToInt32(txt_Following_Account_NumberFirst.Text);
                int secondNumberToFollowAccount = Convert.ToInt32(txt_Following_Account_NumberSecond.Text);
                Random random = new Random();
                if (processHistory.NumberOfFollowingAccount == 0)
                {
                    followingAccountNumer = random.Next(firstNumberToFollowAccount, secondNumberToFollowAccount);
                }
                else
                {
                    followingAccountNumer = processHistory.NumberOfFollowingAccount;
                }
                processHistory.NumberOfFollowingAccount = followingAccountNumer;
                _processHistoryService.Update(processHistory);
            }
            catch
            {
                throw new Exception("Lütfen Takip Edilecek Kişi Saysını Tam Sayı Seçiniz ! Örneğin: 1 3 15...");
            }


            for (int i = 0; i < followingAccountNumer; i++)
            {
                if (processHistory.NumberOfFollowingAccount == 0)
                {
                    break;
                }
                if (Helper.IsConnected() != true)
                {
                    break;
                }
                int J = 0;
                if (processHistory.NumberOfLastAccount > 0)
                {
                    J = processHistory.NumberOfLastAccount;
                }
                while (true)
                {
                    lstbox_TwitterAccountsToFollow.SelectedIndex = J;
                    lstbox_TwitterAccountsToFollow.Select();
                    TwitterAccountToFollow twitterAccountToFollow2 = lstbox_TwitterAccountsToFollow.SelectedItem as TwitterAccountToFollow;
                    if (_followedAccountService.IsAccountFollowed(twitterAccountToFollow2))
                    {
                        J++;
                        continue;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(2500);
                        break;
                    }
                }
                TwitterAccountToFollow twitterAccountToFollow = lstbox_TwitterAccountsToFollow.SelectedItem as TwitterAccountToFollow;
                if (_twitterService.FollowingAccountExistOrBlocked(twitterAccountToFollow))
                {
                    bool result = _twitterService.Follow(twitterAccountToFollow, minTimeValue, maxTimeValue);
                    if (result)
                    {
                        processHistory.NumberOfFollowingAccount--;
                        _processHistoryService.Update(processHistory);
                        bool resultOfUpdateAsFollowed = _twitterAccountToFollowService.UpdateAsFollowed(twitterAccountToFollow);
                        TwitterAccount twitterAccount = lstbox_TwitterAccounts.SelectedItem as TwitterAccount;
                        FollowedAccount followedAccount = new FollowedAccount();
                        followedAccount.FollowingAccountId = twitterAccount.AccountId;
                        followedAccount.FollowedAccountId = twitterAccountToFollow.AccountToFollowId;
                        followedAccount.FollowingDate = DateTime.Now;
                        _followedAccountService.Add(followedAccount);
                        string extraInfoForLogProcess = "-" + "@" + twitterAccountToFollow.AccountToFollowUserName;
                        mainProcesses.LogProcess(LogStatus.TwitterAccountFollowingSuccessful, txt_MainLogs, extraInfoForLogProcess); ;
                    }
                    else
                    {
                        processHistory.NumberOfFollowingAccount--;
                        _processHistoryService.Update(processHistory);
                        mainProcesses.LogProcess(LogStatus.TwitterAccountFollowingError, txt_MainLogs);
                        continue;
                    }
                }
                else
                {
                    processHistory.NumberOfFollowingAccount--;
                    _processHistoryService.Update(processHistory);
                    mainProcesses.LogProcess(LogStatus.TwitterAccountFollowingErrorThereIsNoAccount, txt_MainLogs);
                    if (_twitterAccountToFollowService.Delete(twitterAccountToFollow))
                    {
                        FillTwitterAccountToFollowListBox();
                    }
                    continue;
                }
                System.Threading.Thread.Sleep(1500);
            }
        }
        private void StartToProcess()
        {
            ProcessHistory lastProcessHistories = null;
            try
            {
                string minValue = txt_MinValue.Text;
                string maxValue = txt_MaxValue.Text;
                int numberOfFollowingAccountNumber = lstbox_TwitterAccounts.Items.Count;
                int j = 0;
                while (true)
                {
                    bool waitProcessContinueStatus = chck_FollowProcessContinueWaitingMiunte.Checked;
                    if (waitProcessContinueStatus)
                    {
                        int waitProcessContinueTime = Convert.ToInt32(txt_FollowProcessContinueWaitingMiunte.Text);
                        if (waitProcessContinueTime > 0 && processFinishTime != DateTime.MinValue)
                        {
                            int controlTimeAsMinute = Convert.ToInt32(txt_FollowProcessContinueWaitingMiunte.Text);
                            int passedTimeAsMinute = 0;
                            while (true)
                            {
                                passedTimeAsMinute = Helper.CalculateMinuteFromDateTime(processFinishTime);
                                if (passedTimeAsMinute >= waitProcessContinueTime)
                                {
                                    break;
                                }
                                else
                                {
                                    SetFollowingProcess(ProcessStatus.WaitingTime);
                                    System.Threading.Thread.Sleep(5000);
                                }
                            }
                        }
                    }
                    try
                    {
                        lastProcessHistories = _processHistoryService.List()[0];
                        j = lastProcessHistories.NumberOfLastAccount;
                    }
                    catch
                    {
                        lastProcessHistories = null;
                    }
                    ProcessHistory processHistory;
                    if (lastProcessHistories == null)
                    {
                        processHistory = new ProcessHistory();
                        processHistory.NumberOfLastAccount = 0;
                        processHistory.ProcessDateTime = DateTime.Now;
                        processHistory.ProcessStatus = true;
                        int processId = _processHistoryService.Add(processHistory);
                    }
                    else
                    {
                        processHistory = lastProcessHistories;
                    }
                    ConnectControl();
                    SetFollowingProcess(ProcessStatus.OnProcess);
                    if (Helper.IsConnected())
                    {
                        ConnectControl();
                        mainProcesses.LogProcess(LogStatus.InternetConnected, txt_MainLogs);
                        int i = processHistory.NumberOfLastAccount;
                        while (i < lstbox_TwitterAccounts.Items.Count)
                        {
                            processHistory.NumberOfLastAccount = i;
                            _processHistoryService.Update(processHistory);
                            j++;
                            ConnectControl();
                            lstbox_TwitterAccounts.SelectedIndex = i;
                            lstbox_TwitterAccounts.Select();
                            TwitterAccount twitterAccount = lstbox_TwitterAccounts.SelectedItem as TwitterAccount;

                            TwitterAccountSituations result = TwitterAccountSituations.Undefined;// hata olmaması için.
                            for (int k = 0; k < 2; k++)
                            {
                                if (_twitterService != null)
                                {
                                    _twitterService.LogOut();
                                    _twitterService = null;
                                }
                                ConnectControl();
                                result = LoginToAccount(processHistory, twitterAccount);
                                if (result == TwitterAccountSituations.TwitterLoginErrorRequireChangingPassword || result == TwitterAccountSituations.Blocked || result == TwitterAccountSituations.LoginSuccessful)
                                {
                                    break;
                                }
                            }
                            if (result == TwitterAccountSituations.LoginSuccessful)
                            {
                                ConnectControl();
                                if (chck_ShareTweetForAllAccount.Checked)
                                {
                                    int shareCount = Convert.ToInt32(txt_ShareTweetNumber.Text);
                                    int timeRequiringPassToShareTweet = Convert.ToInt32(txt_ShareTweetWaitMinute.Text);
                                    string hourIntervalFirst = null;
                                    string hourIntervalLast = null;
                                    if (chck_ShareTweetIfItIsInHours.Checked)
                                    {
                                        hourIntervalFirst = cmb_ShareTweetIfItIsInHoursFirstHours.Text;
                                        hourIntervalLast = cmb_ShareTweetIfItIsInHoursLastHours.Text;
                                    }
                                    bool accountWillShareTweet = _twitterAccountService.AccountWillShareTweet(twitterAccount, shareCount,timeRequiringPassToShareTweet, hourIntervalFirst, hourIntervalLast);
                                    if (accountWillShareTweet)
                                    {
                                        ShareTweetProcess(twitterAccount);
                                        System.Threading.Thread.Sleep(1000);
                                    }
                                }
                                if (minValue != string.Empty && maxValue != string.Empty)
                                {
                                    if (Helper.IsNumber(minValue) && Helper.IsNumber(maxValue))
                                    {
                                        ConnectControl();
                                        int firtTime = Convert.ToInt32(minValue);
                                        int lastTime = Convert.ToInt32(maxValue);
                                        Follow(processHistory, firtTime, lastTime);
                                    }
                                }
                                else
                                {
                                    ConnectControl();
                                    Follow(processHistory);
                                }
                                i++;
                                if (i == lstbox_TwitterAccounts.Items.Count)
                                {
                                    processHistory.ProcessStatus = false;
                                    _processHistoryService.Update(processHistory);
                                    processHistory = null;
                                }
                                _twitterService.LogOut();
                                RebootModem();
                            }
                            else
                            {
                                _twitterService.LogOut();
                                RebootModem();
                                i++;
                                continue;
                            }
                        }
                        bool replayFollowingProcess = chck_FollowProcessContinue.Checked;
                        if (j == lstbox_TwitterAccounts.Items.Count && replayFollowingProcess == false)
                        {
                            if (processHistory != null)
                            {
                                processHistory.ProcessStatus = false;
                                _processHistoryService.Update(processHistory);
                                processHistory = null;
                            }
                            SetFollowingProcess(ProcessStatus.ProcessIsFinish);
                            processFinishTime = DateTime.Now;
                            break;
                        }
                        if (j == lstbox_TwitterAccounts.Items.Count)
                        {
                            if (processHistory != null)
                            {
                                processHistory.ProcessStatus = false;
                                _processHistoryService.Update(processHistory);
                                processHistory = null;
                                processFinishTime = DateTime.Now;
                            }
                        }
                        processFinishTime = DateTime.Now;
                    }
                    else
                    {
                        mainProcesses.LogProcess(LogStatus.NoInternetConnected, txt_MainLogs);
                        System.Threading.Thread.Sleep(10000);
                        processFinishTime = DateTime.Now;
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                string extraInfoForLogProcess = ex.Message;
                mainProcesses.LogProcess(LogStatus.UndefinedError, txt_MainLogs, extraInfoForLogProcess);
                if (_twitterService != null)
                {
                    _twitterService.LogOut();
                    System.Threading.Thread.Sleep(200);
                    StartToProcess();
                }
            }
        }
        private void ConnectControl()
        {
            if (Helper.IsConnected() == false)
            {
                while (true)
                {
                    mainProcesses.LogProcess(LogStatus.NoInternetConnected, txt_MainLogs);
                    System.Threading.Thread.Sleep(10000);
                    if (Helper.IsConnected())
                    {
                        break;
                    }
                }
            }
        }
        private void RebootModem()
        {
            modemResetTime = DateTime.Now;
            if (chck_AllowRebootModem.Checked)
            {
                mainProcesses.LogProcess(LogStatus.ModemIsRebooting, txt_MainLogs);
                _modemService.Reboot();
            }
            txt_MainLogs.AppendText("---------------------------------------------------------------------------------------");
            txt_MainLogs.AppendText(Environment.NewLine);
            while (true)
            {
                if (Helper.IsConnected())
                {
                    mainProcesses.LogProcess(LogStatus.InternetConnected, txt_MainLogs);
                    break;
                }
                else
                {
                    if (chck_ReresetModem.Checked)
                    {
                        int controlTimeAsMinute = Convert.ToInt32(txt_ReresetModemMinute.Text);
                        int passedTimeAsMinute = 0;
                        if (DateTime.Now.Hour - modemResetTime.Hour > 0)
                        {
                            passedTimeAsMinute = 60 - modemResetTime.Minute + DateTime.Now.Minute;
                        }
                        else
                        {
                            passedTimeAsMinute = DateTime.Now.Minute - modemResetTime.Minute;
                        }
                        if (passedTimeAsMinute >= controlTimeAsMinute)
                        {
                            string extraInfoForLogProcess = controlTimeAsMinute.ToString();
                            mainProcesses.LogProcess(LogStatus.ModemISRerebooting, txt_MainLogs, extraInfoForLogProcess);
                            RebootModem();
                        }
                    }
                }
            }
        }
        private void SelectMediaFile()
        {
            opfd_SelectMediaFile.Title = "Media Dosyasını Seçiniz";
            if (opfd_SelectMediaFile.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = opfd_SelectMediaFile.FileName.ToString();
                if (selectedFilePath != String.Empty)
                {
                    btn_RemoveSelectedFile.Visible = true;
                    lbl_SelectedFilePath.Text = selectedFilePath;
                }
            }
        }
        private int ShareTweet()
        {
            _tweetService = NinjectInstanceFactory.GetInstance<ITweetService>();
            List<Tweet> tweets = _tweetService.List();
            Tweet tweet;
            if (tweets.Count > 0)
            {
                tweet = tweets[0];
                bool result = _twitterService.ShareTweet(tweet);
                tweetSharedTime = DateTime.Now;
                if (result)
                {
                    while (true)
                    {
                        int passedTime = Helper.CalculateMinuteFromDateTime(tweetSharedTime);
                        if (passedTime >= 10)
                        {
                            break;
                        }
                        bool tweetIsSharedResult = false;
                        if (tweet.TweetMediaPath == null || tweet.TweetMediaPath == string.Empty)
                        {
                            tweetIsSharedResult = _twitterService.TweetIsShared(false);
                        }
                        else
                        {
                            tweetIsSharedResult = _twitterService.TweetIsShared(true);
                        }
                        if (tweetIsSharedResult)
                        {
                            System.Threading.Thread.Sleep(2000);
                            tweet.TweetStatus = false;
                            bool tweetChangeStatus = _tweetService.Update(tweet);
                            break;
                        }
                    }
                    FillTweetsListBox();
                }
                return tweet.TweetId;
            }
            else
            {
                return 0;
            }
        }
        private void ShareTweetProcess(TwitterAccount twitterAccount)
        {
            int shareTweetResult = ShareTweet();
            if (shareTweetResult > 0)
            {

                int tweetId = shareTweetResult;
                int twitterAccountId = twitterAccount.AccountId;

                SharedTweet sharedTweet = new SharedTweet();
                sharedTweet.TweetId = tweetId;
                sharedTweet.TwitterAccountId = twitterAccountId;
                sharedTweet.ShareDateTime = DateTime.Now;
                _sharedTweetService.Add(sharedTweet);
                mainProcesses.LogProcess(LogStatus.TweetSharingSuccessful, txt_MainLogs);
            }
            else
            {
                mainProcesses.LogProcess(LogStatus.TweetSharingError, txt_MainLogs);
            }

        }

        //private void AddTweetSharedTime()
        //{
        //    string firsTime = cmb_SharedTweetFirstTime.Text;
        //    string seconTime = cmb_SharedTweetSecondTime.Text;
        //    int tweetNumber = Convert.ToInt32(txt_SharedTweetNumber.Text);
        //    TweetSharedTime tweetSharedTime = new TweetSharedTime();
        //    tweetSharedTime.TweetSharedFirstTime = firsTime;
        //    tweetSharedTime.TweetSharedSecondTime = seconTime;
        //    tweetSharedTime.TweetNumberToShare = tweetNumber;
        //    bool result = _tweetSharedTimeService.Add(tweetSharedTime);
        //    if (result)
        //    {
        //        FillTweetSharedTimeList();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Hata Tweet Paylaşım Bilgileri Girilemedi !");
        //    }
        //}

        string selectedFilePath = string.Empty;
        private void SelectTweetMediaPatch()
        {
            fbd_SelectMediaFilePath.Description = "Media Dosyası Pathini Seçiniz";
            if (fbd_SelectMediaFilePath.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = fbd_SelectMediaFilePath.SelectedPath;
            }
        }
        private void AddTweets()
        {
            if (selectedFilePath != String.Empty)
            {
                btn_SelectMeidaFilesPath.Text = "Path: " + selectedFilePath;
            }
            while (true)
            {
                for (int i = 0; i < Directory.GetFiles(selectedFilePath).Length; i++)
                {
                    string fileName = Directory.GetFiles(selectedFilePath)[i];
                    string tweetText = string.Empty;
                    if (chck_TweetTextIsSameFileName.Checked)
                    {
                        tweetText = fileName.Split('\\')[fileName.Split('\\').Length - 1].Split('.')[0];
                    }
                    Tweet tweet = new Tweet();
                    tweet.TweetText = tweetText;
                    tweet.TweetMediaPath = fileName;
                    _tweetService.Add(tweet);
                }
                if (Directory.GetFiles(selectedFilePath).Length == 0)
                {
                    break;
                }
            }
        }
        //----------------------------------------------------------------
        //----------------------------------------------------------------
        //----------------------------------------------------------------
        //----------------------------------------------------------------
        //----------------------------------------------------------------
        //----------------------------------------------------------------
        private void btn_AddAccount_Click(object sender, EventArgs e)
        {
            AddTwitterAccount();
        }
        private void btn_AddTwitterAccountToFollow_Click(object sender, EventArgs e)
        {
            Task task = Task.Run(() => AddTwitterAccountToFollow());
        }
        private void lstbox_Accounts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DeleteTwitterAccount(sender);
        }
        private void lstbox_TwitterAccountsToFollow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DeleteTwitterAccountToFollow(sender);
        }
        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListBox listBox = lstbox_TwitterAccounts;
            TwitterAccount twitterAccount = (TwitterAccount)listBox.SelectedItem;
            UpdateAccount updateAccount = new UpdateAccount(twitterAccount);
            updateAccount.ShowDialog();
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object senderForDeleteTwitterAccount = lstbox_TwitterAccounts;
            DeleteTwitterAccount(senderForDeleteTwitterAccount);
        }
        private void düzenleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListBox listBox = lstbox_TwitterAccountsToFollow;
            TwitterAccountToFollow twitterAccountToFollow = (TwitterAccountToFollow)listBox.SelectedItem;
            UpdateAccountToFollow updateAccountToFollow = new UpdateAccountToFollow(twitterAccountToFollow);
            updateAccountToFollow.ShowDialog();
        }
        private void silToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            object senderForDeleteTwitterAccountToFollow = lstbox_TwitterAccountsToFollow;
            DeleteTwitterAccountToFollow(senderForDeleteTwitterAccountToFollow);
        }
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            _twitterService.LogOut();
        }
        private void TwitterBot_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClosingProcess();
        }
        private void btn_RebootModem_Click(object sender, EventArgs e)
        {
            Task task = Task.Run(() => RebootModem());
        }
        private void btn_Start_Click(object sender, EventArgs e)
        {
            Task task = Task.Run(() => StartToProcess());
        }
        private void btn_AddTweet_Click(object sender, EventArgs e)
        {
            AddTweet();
        }
        private void cmb_ModemBrandModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb_ModemBrandModel.SelectedItem)
            {
                case Modems.Keenetic:
                    _modemService = new KeeneticModemManager();
                    break;
                case Modems.TpLink:
                    _modemService = new TpLinkModemManager();
                    break;
                case Modems.Android_Mobile:
                    _modemService = new MobileAndroidModemManager();
                    break;
            }
        }
        private void chcklstbox_FollowProcessContinue_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_FollowProcessContinueWaitingMiunte.Checked)
            {
                txt_FollowProcessContinueWaitingMiunte.Enabled = true;
            }
            else
            {
                txt_FollowProcessContinueWaitingMiunte.Enabled = false;
            }
        }

        private void chck_ReresetModem_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_ReresetModem.Checked)
            {
                txt_ReresetModemMinute.Enabled = true;
            }
            else
            {
                txt_ReresetModemMinute.Enabled = false;
            }
        }
        private void btn_SelectFile_Click(object sender, EventArgs e)
        {
            SelectMediaFile();
        }
        private void btn_RemoveSelectedFile_Click(object sender, EventArgs e)
        {
            mainProcesses.RemoveSelectedFile(btn_RemoveSelectedFile, opfd_SelectMediaFile, lbl_SelectedFilePath);
        }
        private void btn_SelectMeidaFilesPath_Click(object sender, EventArgs e)
        {
            SelectTweetMediaPatch();
        }

        private void btn_AddTweets_Click(object sender, EventArgs e)
        {
            AddTweets();
            FillTweetsListBox();
            SetCountOfTweet();
        }

        private void chck_ShareTweetWaitMinute_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_ShareTweetWaitMinute.Checked)
            {
                txt_ShareTweetWaitMinute.Enabled = true;
            }
            else
            {
                txt_ShareTweetWaitMinute.Enabled = false;
            }
        }
    }
}
