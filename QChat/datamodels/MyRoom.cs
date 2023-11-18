namespace QChat.datamodels
{
    // 聊天房间模型
    public class MyRoom
    {
        // 房间号，唯一，可根据此查找，删除
        public int oid { get; set; }
        // 房间主人的uid，对应USERS表中的uid
        public int ouid { get; set; }
        // 房间名，房间的名字
        public string oname { get; set; }
        // 记录该房间的最后一条消息mid
        public int omid { get; set; }
        // 构造函数
        public MyRoom(int oid, int ouid, string oname, int omid)
        {
            this.oid = oid;
            this.ouid = ouid;
            this.oname = oname;
            this.omid = omid;
        }

        public MyRoom()
        {
        }
    }
}
