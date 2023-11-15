using System;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{
    /// <summary>
    /// Author  YIUI
    /// Date    2023.11.16
    /// Desc
    /// </summary>
    [FriendOf(typeof(LobbyPanelSourceComponent))]
    public static partial class LobbyPanelSourceComponentSystem
    {
        [ObjectSystem]
        public class LobbyPanelSourceComponentInitializeSystem: YIUIInitializeSystem<LobbyPanelSourceComponent>
        {
            protected override void YIUIInitialize(LobbyPanelSourceComponent self)
            {
            }
        }
        
        [ObjectSystem]
        public class LobbyPanelSourceComponentDestroySystem: DestroySystem<LobbyPanelSourceComponent>
        {
            protected override void Destroy(LobbyPanelSourceComponent self)
            {
            }
        }
        
        [ObjectSystem]
        public class LobbyPanelSourceComponentOpenSystem: YIUIOpenSystem<LobbyPanelSourceComponent>
        {
            protected override async ETTask<bool> YIUIOpen(LobbyPanelSourceComponent self)
            {
                await ETTask.CompletedTask;
                return true;
            }
        }
        
        #region YIUIEvent开始
        #endregion YIUIEvent结束
    }
}