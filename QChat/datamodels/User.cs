namespace QChat.datamodels
{
    // 用于用户的模型构造
    public class User
    {
        public int uid { get; set; } // 用户名
        public string pwd { get; set; } // 密码
        public string email { get; set; } // 电子邮件
        public string name { get; set; } // 名称

        public User()
        {
        }

        public User(int uid, string pwd, string email, string name)
        {
            this.uid = uid;
            this.pwd = pwd;
            this.email = email;
            this.name = name;
        }
    }
}
