using QChat.common;
using QChat.datamodels;
using QChat.Forms;
using QChat.repo;
using System;
using System.Windows.Forms;

namespace QChat
{
    // 登陆界面
    public partial class LoginFrom : Form
    {
        public LoginFrom()
        {
            InitializeComponent();
        }

        // 登录按钮
        private void button1_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text; // 获取邮箱
            string pwd = md5.GetMd5Hash(pwdTextBox.Text); // 获取密码
            UserRepo userRepo = new UserRepo(); // 准备查找用户
            User user = userRepo.GetUser(email, pwd); // 匹配用户
            if (user != null)
            {
                Hide(); // 登录成功，藏登陆界面
                Home home = new Home(user); // 打开主界面，传入登录的用户
                home.Show(); // 展开用户
            }
            else
            {
                MessageBox.Show("登录失败");
            }
        }


        private void registerBtn_Click(object sender, EventArgs e)
        {
            new Register().Show(); // 打开注册界面
        }
    }
}
