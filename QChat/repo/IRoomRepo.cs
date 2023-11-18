using QChat.datamodels;
using System.Collections.Generic;

namespace QChat.repo
{
    public interface IRoomRepo
    {
        // 用于加入聊天室
        void insert(Room room);
        // 用于将一个用户从聊天室删除
        void delete(int rid);
        // 通过聊天室号寻找所有的成员
        List<User> selectAllByRoid(int roid);
        // 根据rid获取getroom
        Room GetRoom(int rid);
    }
}
