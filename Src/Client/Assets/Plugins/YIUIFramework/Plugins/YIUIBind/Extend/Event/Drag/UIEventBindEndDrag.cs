﻿using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace YIUIFramework
{
    /// <summary>
    /// 拖拽结束
    /// 与按钮无关
    /// 只要是任何可以被射线检测的物体都可以响应事件
    /// </summary>
    [LabelText("拖拽结束<obj>")]
    [AddComponentMenu("YIUIBind/Event/拖拽结束 【Drag】 UIEventBindEndDrag")]
    public class UIEventBindEndDrag: UIEventBind, IEndDragHandler
    {
        [SerializeField]
        [LabelText("可选组件")]
        private Selectable m_Selectable;

        [NonSerialized]
        private List<EUIEventParamType> m_FilterParamType = new List<EUIEventParamType> { EUIEventParamType.Object, };

        protected override List<EUIEventParamType> GetFilterParamType()
        {
            return m_FilterParamType;
        }

        private void Awake()
        {
            m_Selectable ??= GetComponent<Selectable>();
        }

        protected virtual void OnUIEvent(PointerEventData eventData)
        {
            //额外添加 如果想要这个点击事件 使用此监听
            //响应方法那边参数是obj 自己在转一次 没有扩展这个参数 因为没必要
            m_UIEvent?.Invoke(eventData as object);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (m_Selectable != null && !m_Selectable.interactable)
            {
                return;
            }

            try
            {
                OnUIEvent(eventData);
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                throw;
            }
        }
    }
}