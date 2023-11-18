using QChat.datamodels;
using QChat.repo.impl;
using System;
using System.Windows.Forms;

namespace QChat.Forms
{
    // 更新房间
    public partial class UpdateRoom : Form
    {
        MyRoom myRoom;
        Home home;
        public UpdateRoom(Home home)
        {
            this.myRoom = (MyRoom)home.roomLabel.Tag;
            this.home = home;
            InitializeComponent();
        }
        // 用于更新房间
        private void updBtn_Click(object sender, EventArgs e)
        {
            MyRoomRepo myRoomRepo = new MyRoomRepo();
            myRoom.oname = updTextBox.Text;
            myRoomRepo.update(myRoom);
            home.createBtns(home.user);
            home.roomLabel.Text = myRoom.oname;
            Close();
        }
        // 删除房间
        private void dltBtn_Click(object sender, EventArgs e)
        {
            MyRoomRepo myRoomRepo = new MyRoomRepo();
            myRoomRepo.delete(myRoom.oid);
            home.createBtns(home.user);
            home.roomLabel.Text = myRoom.oname;
            Close();
        }
    }
}
