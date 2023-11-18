using QChat.datamodels;
using QChat.repo.impl;
using System;
using System.Windows.Forms;

namespace QChat.Forms
{
    public partial class CreateRoom : Form
    {
        User user;
        Home home; // 需要在该函数中调整主界面的样式，所以传入的主界面
        public CreateRoom(Home home)
        {
            this.user = home.user;
            this.home = home;
            InitializeComponent();
        }

        // 创建一个聊天室
        private void crtBtn_Click(object sender, EventArgs e)
        {
            MyRoomRepo repo = new MyRoomRepo();
            MyRoom myRoom = new MyRoom();
            myRoom.oname = crtTextBox.Text; // 房间名
            myRoom.ouid = user.uid; // 房间主人uid设置为用户id
            myRoom.omid = 0; // 聊天室中最后一条消息的mid设置为0，有插入新的mid则会更新为更大的
            int oid = repo.insert(myRoom);
            if (oid == 0)
            {
                MessageBox.Show("创建失败");
            }
            else // 创建成功，加入聊天室，关闭窗口
            {
                RoomRepo roomRepo = new RoomRepo(); // 将自己加入到这个群聊中去
                Room room = new Room();
                room.ruid = user.uid;
                room.roid = oid;
                roomRepo.insert(room); // 插入进群内，这个其实也是个事务，不过简单写在这里插入了
            }
            home.createBtns(user); // 刷新群聊按钮界面，显示新创建的按钮，主界面调整
            Close(); // 关闭界面
        }
    }
}
