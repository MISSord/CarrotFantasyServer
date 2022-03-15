using ETModel;
using System.Net;

namespace ETHotfix
{
    public static class GateHelper
    {
        /// <summary>
        /// 验证Session是否绑定了玩家
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public static bool SignSession(Session session)
        {
            SessionUserComponent sessionUser = session.GetComponent<SessionUserComponent>();
            if (sessionUser == null || Game.Scene.GetComponent<UserComponent>().Get(sessionUser.User.UserID) == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取斗地主游戏专用Map服务器的Session
        /// </summary>
        /// <returns></returns>
        public static Session GetMapSession()
        {
            StartConfigComponent config = Game.Scene.GetComponent<StartConfigComponent>();
            IPEndPoint mapIPEndPoint = config.MapConfigs[0].GetComponent<InnerConfig>().IPEndPoint;
            Log.Debug(mapIPEndPoint.ToString());
            Session mapSession = Game.Scene.GetComponent<NetInnerComponent>().Get(mapIPEndPoint);
            return mapSession;
        }
    }
}
