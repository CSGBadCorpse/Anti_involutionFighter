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
    [FriendOf(typeof(LoginPanelSourceComponent))]
    public static partial class LoginPanelSourceComponentSystem
    {
        [ObjectSystem]
        public class LoginPanelSourceComponentInitializeSystem: YIUIInitializeSystem<LoginPanelSourceComponent>
        {
            protected override void YIUIInitialize(LoginPanelSourceComponent self)
            {
            }
        }
        
        [ObjectSystem]
        public class LoginPanelSourceComponentDestroySystem: DestroySystem<LoginPanelSourceComponent>
        {
            protected override void Destroy(LoginPanelSourceComponent self)
            {
            }
        }
        
        [ObjectSystem]
        public class LoginPanelSourceComponentOpenSystem: YIUIOpenSystem<LoginPanelSourceComponent>
        {
            protected override async ETTask<bool> YIUIOpen(LoginPanelSourceComponent self)
            {
                await ETTask.CompletedTask;
                return true;
            }
        }
        
        #region YIUIEvent开始
        #endregion YIUIEvent结束
    }
}