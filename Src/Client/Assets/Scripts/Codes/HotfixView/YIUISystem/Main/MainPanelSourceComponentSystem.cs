using System;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{
    /// <summary>
    /// Author  YIUI
    /// Date    2023.11.20
    /// Desc
    /// </summary>
    [FriendOf(typeof(MainPanelSourceComponent))]
    public static partial class MainPanelSourceComponentSystem
    {
        [ObjectSystem]
        public class MainPanelSourceComponentInitializeSystem: YIUIInitializeSystem<MainPanelSourceComponent>
        {
            protected override void YIUIInitialize(MainPanelSourceComponent self)
            {
            }
        }
        
        [ObjectSystem]
        public class MainPanelSourceComponentDestroySystem: DestroySystem<MainPanelSourceComponent>
        {
            protected override void Destroy(MainPanelSourceComponent self)
            {
            }
        }
        
        [ObjectSystem]
        public class MainPanelSourceComponentOpenSystem: YIUIOpenSystem<MainPanelSourceComponent>
        {
            protected override async ETTask<bool> YIUIOpen(MainPanelSourceComponent self)
            {
                await ETTask.CompletedTask;
                return true;
            }
        }
        
        #region YIUIEvent开始
        #endregion YIUIEvent结束
    }
}