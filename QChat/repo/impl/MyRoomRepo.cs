using MySql.Data.MySqlClient;
using QChat.common;
using QChat.datamodels;
using System;
using System.Windows.Forms;

namespace QChat.repo.impl
{
    class MyRoomRepo : IMyRoomRepo
    {
        // 只需要room.oid正确即可，其他的无所谓对不对
        // 删除时，如果该聊天室有成员和聊天数据，会自动删除相关联的聊天记录和聊天成员
        public void delete(int oid)
        {
            using (MySqlConnection conn = Mysql.Conn())
            {
                conn.Open(); // 打开连接
                string sql = "delete from myrooms where oid=@oid"; // sql语句
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn)) // 准备执行sql
                    {
                        cmd.Parameters.Add("@oid", MySqlDbType.Int32).Value = oid;
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("删除聊天室成功");
                        }
                        else
                        {
                            MessageBox.Show("删除聊天室失败");
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

        // 根据房间号oid查找聊天室，返回一个聊天室对象
        // 如果有聊天室有mid会赋值，没有消息，mid会是0
        public MyRoom getById(int oid)
        {
            MyRoom room = null; // 准备room
            using (MySqlConnection conn = Mysql.Conn())
            {
                conn.Open(); // 打开连接
                string sql = "select * from myrooms where oid=@oid"; // sql语句
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) // 准备执行sql
                {
                    try
                    {
                        cmd.Parameters.Add("@oid", MySqlDbType.Int32).Value = oid;
                        using (MySqlDataReader mySqlDataReader = cmd.ExecuteReader()) // 查找
                        {
                            if (mySqlDataReader.Read())
                            {
                                room = new MyRoom(oid, (int)mySqlDataReader["ouid"], (string)mySqlDataReader["oname"], 0);
                                if (!mySqlDataReader["omid"].ToString().Equals("")) // 如果有消息就对应赋值
                                {
                                    room.omid = (int)mySqlDataReader["omid"];
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                }
            }
            return room;
        }

        // 创建聊天室，传入ouid拥有者id，oname聊天室名字建立聊天室，聊天室oid自动生成，聊天室最新消息omid设置为空
        // ouid必须存在
        public int insert(MyRoom room)
        {
            int oid = 0;
            using (MySqlConnection conn = Mysql.Conn())
            {
                conn.Open(); // 打开连接
                string sql = "insert into myrooms(ouid, oname) values(@ouid, @oname); SELECT LAST_INSERT_ID();"; // sql语句
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) // 准备执行sql
                {
                    try
                    {
                        cmd.Parameters.Add("@ouid", MySqlDbType.Int32).Value = room.ouid;
                        cmd.Parameters.Add("@oname", MySqlDbType.String).Value = room.oname;
                        oid = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw ex;
                    }
                }
            }
            return oid;
        }
        // 根据room 的rid去修改room里的数据，更改ouid修改聊天室主人，更改oname修改聊天室名称，更改omid更改聊天室最新消息数
        // oid必须存在，ouid必须存在，oname任意，omid可为空
        public void update(MyRoom room)
        {
            using (MySqlConnection conn = Mysql.Conn())
            {
                conn.Open(); // 打开连接
                string sql = "update myrooms set ouid=@ouid, oname=@oname, omid=@omid where oid=@oid"; // sql语句
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) // 准备执行sql
                {
                    try
                    {
                        cmd.Parameters.Add("@oid", MySqlDbType.Int32).Value = room.oid;
                        cmd.Parameters.Add("@ouid", MySqlDbType.Int32).Value = room.ouid;
                        cmd.Parameters.Add("@oname", MySqlDbType.String).Value = room.oname;
                        cmd.Parameters.Add("@omid", MySqlDbType.Int32).Value = room.omid;
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("修改聊天室成功");
                        }
                        else
                        {
                            MessageBox.Show("修改聊天室失败");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        throw ex;
                    }
                }
            }
        }
    }
}
