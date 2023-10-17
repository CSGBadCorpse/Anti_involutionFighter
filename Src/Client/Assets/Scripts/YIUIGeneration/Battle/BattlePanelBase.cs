using System;
using YIUIBind;
using YIUIFramework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Fighter.Battle
{



    /// <summary>
    /// 由YIUI工具自动创建 请勿手动修改
    /// </summary>
    public abstract class BattlePanelBase:BasePanel
    {
        public const string PkgName = "Battle";
        public const string ResName = "BattlePanel";
        
        public override EWindowOption WindowOption => EWindowOption.None;
        public override EPanelLayer Layer => EPanelLayer.Panel;
        public override EPanelOption PanelOption => EPanelOption.None;
        public override EPanelStackOption StackOption => EPanelStackOption.VisibleTween;
        public override int Priority => 0;
        public UnityEngine.UI.Button u_ComSkillButton { get; private set; }
        public YIUIBind.UIDataValueString u_DataName { get; private set; }

        
        protected sealed override void UIBind()
        {
            u_ComSkillButton = ComponentTable.FindComponent<UnityEngine.UI.Button>("u_ComSkillButton");
            u_DataName = DataTable.FindDataValue<YIUIBind.UIDataValueString>("u_DataName");

        }

        protected sealed override void UnUIBind()
        {

        }
     
   
   
    }
}