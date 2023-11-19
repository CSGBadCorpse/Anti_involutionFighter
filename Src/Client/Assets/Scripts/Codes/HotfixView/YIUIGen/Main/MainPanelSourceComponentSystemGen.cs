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
    public static partial class MainPanelSourceComponentSystem
    {
        [ObjectSystem]
        public class MainPanelSourceComponentYIUIBindSystem: YIUIBindSystem<MainPanelSourceComponent>
        {
            protected override void YIUIBind(MainPanelSourceComponent self)
            {
                self.UIBind();
            }
        }
        
        private static void UIBind(this MainPanelSourceComponent self)
        {
            self.UIBase = self.GetParent<YIUIComponent>();
            self.UIWindow = self.UIBase.GetComponent<YIUIWindowComponent>();
            self.UIPanel = self.UIBase.GetComponent<YIUIPanelComponent>();
            self.UIWindow.WindowOption = EWindowOption.None;
            self.UIPanel.Layer = EPanelLayer.Panel;
            self.UIPanel.PanelOption = EPanelOption.ForeverCache|EPanelOption.DisClose;
            self.UIPanel.StackOption = EPanelStackOption.VisibleTween;
            self.UIPanel.Priority = 0;


        }
    }
}