using QChat.datamodels;
using QChat.repo;
using QChat.repo.impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace QChat.Forms
{
    public partial class Home : Form
    {
        public User user;
        public Home(User user)
        {
            this.user = user;
            InitializeComponent();
            userNameLabel.Text = user.name + "'QChat";
            createBtns(user); // 调用下面的那个函数更新页面左侧的群聊按钮
        }

        // 清空并添加按钮，主要用于刷新界面图标
        public void createBtns(User user)
        {
            chatBtnPanl.Controls.Clear(); // 清空聊天群聊按钮Panl上的所有部件
            List<Room> rooms = new List<Room>(); // 建立房间集合准备用于存储给按钮
            UserRepo userRepo = new UserRepo(); // 准备用户数据库相关的操作
            MyRoomRepo myRoomRepo = new MyRoomRepo(); // 准备用于获取房间相关信息（名字）
            rooms = userRepo.selectAllRoomByUid(user.uid); // 获取所有房间的集合
            if (rooms.Count > 0) // 如果集合中数量大于0（没有加入任何房间就不进行下面操作
            {
                foreach (Room room in rooms)
                {
                    //msgTextBox2.AppendText(myRoomRepo.get(room.roid).oname);
                    Button button = new Button(); // 创建按钮
                    button.Text = myRoomRepo.getById(room.roid).oname; // 设定按钮的名字就是群聊的名字
                    button.Size = new System.Drawing.Size(180, 40); // 设置按钮大小
                    button.Tag = room; // 将房间对象放入button的tag里去，这样可以方便后续的一些操作
                    button.MouseDown += myButton_MouseDown; // 将触发器放入button里去
                    chatBtnPanl.Controls.Add(button); // 给空间添加button
                }
            }
        }

        // 群聊按钮的触发器功能
        // 涉及群聊按钮的左键右键操作
        private void myButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // 鼠标左键操作，用于打开群聊查看消息记录
            {
                msgTextBox2.Text = ""; // 清空聊天记录
                Button button = (Button)sender; // 从sender中获取button对象，准备用于后续处理
                // MessageBox.Show("rid:"+((Room)button.Tag).rid.ToString());
                String folderPath = "histories/" + user.uid.ToString(); // 消息记录目录的位置，是histories/用户id
                if (!Directory.Exists(folderPath)) // 如果目录不存在
                {
                    Directory.CreateDirectory(folderPath); // 那就创建这个目录
                }

                string filePath = "histories/" + user.uid.ToString() + "/" + ((Room)button.Tag).rid.ToString() + ".txt"; //消息记录的名字，加入房间号的id.txt
                if (!File.Exists(filePath)) // 如果文件不存在
                {
                    try
                    {
                        StreamWriter sw = File.CreateText(filePath); // 创建这个文件
                        sw.Close();
                    }
                    catch (Exception ex) // 创建失败抛出异常
                    {
                        Console.WriteLine(ex);
                        throw ex;
                    }
                }
                msgTextBox2.Text = File.ReadAllText(filePath); // 从文件夹中读取聊天记录
                msgTextBox2.AppendText("\n 以上为历史消息 \n"); // 在聊天记录位置的末尾显示，以上是历史聊天记录
                List<Msg> msgs = new List<Msg>(); // 获取新的，未收到国地聊天记录
                MsgRepo msgRepo = new MsgRepo(); // 准备消息处理数据库操作
                UserRepo userRepo = new UserRepo(); // 准备用户数据相关数据库操作
                RoomRepo roomRepo = new RoomRepo(); // 准备用户加入的房间数据库相关操作
                MyRoomRepo myRoomRepo = new MyRoomRepo(); // 准备房间相关数据库操作
                msgs = msgRepo.selectByRmid((Room)button.Tag); // 从按钮中获取房间对象来得到未获取的消息集合
                if (msgs.Count > 0) // 如果消息数多余0，就要进行更新
                {
                    foreach (var item in msgs)
                    {
                        var name = userRepo.GetUserById(item.muid).name; // 根据muid获取发送消息者的用户名
                        msgTextBox2.AppendText(name + " " + item.mtime.ToString() + "\n" + item.context + "\n\n"); // 按格式显示在聊天记录板块中
                        File.AppendAllText(filePath, name + " " + item.mtime.ToString() + "\n" + item.context + "\n\n"); // 按格式进行存储在本地文件中
                    }
                    this.user = userRepo.GetUserById(user.uid); // 根据用户id更新用户对象，似乎多余了这行
                    button.Tag = roomRepo.GetRoom(((Room)button.Tag).rid); // 给button绑定上rid便于后续处理
                }
                // msgTextBox2.AppendText(msgs[0].context);
                roomLabel.Tag = myRoomRepo.getById(((Room)button.Tag).roid); // 更新房间tag标签，便于后续处理
                roomLabel.Text = ((MyRoom)roomLabel.Tag).oname; // 群聊名称写上
            }
            if (e.Button == MouseButtons.Right) // 右击群聊按钮进行退出
            {
                var result = MessageBox.Show("确定要退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) // 确定退出
                {
                    Room room = (Room)((Button)sender).Tag; // 从tag里获取room对象
                    RoomRepo roomRepo = new RoomRepo(); // 创建roomrepo准备删除
                    MyRoomRepo myRoomRepo = new MyRoomRepo(); // 检查是不是群主
                    if (myRoomRepo.getById(room.roid).ouid == user.uid) // 是群主
                    {
                        MessageBox.Show("不能退出自己是群主的群");
                        return;
                    }
                    roomRepo.delete(room.rid); // 不是群主，删除
                    createBtns(user);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) // 发送聊天界面
        {
            if (roomLabel.Tag == null) // 初始界面未选定聊天
            {
                MessageBox.Show("未选定聊天");
            }
            else if (msgTextBox1.Text.Equals("")) // 消息不能为空
            {
                MessageBox.Show("消息不可为空");
            }
            else
            {
                string context = msgTextBox1.Text; // 获取消息内容
                Msg msg = new Msg(); // 创建消息对象
                msg.context = context; // 赋值
                msg.muid = user.uid;
                msg.moid = ((MyRoom)roomLabel.Tag).oid;
                MsgRepo msgRepo = new MsgRepo(); // 准备数据哭操作
                msgRepo.insert(msg); // 发送消息
                msgTextBox1.Text = ""; // 清楚内容
            }
        }

        // 加入聊天室的触发器
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Room room = new Room(); // 创建加入房间对象
            room.ruid = user.uid; // 房间主人id
            room.roid = (int)(((Button)sender).Tag); // 房间号
            RoomRepo roomRepo = new RoomRepo(); // 准备加入房间
            roomRepo.insert(room); // 加入房间
            createBtns(user); // 刷新按钮
        }

        // 点击home界面的右上角叉直接退出整个程序
        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // 结束整个应用程序的运行
        }
        // 点击房间名字（非按钮，是标签上的名字）进行房间解散或修改名字等操作
        private void roomLabel_Click(object sender, EventArgs e)
        {
            if (roomLabel.Tag == null)
            {
                MessageBox.Show("请选择群聊进行操作"); // 在主界面未选定聊天室
                return;
            }
            if (((MyRoom)(((Label)sender).Tag)).ouid == user.uid)
            {
                new UpdateRoom(this).Show(); // 打开设置界面
            }
        }

        // 创建新房间的触发器
        private void myCreateBtn_Click(object sender, EventArgs e)
        {
            new CreateRoom(this).Show();
        }

        // 更改用户信息的触发器
        private void userNameLabel_Click(object sender, EventArgs e)
        {
            new UpdateUser(this).Show();
        }
        // 查找聊天室并加入的触发器
        private void searchBtn_Click(object sender, EventArgs e)
        {
            // 插入room表
            int myid; // 房间id
            try
            {
                myid = Convert.ToInt32(searchTextBox.Text); // 获取房间id
                MyRoomRepo roomRepo = new MyRoomRepo(); // 准备查找操作
                MyRoom room = new MyRoom(); // 准备room接受查找对象
                room = roomRepo.getById(myid); // 获取对象
                if (room == null)
                {
                    MessageBox.Show("查无此群");
                    createBtns(user);
                    return;
                }
                chatBtnPanl.Controls.Clear(); // 清空群聊按钮
                //msgTextBox2.AppendText(myRoomRepo.get(room.roid).oname);
                Button button = new Button(); // 设置按钮信息
                button.Text = room.oname;
                button.Size = new System.Drawing.Size(180, 40);
                button.Tag = room.oid;
                button.MouseDown += buttonAdd_Click; // 添加触发器
                chatBtnPanl.Controls.Add(button); // 添加按钮
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确的群ID");
                createBtns(user);
            }
        }

        private void roomLabel_MouseEnter(object sender, EventArgs e)
        {
            // 创建ToolTip控件
            ToolTip toolTip = new ToolTip();
            if ((MyRoom)((Label)sender).Tag != null)
            {
                // 设置提示内容
                toolTip.SetToolTip((Label)sender, "本群聊房间号：" + ((MyRoom)((Label)sender).Tag).oid.ToString());
            }
        }
    }
}
