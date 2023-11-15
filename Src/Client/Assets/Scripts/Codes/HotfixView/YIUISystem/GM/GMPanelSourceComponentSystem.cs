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
    [FriendOf(typeof(GMPanelSourceComponent))]
    public static partial class GMPanelSourceComponentSystem
    {
        [ObjectSystem]
        public class GMPanelSourceComponentInitializeSystem: YIUIInitializeSystem<GMPanelSourceComponent>
        {
            protected override void YIUIInitialize(GMPanelSourceComponent self)
            {
            }
        }
        
        [ObjectSystem]
        public class GMPanelSourceComponentDestroySystem: DestroySystem<GMPanelSourceComponent>
        {
            protected override void Destroy(GMPanelSourceComponent self)
            {
            }
        }
        
        [ObjectSystem]
        public class GMPanelSourceComponentOpenSystem: YIUIOpenSystem<GMPanelSourceComponent>
        {
            protected override async ETTask<bool> YIUIOpen(GMPanelSourceComponent self)
            {
                await ETTask.CompletedTask;
                return true;
            }
        }
        
        #region YIUIEvent开始
        #endregion YIUIEvent结束
    }
}