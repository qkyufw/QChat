using MySql.Data.MySqlClient;
using QChat.common;
using QChat.datamodels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QChat.repo.impl
{
    // 用于与消息相关的数据库操作
    class MsgRepo : IMsgRepo
    {
        // 发送消息到数据库
        // 将发送者uid 房间号oid 信息内容context，添加到message表中，用SELECT LAST_INSERT_ID()得到插入后得到的mid
        // 用mid去更新myrooms中的omid
        public void insert(Msg message)
        {
            // 打开数据库连接
            using (MySqlConnection connection = Mysql.Conn())
            {
                connection.Open();
                // 开始事务
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 插入消息记录并获取自增ID
                        int lastInsertId = InsertMessage(connection, transaction, message);
                        // 更新myrooms表中的omid字段
                        UpdateMyRooms(connection, transaction, message.moid, lastInsertId);
                        // 提交事务
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // 回滚事务
                        MessageBox.Show("发送失败");
                        transaction.Rollback();
                        throw (ex);
                    }
                }
            }
        }

        // 插入message函数，传入数据库连接，事务，消息对象，放入数据库中
        private int InsertMessage(MySqlConnection connection, MySqlTransaction transaction, Msg message)
        {
            // 定义sql语句
            string sql = "INSERT INTO messages(muid, moid, context) VALUES (@muid, @moid, @context); SELECT LAST_INSERT_ID();";
            using (MySqlCommand command = new MySqlCommand(sql, connection, transaction))
            {
                command.Parameters.Add("@muid", MySqlDbType.Int32).Value = message.muid;
                command.Parameters.Add("@moid", MySqlDbType.Int32).Value = message.moid;
                command.Parameters.Add("@context", MySqlDbType.String).Value = message.context;
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        // 修改lastomid函数
        private void UpdateMyRooms(MySqlConnection connection, MySqlTransaction transaction, int moid, int omid)
        {
            string sql = "UPDATE myrooms SET omid=@omid WHERE oid=@moid"; // sql语句
            using (MySqlCommand command = new MySqlCommand(sql, connection, transaction))
            {
                command.Parameters.Add("@omid", MySqlDbType.Int32).Value = omid; // 传入参数
                command.Parameters.Add("@moid", MySqlDbType.Int32).Value = moid;
                if (command.ExecuteNonQuery() == 0)
                {
                    throw new Exception("更新myrooms表失败");
                }
            }
        }

        // 根据聊天用户房间的信息，来比对获取消息
        // 如果有新的信息会返回，没有的话就返回为空
        public List<Msg> selectByRmid(Room room)
        {
            List<Msg> msgs = null;
            // 打开数据库连接
            using (MySqlConnection connection = Mysql.Conn())
            {
                connection.Open();
                // 开始事务
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 获取消息
                        msgs = new List<Msg>();
                        msgs = SelectByRmid(connection, transaction, room.roid, room.rmid);
                        if (msgs.Count > 0) // 不可以写msgs == null，如果已经获取到最新消息，就不用关了
                        {
                            int rmid = msgs[msgs.Count - 1].mid;
                            UpdateRooms(connection, transaction, room.rid, rmid);
                            transaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        // 回滚事务
                        transaction.Rollback();
                        throw (ex);
                    }
                }
            }
            return msgs;
        }

        // 获取新的消息，用msg集合去获取所有的消息，获取成功就返回所有的消息，获取失败则返回为空
        // 传入MySqlConnection对象，事务对象，roid和rmid来读取消息
        // 如果有新的消息会读取，没有消息则返回为空
        private List<Msg> SelectByRmid(MySqlConnection connection, MySqlTransaction transaction, int roid, int rmid)
        {
            List<Msg> msgs = null; // 定义msg
            string sql = "select * from messages where moid=@roid and mid > @rmid"; // sql语句
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.Add("@roid", MySqlDbType.Int32).Value = roid; // 添加参数
                cmd.Parameters.Add("@rmid", MySqlDbType.Int32).Value = rmid;
                using (MySqlDataReader mySqlDataReader = cmd.ExecuteReader())
                {
                    msgs = new List<Msg>(); // new
                    while (mySqlDataReader.Read()) // 读取不为空就放入集合
                    {
                        msgs.Add(new Msg((int)mySqlDataReader["mid"],
                            (int)mySqlDataReader["muid"],
                            (int)mySqlDataReader["moid"],
                            (DateTime)mySqlDataReader["mtime"],
                            (string)mySqlDataReader["context"]));
                    }
                }
            }
            return msgs; // 返回集合
        }

        // 更新获取过的消息的rmid，使得用户不会重复获取到获取过的消息
        // 传入connction的对象，事务对象，和rid rmid来对对应rmid进行更改
        private void UpdateRooms(MySqlConnection connection, MySqlTransaction transaction, int rid, int rmid)
        {
            string sql = "UPDATE rooms SET rmid=@rmid WHERE rid=@rid"; // sql语句
            using (MySqlCommand command = new MySqlCommand(sql, connection, transaction))
            {
                command.Parameters.Add("@rmid", MySqlDbType.Int32).Value = rmid; // 传入参数
                command.Parameters.Add("@rid", MySqlDbType.Int32).Value = rid;
                if (command.ExecuteNonQuery() == 0)
                {
                    throw new Exception("更改rmid失败");
                }
            }
        }
    }
}
