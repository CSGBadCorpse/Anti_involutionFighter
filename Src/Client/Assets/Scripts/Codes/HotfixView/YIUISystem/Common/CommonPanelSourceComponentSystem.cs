using System;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{
    /// <summary>
    /// Author  YIUI
    /// Date    2023.11.15
    /// Desc
    /// </summary>
    [FriendOf(typeof(CommonPanelSourceComponent))]
    public static partial class CommonPanelSourceComponentSystem
    {
        [ObjectSystem]
        public class CommonPanelSourceComponentInitializeSystem: YIUIInitializeSystem<CommonPanelSourceComponent>
        {
            protected override void YIUIInitialize(CommonPanelSourceComponent self)
            {
            }
        }
        
        [ObjectSystem]
        public class CommonPanelSourceComponentDestroySystem: DestroySystem<CommonPanelSourceComponent>
        {
            protected override void Destroy(CommonPanelSourceComponent self)
            {
            }
        }
        
        [ObjectSystem]
        public class CommonPanelSourceComponentOpenSystem: YIUIOpenSystem<CommonPanelSourceComponent>
        {
            protected override async ETTask<bool> YIUIOpen(CommonPanelSourceComponent self)
            {
                await ETTask.CompletedTask;
                return true;
            }
        }
        
        #region YIUIEvent开始
        #endregion YIUIEvent结束
    }
}