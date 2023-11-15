using System;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{
    /// <summary>
    /// 由YIUI工具自动创建 请勿修改
    /// </summary>
    [FriendOf(typeof(YIUIComponent))]
    [FriendOf(typeof(YIUIWindowComponent))]
    [FriendOf(typeof(YIUIPanelComponent))]
    public static partial class LobbyPanelSourceComponentSystem
    {
        [ObjectSystem]
        public class LobbyPanelSourceComponentYIUIBindSystem: YIUIBindSystem<LobbyPanelSourceComponent>
        {
            protected override void YIUIBind(LobbyPanelSourceComponent self)
            {
                self.UIBind();
            }
        }
        
        private static void UIBind(this LobbyPanelSourceComponent self)
        {
            self.UIBase = self.GetParent<YIUIComponent>();
            self.UIWindow = self.UIBase.GetComponent<YIUIWindowComponent>();
            self.UIPanel = self.UIBase.GetComponent<YIUIPanelComponent>();
            self.UIWindow.WindowOption = EWindowOption.None;
            self.UIPanel.Layer = EPanelLayer.Panel;
            self.UIPanel.PanelOption = EPanelOption.None;
            self.UIPanel.StackOption = EPanelStackOption.VisibleTween;
            self.UIPanel.Priority = 0;


        }
    }
}