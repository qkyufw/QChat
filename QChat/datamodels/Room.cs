namespace QChat.datamodels
{
    // 加入房间模型
    // 如果一个用户加入一个房间，那么就会有这样一个对象，如果加入另一个房间，需要有另一个对象
    public class Room
    {
        // roomid 房间ID
        public int rid { get; set; }
        // userid 用户ID对应users表中的uid
        public int ruid { get; set; }
        // 房间id，对应myroom表中的OID
        public int roid { get; set; }
        // 记录该用户收到的最后一条消息的（rmid)，如果这个用户在这个房间收到的最后一条消息的
        // mid小于对应房间的最后一条消息的mid（omid），那么就会进行消息记录更新
        public int rmid { get; set; }
        // 构造函数
        public Room()
        {
        }
        public Room(int rid, int ruid, int roid)
        {
            this.rid = rid;
            this.ruid = ruid;
            this.roid = roid;
        }
        public Room(int rid, int ruid, int roid, int rmid)
        {
            this.rid = rid;
            this.ruid = ruid;
            this.roid = roid;
            this.rmid = rmid;
        }
    }

}
