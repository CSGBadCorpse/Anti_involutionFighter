﻿using System;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{
    /// <summary>
    /// 由YIUI工具自动创建 请勿修改
    /// </summary>
    [FriendOf(typeof(YIUIComponent))]
    [FriendOf(typeof(YIUIWindowComponent))]
    [FriendOf(typeof(YIUIViewComponent))]
    public static partial class TextTipsViewComponentSystem
    {
        [ObjectSystem]
        public class TextTipsViewComponentYIUIBindSystem: YIUIBindSystem<TextTipsViewComponent>
        {
            protected override void YIUIBind(TextTipsViewComponent self)
            {
                self.UIBind();
            }
        }
        
        private static void UIBind(this TextTipsViewComponent self)
        {
            self.UIBase = self.GetParent<YIUIComponent>();
            self.UIWindow = self.UIBase.GetComponent<YIUIWindowComponent>();
            self.UIView = self.UIBase.GetComponent<YIUIViewComponent>();
            self.UIWindow.WindowOption = EWindowOption.BanTween|EWindowOption.BanAwaitOpenTween|EWindowOption.BanAwaitCloseTween|EWindowOption.SkipOtherOpenTween|EWindowOption.SkipOtherCloseTween;
            self.UIView.ViewWindowType = EViewWindowType.Popup;
            self.UIView.StackOption = EViewStackOption.VisibleTween;

            self.u_ComContent = self.UIBase.ComponentTable.FindComponent<UnityEngine.RectTransform>("u_ComContent");
            self.u_ComAnimation = self.UIBase.ComponentTable.FindComponent<UnityEngine.Animation>("u_ComAnimation");
            self.u_DataMessageContent = self.UIBase.DataTable.FindDataValue<YIUIFramework.UIDataValueString>("u_DataMessageContent");

        }
    }
}