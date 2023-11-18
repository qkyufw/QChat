using QChat.datamodels;
using System.Collections.Generic;

namespace QChat.repo
{
    public interface IUserRepo
    {
        // 根据uid获取用户对象
        User GetUserById(int id);
        // 根据账号密码获取用户
        User GetUser(string email, string pwd);
        // 根据用户对象加入表中
        void InsertUser(User user);
        // 根据用户对象进行更新
        void UpdateUser(User user);
        // 根据用户uid获取用户加入的所有房间（放在房间repo里似乎更合适点）
        List<Room> selectAllRoomByUid(int uid);
    }
}
