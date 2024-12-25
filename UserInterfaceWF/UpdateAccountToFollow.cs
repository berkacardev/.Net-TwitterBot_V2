using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Concreate;
using UserInterfaceWF.Utilities;
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
    public partial class UpdateAccountToFollow : Form
    {
        ITwitterAccountToFollowService _twitterAccountToFollowService;
        public TwitterAccountToFollow twitterAccountToFollow { get; set; }
        public UpdateAccountToFollow(TwitterAccountToFollow twitterAccountToFollow)
        {
            _twitterAccountToFollowService = NinjectInstanceFactory.GetInstance<ITwitterAccountToFollowService>();
            this.twitterAccountToFollow = twitterAccountToFollow;
            InitializeComponent();
            string accountToFollowUserName = twitterAccountToFollow.AccountToFollowUserName;
            DateTime accountToFollowDate = twitterAccountToFollow.AccountToFollowDate;
            if(twitterAccountToFollow != null)
            {
                lbl_AccountToFollowUserName.Text = accountToFollowUserName;
                lbl_AccountToFollowDate.Text = accountToFollowDate.ToString();
                txt_AccountToFollowUserName.Text = accountToFollowUserName;
            }
        }
        private void UpdateTwitterAccountToFollow(TwitterAccountToFollow twitterAccountToFollow)
        {
            string accountToFollowUserName = txt_AccountToFollowUserName.Text;
            TwitterAccountToFollow _twitterAccountToFollow = new TwitterAccountToFollow();
            _twitterAccountToFollow.AccountToFollowId = twitterAccountToFollow.AccountToFollowId;
            _twitterAccountToFollow.AccountToFollowUserName = accountToFollowUserName;
            _twitterAccountToFollow.AccountToFollowDate = twitterAccountToFollow.AccountToFollowDate;
            bool result = _twitterAccountToFollowService.Update(_twitterAccountToFollow);
            if (result)
            {
                lbl_AccountToFollowUserName.Text = accountToFollowUserName;
                this.twitterAccountToFollow = _twitterAccountToFollow;
                MessageBox.Show("Düzenleme işlemi başarılı");
                TwitterBot twitterBot = (TwitterBot)Application.OpenForms["TwitterBot"];
                twitterBot.FillTwitterAccountToFollowListBox();
            }
            else
            {
                MessageBox.Show("Bir Hata Oluştu");
            }
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            UpdateTwitterAccountToFollow(this.twitterAccountToFollow);
        }
    }
}
