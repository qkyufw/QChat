using QChat.common;
using QChat.datamodels;
using QChat.repo;
using System;
using System.Windows.Forms;

namespace QChat.Forms
{
    public partial class UpdateUser : Form
    {
        Home home;
        public UpdateUser(Home home)
        {
            this.home = home;
            InitializeComponent();
        }
        // 获取新的用户信息，更新
        private void updBtn_Click(object sender, EventArgs e)
        {
            home.user.name = nameTextBox.Text;
            home.user.pwd = md5.GetMd5Hash(pwdTextBox.Text);
            UserRepo userRepo = new UserRepo();
            userRepo.UpdateUser(home.user);
            Close();
            home.userNameLabel.Text = home.user.name + "'QChat";
        }
    }
}
