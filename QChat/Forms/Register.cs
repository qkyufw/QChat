using QChat.common;
using QChat.datamodels;
using QChat.repo;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QChat.Forms
{
    // 注册功能
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        // 注册按钮触发器
        private void registerBtn_Click(object sender, EventArgs e)
        {
            // 两次密码匹配
            if (pwdTextBox.Text == pwdCTextBox.Text)
            {
                string email = emailTextBox.Text;
                // 正则表达式匹配邮箱是否正确
                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("请输入正确格式的电子邮件地址");
                    return;
                }
                // 插入用户到数据库中
                User user = new User
                {
                    name = nameTextBox.Text,
                    email = emailTextBox.Text,
                    pwd = md5.GetMd5Hash(pwdTextBox.Text),
                };
                UserRepo userRepo = new UserRepo();
                userRepo.InsertUser(user);
                Close();
            }
            else
            {
                MessageBox.Show("两次输入的密码不相同");
            }
        }
    }
}
