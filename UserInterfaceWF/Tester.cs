using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Concreate.Selenium;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterfaceWF
{
    public partial class Tester : Form
    {
        ITwitterService _twitterService;
        public Tester()
        {
            InitializeComponent();
        }

        private void Tester_Load(object sender, EventArgs e)
        {
            TwitterAccount twitterAccount = new TwitterAccount();
            twitterAccount.AccountUserName = "NehirSefil";
            twitterAccount.AccountPassword = "b";
            _twitterService = new SeleniumTwitterManager();
            _twitterService.Login(twitterAccount);
        }
    }
}
