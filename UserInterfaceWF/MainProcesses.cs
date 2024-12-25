using BusinessLogicLayer.Abstract;
using Entity.Concreate;
using Entity.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterfaceWF.Utilities;

namespace UserInterfaceWF
{
    internal class MainProcesses
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

        internal MainProcesses()
        {
            _twitterAccountService = NinjectInstanceFactory.GetInstance<ITwitterAccountService>();
            _twitterAccountToFollowService = NinjectInstanceFactory.GetInstance<ITwitterAccountToFollowService>();
            _confugrateService = NinjectInstanceFactory.GetInstance<IConfugrateService>();
            _followedAccountService = NinjectInstanceFactory.GetInstance<IFollowedAccountService>();
            _tweetService = NinjectInstanceFactory.GetInstance<ITweetService>();
            _processHistoryService = NinjectInstanceFactory.GetInstance<IProcessHistoryService>();
            _tweetSharedTimeService = NinjectInstanceFactory.GetInstance<ITweetSharedTimeService>();
            _sharedTweetService = NinjectInstanceFactory.GetInstance<ISharedTweetService>();
        }
        internal void AddTwitterAccount(TextBox userNameTextBox, TextBox userPasswordTextBox, TextBox userEmailAddressTextBox, TextBox userPhoneNumberTextBox)
        {
            string userName = userNameTextBox.Text;
            string userPassword = userPasswordTextBox.Text;
            string userEmailAddress = userEmailAddressTextBox.Text;
            string userPhoneNumber = userPhoneNumberTextBox.Text;
            TwitterAccount twitterAccount = new TwitterAccount(userName, userPassword, userEmailAddress, userPhoneNumber);
            bool result = _twitterAccountService.Add(twitterAccount);
            if (result)
            {
                userNameTextBox.Text = string.Empty;
                userPasswordTextBox.Text = string.Empty;
                userEmailAddressTextBox.Text = string.Empty;
                userPhoneNumberTextBox.Text = string.Empty;
            }
            else
            {
                throw new Exception("Hesap eklenirken bir hata oluştu !");
            }
        }
        internal void DeleteTwitterAccount(object sender)
        {
            ListBox listBox = (ListBox)sender;
            TwitterAccount twitterAccount = (TwitterAccount)listBox.SelectedItem;
            string message = "Kullanıcı Adı: " + twitterAccount.AccountUserName + "\nŞifre: " + twitterAccount.AccountPassword + "\nSilmek istediğinize eminmisiniz ?";
            DialogResult dialogResultDelete = MessageBox.Show(message, "Silmek İstediğinize Eminmisiniz", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResultDelete == DialogResult.Yes)
            {
                bool result = _twitterAccountService.Delete(twitterAccount);
                if (result)
                {
                    MessageBox.Show("Hesap Başarıyla Silindi", "Silme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Hata Hesap Silinirken Bir Hata Oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        internal void FillTwitterAccountListBox(ListBox listBox)
        {
            try
            {
                _twitterAccountService = NinjectInstanceFactory.GetInstance<ITwitterAccountService>();
                List<TwitterAccount> twitterAccounts = _twitterAccountService.List();
                listBox.DataSource = twitterAccounts;
            }
            catch
            {
                throw new Exception("Twitter Hesapları listesi doldurulurken bir hata oluştu");
            }
        }
        internal void AddTwitterAccountToFollow(TextBox textBox, ProgressBar progressBar, Label label)
        {
            try
            {
                int countOfTwitterAccountToFollow = textBox.Lines.Length;
                for (int i = 0; i < countOfTwitterAccountToFollow; i++)
                {
                    string twitterAccount = textBox.Lines[i];
                    if (twitterAccount.StartsWith("@"))
                    {
                        string[] resultOfTwitterAccountUserName = twitterAccount.Split('@');
                        twitterAccount = resultOfTwitterAccountUserName[1];
                    }
                    TwitterAccountToFollow twitterAccountToFollow = new TwitterAccountToFollow(twitterAccount);
                    double rateOfProcessAsPercent = 100 * (double)i / (double)countOfTwitterAccountToFollow;
                    int processStatusAsPercent = (int)Math.Round(rateOfProcessAsPercent, 0);
                    bool result = _twitterAccountToFollowService.Add(twitterAccountToFollow);
                    progressBar.Value = (int)processStatusAsPercent;
                    label.Text = "%" + processStatusAsPercent.ToString();
                    if (i == countOfTwitterAccountToFollow - 1)
                    {
                        progressBar.Value = 100;
                        label.Text = "%100 Bitti";
                        label.Text = string.Empty;
                    }
                }
            }
            catch
            {
                throw new Exception("Hesaplar eklenirken bir hata oluştu");
            }
        }
        internal void DeleteTwitterAccountToFollow(object sender)
        {
            ListBox listBox = (ListBox)sender;
            TwitterAccountToFollow twitterAccountToFollow = (TwitterAccountToFollow)listBox.SelectedItem;
            string message = "Takip edileckler listesindeki" + " @" + twitterAccountToFollow.AccountToFollowUserName + "kullanıcıyı listeden çıkarmak istiyormusunuz ?";
            DialogResult dialogResultDelete = MessageBox.Show(message, "Silmek İstediğinize Eminmisiniz", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResultDelete == DialogResult.Yes)
            {
                bool result = _twitterAccountToFollowService.Delete(twitterAccountToFollow);
                if (result)
                {
                    MessageBox.Show("Kullanıcı Başarıyla Silindi", "Silme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Hata Kullanıcı Silinirken Bir Hata Oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        internal void FillTwitterAccountToFollowListBox(ListBox listBox)
        {
            try
            {
                _twitterAccountToFollowService = NinjectInstanceFactory.GetInstance<ITwitterAccountToFollowService>();
                List<TwitterAccountToFollow> twitterAccountToFollows = _twitterAccountToFollowService.List();
                listBox.DataSource = twitterAccountToFollows;
            }
            catch
            {
                throw new Exception("Takip edilecek hesaplar listesi doldurulurken bir hata oluştu");
            }
        }
        internal void SetCountOfTwitterAccount(Label label)
        {
            label.Text = _twitterAccountService.CountrOfAllAccount().ToString();
        }
        internal void SetCountOfTwitterAccountToFollow(Label label)
        {
            label.Text = _twitterAccountToFollowService.CountOfAllAccount().ToString();
        }
        internal void AddTweet(TextBox tweetTextBox, OpenFileDialog openFileDialogForMedia)
        {
            string tweetText = tweetTextBox.Text;
            string mediaFilePath = openFileDialogForMedia.FileName.ToString();
            Tweet tweet = new Tweet();
            tweet.TweetMediaPath = mediaFilePath;
            tweet.TweetText = tweetText;
            if (_tweetService.Add(tweet))
            {
                tweetTextBox.Text = string.Empty;
            }
            else
            {
                throw new Exception("Tweet eklenirken bir hata oluştu");
            }
        }
        internal void RemoveSelectedFile(Button removeMediaButton, OpenFileDialog openFileDialogForMedia, Label selectedFilePath)
        {
            removeMediaButton.Visible = false;
            openFileDialogForMedia.FileName = string.Empty;
            selectedFilePath.Text = "Seçili Dosya Yok";
        }
        internal void FillTweetsListBox(DataGridView dataGridView)
        {
            try
            {
                _tweetService = NinjectInstanceFactory.GetInstance<ITweetService>();
                List<Tweet> tweets = _tweetService.List();
                tweets.Reverse();
                dataGridView.DataSource = tweets;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[1].Width = 420;
                dataGridView.Columns[1].HeaderText = "Tweet Metni";
                dataGridView.Columns[2].Width = 440;
                dataGridView.Columns[2].HeaderText = "Media Dosya Yolu";
                dataGridView.Columns[3].Width = 110;
                dataGridView.Columns[3].HeaderText = "Kayıt Tarihi";
            }
            catch
            {
                throw new Exception("Tweet listesi doldurulurken bir hata oluştu");
            }
        }
        internal void SetCountOfTweet(Label label)
        {
            label.Text = _tweetService.CountOfTweet().ToString();
        }
        private Log DetermineLog(LogStatus logStatus)
        {
            string message = string.Empty;
            switch (logStatus)
            {
                case LogStatus.UndefinedError: message = "Tanımlanmamış Hata:"; break;
                case LogStatus.InternetConnected: message = "İnternet bağlantısı var."; break;
                case LogStatus.NoInternetConnected: message = "İNTERNET BAĞLANTISI YOK ! 10 Saniye sonra tekrar bağlanmayı deneyecek."; break;
                case LogStatus.ModemIsRebooting: message = "Modem Resetleniyor..."; break;
                case LogStatus.ModemISRerebooting: message = "Dakika geçti ve internete bağlanamadı, Modem Tekrar Resetleniyor"; break;
                case LogStatus.TwitterLoginError: message = " Hata giriş yapılamadı. Kullanıcı Adı veya Şifrenin doğru olduğundan emin olun veya hesap engellenmiş olabailir!"; break;
                case LogStatus.TwitterLoginSuccessful: message = " Kullanıcı adlı hesaba başarıyla giriş yapıldı"; break;
                case LogStatus.TwitterLoginErrorAccountBlocked: message = " Bu Twitter Hesabı Engllenmiş."; break;
                case LogStatus.TwitterLoginErrorRequirePhoneNumber: message = "Hesaba giriş için telefon numarası gerekli"; break;
                case LogStatus.TwitterLoginErrorRequireEmail: message = "Hesaba giriş için Email adresi gerekli"; break;
                case LogStatus.TwitterLoginErrorRequireChangingPassword: message = " Bu Twitter Hesabına erişmek için şifre değişikliği gerekli."; break;
                case LogStatus.TwitterAccountFollowingError: message = " Hesap Takipedilirken bir hata oluştu !"; break;
                case LogStatus.TwitterAccountFollowingErrorThereIsNoAccount: message = " Bu Twitter hesabı yok veya askıya alınmış ! - Bu hesap listeden kaldırıldı"; break;
                case LogStatus.TwitterAccountFollowingSuccessful: message = "Hesap başarıyla takip edildi"; break;
                case LogStatus.TweetSharingError: message = "Hata tweet atılamadı. Bir Hata oluştu veya Tweet Havuzu boş olabilir."; break;
                case LogStatus.TweetSharingErrorTweetPoolCanBeEmpty: message = "Hata tweet atılamadı. Bir Hata oluştu veya Tweet Havuzu boş olabilir."; break;
                case LogStatus.TweetSharingSuccessful: message = "Tweet Başarı İle atıldı"; break;
                case LogStatus.TwitterLoginSendMobilePhoneError: message = "Telefon Numarası girilirken bir hata oluştu, telfon numarası yanlış olabilir."; break;
                case LogStatus.TwitterLoginSendMobilePhoneSuccessful: message = "Telefon Numarası başarı ile girildi"; break;
                case LogStatus.TwitterLoginSendEmailAdressError: message = "Email adresi girilirken bir hata oluştu, telfon numarası yanlış olabilir."; break;
                case LogStatus.TwitterLoginSendEmailAdressSuccessful: message = "Email adresi başarı ile girildi"; break;
                default: message = "Tanımlanmamış Hata:"; break;
            }
            Log log = new Log(message);
            return log;
        }
        private void AddLogPresentationTextBox(TextBox logPresentationTextBox, Log log)
        {
            string logMessage = log.LogMessage;
            string logDateTime = log.LogDateTime.ToString();
            string logMessageToLogger = "-" + logDateTime + " " + logMessage;
            logPresentationTextBox.AppendText(logMessageToLogger);
            logPresentationTextBox.AppendText(Environment.NewLine);
        }
        internal void LogProcess(LogStatus logStatus, TextBox logPresentationTextBox, string extraInfoAboutProcess = null)
        {
            Log log = DetermineLog(logStatus);
            if (extraInfoAboutProcess != null && extraInfoAboutProcess != string.Empty)
            {
                string logMessage = log.LogMessage;
                if (logStatus != LogStatus.UndefinedError)
                {
                    logMessage = extraInfoAboutProcess + " " + logMessage;
                }
                else
                {
                    logMessage = logMessage + " " + extraInfoAboutProcess;
                }
                log.LogMessage = logMessage;
            }
            AddLogPresentationTextBox(logPresentationTextBox, log);
        }
    }
}
