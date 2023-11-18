using QChat.datamodels;
using System.Collections.Generic;

namespace QChat.repo
{
    public interface IMsgRepo
    {
        // 插入信息对象，用于发送信息
        void insert(Msg message);
        // 根据rmid该用户该聊天室的最后一条信息，获取所有新的信息
        List<Msg> selectByRmid(Room room);
    }
}
