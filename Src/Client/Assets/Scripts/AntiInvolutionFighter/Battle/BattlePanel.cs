using System;
using YIUIBind;
using YIUIFramework;
using UnityEngine;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Fighter.Battle
{
    /// <summary>
    /// Author  YIUI
    /// Date    2023.10.12
    /// </summary>
    public sealed partial class BattlePanel:BattlePanelBase
    {
        public int i = 0;
        #region 生命周期
        
        protected override void Initialize()
        {
            Debug.Log($"BattlePanel Initialize");
        }

        protected override void Start()
        {
            Debug.Log($"BattlePanel Start");
        }

        protected override void OnEnable()
        {
            Debug.Log($"BattlePanel OnEnable");
        }

        protected override void OnDisable()
        {
            Debug.Log($"BattlePanel OnDisable");
        }

        protected override void OnDestroy()
        {
            Debug.Log($"BattlePanel OnDestroy");
        }

        protected override async UniTask<bool> OnOpen()
        {
            u_ComSkillButton.onClick.AddListener(() =>
            {
                Debug.Log("u_ComSkillButton.onClick");
                i++;
                u_DataName.SetValue("程序员"+i);
            });
            
            await UniTask.CompletedTask;
            Debug.Log($"BattlePanel OnOpen");
            return true;
        }

        protected override async UniTask<bool> OnOpen(ParamVo param)
        {
            return await base.OnOpen(param);
        }
        
        #endregion

        #region Event开始
        
        // protected override void OnEventOnSceneLoadAction()
        // {
        //     
        // }
        #endregion Event结束

    }
}