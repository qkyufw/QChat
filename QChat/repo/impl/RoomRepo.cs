using MySql.Data.MySqlClient;
using QChat.common;
using QChat.datamodels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QChat.repo.impl
{
    class RoomRepo : IRoomRepo
    {
        // 根据room的id来删除对应数据
        // 其他细节信息不用管，只需要id正确即可
        public void delete(int rid)
        {
            using (MySqlConnection conn = Mysql.Conn())
            {
                conn.Open(); // 打开连接
                string sql = "delete from rooms where rid=@rid"; // sql语句
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) // 准备执行sql
                {
                    try
                    {
                        cmd.Parameters.Add("@rid", MySqlDbType.Int32).Value = rid;
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("删除聊天室成功");
                        }
                        else
                        {
                            MessageBox.Show("删除聊天室失败");
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

        // 加入聊天室，主要需要加入者uid，聊天室oid
        public void insert(Room room)
        {
            using (MySqlConnection conn = Mysql.Conn())
            {
                conn.Open(); // 打开连接
                string sql = "insert into rooms(ruid, roid) values(@ruid, @roid)"; // sql语句
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) // 准备执行sql
                {
                    try
                    {
                        cmd.Parameters.Add("@ruid", MySqlDbType.Int32).Value = room.ruid;
                        cmd.Parameters.Add("@roid", MySqlDbType.String).Value = room.roid;
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("加入聊天室成功");
                        }
                        else
                        {
                            MessageBox.Show("加入聊天室失败");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("加入聊天室失败");
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        // 根据roid房间号查找出里面的所有用户并返回一个集合，查找失败返回为空
        public List<User> selectAllByRoid(int roid)
        {
            // 返回users集合
            // 在user表中查询，其中uid出现在room中了
            List<User> users = null;
            using (MySqlConnection conn = Mysql.Conn())
            {
                conn.Open(); // 打开连接
                string sql = "select * from users where uid in (select ruid from rooms where roid=@roid)"; // sql语句
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) // 准备执行sql
                {
                    try
                    {
                        cmd.Parameters.Add("@roid", MySqlDbType.Int32).Value = roid;
                        using (MySqlDataReader mySqlDataReader = cmd.ExecuteReader()) // 查找
                        {
                            users = new List<User>();
                            while (mySqlDataReader.Read())
                            {
                                users.Add(new User((int)mySqlDataReader["uid"],
                                    (string)mySqlDataReader["pwd"],
                                    (string)mySqlDataReader["email"],
                                    (string)mySqlDataReader["name"]));
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
            return users;
        }
        // 用于获取加入的房间数据
        // 传入rid，返回room对象，查找失败返回为空
        public Room GetRoom(int rid)
        {
            Room room = null;
            try
            {
                using (MySqlConnection conn = Mysql.Conn())
                {
                    conn.Open(); // 打开连接
                    string sql = "select * from rooms where rid=@rid"; // sql语句
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn)) // 准备执行sql
                    {
                        cmd.Parameters.Add("@rid", MySqlDbType.Int32).Value = rid;
                        using (MySqlDataReader mySqlDataReader = cmd.ExecuteReader()) // 查找
                        {
                            if (mySqlDataReader.Read())
                            {
                                room = new Room((int)mySqlDataReader["rid"], (int)mySqlDataReader["ruid"], (int)mySqlDataReader["roid"], (int)mySqlDataReader["rmid"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            return room;
        }
    }
}
