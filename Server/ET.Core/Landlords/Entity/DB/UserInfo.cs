using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ETModel
{
    [ObjectSystem]
    public class UserInfoAwakeSystem : AwakeSystem<UserInfo, string>
    {
        public override void Awake(UserInfo self, string name)
        {
            self.Awake(name);
        }
    }

    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo : Entity
    {
        //昵称
        public string UserName { get; set; }

        //余额
        public string MapInfo { get; set; }

        //public List<Ca>
        public void Awake(string name)
        {
            UserName = name;
            MapInfo = MapInfoHelper.getInitMapInfo();
        }

    }

    public class SingleMapInfo 
    {
        public int isAllClear;//是否清空此关卡道具 1为清空2为没有清空
        public int carrotState;//萝卜状态
        public int levelId;//小关卡ID
        public int bigLevelId;//大关卡ID
        public int unLocked;//此关卡是否解锁 1为解锁 2为未解锁
    }
}