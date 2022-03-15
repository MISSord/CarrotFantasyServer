using System;
using System.Net;
using ETModel;
using System.Collections.Generic;
using MongoDB.Bson;

namespace ETHotfix
{

    [MessageHandler(AppType.Gate)]
    public class A1002_SetSingleMapInfo_Handler : AMRpcHandler<A1002_SetSingleMapInfo_C2G, A1002_SetSingleMapInfo_G2C>
    {
        protected override async ETTask Run(Session session, A1002_SetSingleMapInfo_C2G request, A1002_SetSingleMapInfo_G2C response, Action reply)
        {
            try
            {
                //验证Session
                if (!GateHelper.SignSession(session))
                {
                    response.Error = ErrorCode.ERR_UserNotOnline;
                    reply();
                    return;
                }

                DBProxyComponent dbProxy = Game.Scene.GetComponent<DBProxyComponent>();

                //获取User对象
                User user = session.GetComponent<SessionUserComponent>().User;

                //查询获得用户信息数据对象
                UserInfo userInfo = await dbProxy.Query<UserInfo>(user.UserID);

                SingleMapInfo newMapInfo = new SingleMapInfo();
                newMapInfo.bigLevelId = request.BigLevelId;
                newMapInfo.levelId = request.LevelId;
                newMapInfo.carrotState = request.CarrotState;
                newMapInfo.isAllClear = request.IsAllClear;
                newMapInfo.unLocked = request.UnLocked;

                try {
                    userInfo.MapInfo = MapInfoHelper.getNewMapInfo(userInfo.MapInfo, newMapInfo);
                    await dbProxy.Save(userInfo);
                } 
                catch (Exception e) {
                    ReplyError(response, e, reply);
                    response.Error = ErrorCode.ERR_SaveMapInfoError;
                    reply();
                }
                response.Error = ErrorCode.ERR_Success;
                reply();

                await ETTask.CompletedTask;
            }
            catch (Exception e)
            {
                ReplyError(response, e, reply);
                response.Error = ErrorCode.ERR_SaveMapInfoError;
                reply();
            }
        }
    }
}
