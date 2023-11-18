using MySql.Data.MySqlClient;
using System;

namespace QChat.common
{
    // 用于连接mysql数据库，使用预设的数据库信息进行连接，成功连接返回MysqlConnection对象，否则返回为空
    public class Mysql
    {
        // 数据库信息：未来不定期更改密码
        static string constring = "server=gz-cynosdbmysql-grp-9r92rrz1.sql.tencentcdb.com;port=28738;" +
            "database=qchat;user=qchat;password=pwdpwd0_;pooling=true;charset=utf8;";
        // 连接数据库，成功返回连接，失败抛出异常返回空，获得connection对象
        public static MySqlConnection Conn()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(constring);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return conn;
        }
    }
}
