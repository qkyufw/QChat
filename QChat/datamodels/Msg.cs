using System;

namespace QChat.datamodels
{
    // 消息对象模型
    public class Msg
    {
        // 信息id编号
        public int mid { get; set; }
        // 发送者id，对应user表中的uid
        public int muid { get; set; }
        // 发送的房间号码，房间号码，对应myrooms表中的oid
        public int moid { get; set; }
        // 发送的时间，消息发送的时间
        public DateTime mtime { get; set; }
        // 发送的内容，存储消息发送的内容
        public string context { get; set; }
        public Msg()
        {
        }

        public Msg(int mid, int muid, int moid, DateTime mtime, string text)
        {
            this.mid = mid;
            this.muid = muid;
            this.moid = moid;
            this.mtime = mtime;
            this.context = text;
        }
    }
}
