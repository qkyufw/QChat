using QChat.datamodels;

namespace QChat.repo
{
    public interface IMyRoomRepo
    {
        // 主要用于创建房间
        int insert(MyRoom room);
        // 主要用于修改房间
        void update(MyRoom room);
        // 根据房间号查找房间，不可根据名称查找
        MyRoom getById(int rid);
        // 主要用于删除房间
        void delete(int oid);
    }
}
