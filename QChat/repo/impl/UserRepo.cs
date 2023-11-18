using MySql.Data.MySqlClient;
using QChat.common;
using QChat.datamodels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QChat.repo
{
    public class UserRepo : IUserRepo
    {
        // 根据id查找用户，仅用于查询用户，如查询群聊天内的所有成员，查找不到返回为空
        public User GetUserById(int id)
        {
            User user = null; // 准备user
            using (MySqlConnection conn = Mysql.Conn())
            {
                conn.Open(); // 打开连接
                string sql = "select * from users where uid=@id"; // sql语句
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) // 准备执行sql
                {
                    try
                    {
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id; // 设定参数
                        using (MySqlDataReader mySqlDataReader = cmd.ExecuteReader()) // 查找
                        {
                            if (mySqlDataReader.Read())
                            {
                                user = new User(id, (string)mySqlDataReader["pwd"], (string)mySqlDataReader["email"], (string)mySqlDataReader["name"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw ex;
                    }

                }
            }
            return user;
        }

        // 主要用于登录，根据email和pwd去找，找到返回user类，找不到返回空
        public User GetUser(string email, string pwd)
        {
            User user = null; // 准备user
            using (MySqlConnection conn = Mysql.Conn())
            {
                conn.Open(); // 打开连接
                string sql = "select * from users where email=@email and pwd=@pwd"; // sql语句
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) // 准备执行sql
                {
                    try
                    {
                        cmd.Parameters.Add("@pwd", MySqlDbType.String).Value = pwd;
                        cmd.Parameters.Add("@email", MySqlDbType.String).Value = email;
                        using (MySqlDataReader mySqlDataReader = cmd.ExecuteReader()) // 查找
                        {
                            if (mySqlDataReader.Read())
                            {
                                user = new User((int)mySqlDataReader["uid"], pwd, email, (string)mySqlDataReader["name"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw ex;
                    }
                }
            }

            return user;
        }

        // 创建用户，插入密码，邮箱，用户名等数据，成功显示创建成功，通过email和pwd登录，uid不做登录使用，不返回任何信息
        // 主要用于注册，需要确保user不为空，可以被插入
        public void InsertUser(User user)
        {
            using (MySqlConnection conn = Mysql.Conn())
            {
                conn.Open(); // 打开连接
                string sql = "insert into users(pwd, email, name) values(@pwd, @email, @name)"; // sql语句
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) // 准备执行sql
                {
                    try
                    {
                        cmd.Parameters.Add("@pwd", MySqlDbType.String).Value = user.pwd;
                        cmd.Parameters.Add("@email", MySqlDbType.String).Value = user.email;
                        cmd.Parameters.Add("@name", MySqlDbType.String).Value = user.name;
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("创建成功");
                        }
                        else
                        {
                            MessageBox.Show("创建失败");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("创建失败：邮箱已被注册或其他原因");
                        return;
                    }
                }
            }
        }

        // 根据用户id修改用户数据，可修改密码，邮箱，名字（邮箱不应被修改，登录唯一凭证）已给邮箱增加unique
        // 主要用于更改密码，名字，需要确保user不为空，可以被插入
        // 目前实现了的功能仅支持修改群名
        public void UpdateUser(User user)
        {
            using (MySqlConnection conn = Mysql.Conn())
            {
                conn.Open(); // 打开连接
                string sql = "update users set pwd=@pwd, email=@email, name=@name where uid=@id";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) // 准备执行sql
                {
                    try
                    {
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = user.uid;
                        cmd.Parameters.Add("@pwd", MySqlDbType.String).Value = user.pwd;
                        cmd.Parameters.Add("@email", MySqlDbType.String).Value = user.email;
                        cmd.Parameters.Add("@name", MySqlDbType.String).Value = user.name;
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("修改成功");
                        }
                        else
                        {
                            MessageBox.Show("修改失败");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw ex;
                    }
                }
            }
        }
        // 根据UID得到用户的所有加入的聊天室
        // 没有就返回空
        public List<Room> selectAllRoomByUid(int uid)
        {
            // 返回rooms集合
            // 在user表中查询，其中uid出现在room中了
            List<Room> rooms = null;
            using (MySqlConnection conn = Mysql.Conn())
            {
                conn.Open(); // 打开连接
                string sql = "select * from rooms where ruid=@uid"; // sql语句
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) // 准备执行sql
                {
                    try
                    {
                        cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = uid;
                        using (MySqlDataReader mySqlDataReader = cmd.ExecuteReader()) // 查找
                        {
                            rooms = new List<Room>();
                            while (mySqlDataReader.Read())
                            {
                                Room room = new Room((int)mySqlDataReader["rid"],
                                    (int)mySqlDataReader["ruid"],
                                    (int)mySqlDataReader["roid"]
                                    /*                                    (int)mySqlDataReader["rmid"])*/
                                    );
                                if (!mySqlDataReader["rmid"].ToString().Equals("")) // 如果有消息就对应赋值
                                {
                                    room.rmid = (int)mySqlDataReader["rmid"];
                                }
                                rooms.Add(room);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw ex;
                    }
                }
            }
            return rooms;
        }
    }
}
