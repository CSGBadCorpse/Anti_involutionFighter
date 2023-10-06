using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRecordData
{
    public int viewId;
    public object customData;
}

public class GameUi : MonoBehaviour
{
    public static GameUi Instance;
    public System.Action<UiView> OnShowViewEvent;
    public System.Action<UiView> OnRemoveViewEvent;

    public Camera uiCamera;

    private List<UiLayer> mLayerList = new List<UiLayer>();
    private Stack<UIRecordData> mRecordDataStack = new Stack<UIRecordData>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }

    private void OnDestroy()
    {
        
    }

    public UiLayer GetLayer(int layerType)
    {
        for(int i = 0; i < mLayerList.Count; i++)
        {
            if (mLayerList[i] != null && mLayerList[i].layerType == layerType)
            {
                return mLayerList[i];
            }
        }
        return null;
    }
    public UiLayer GetAddLayer(int layerType)
    {
        UiLayer uiLayer = GetLayer(layerType);
        if (uiLayer == null)
        {
            uiLayer = new UiLayer();
            uiLayer.layerType = layerType;

            mLayerList.Add(uiLayer);
        }
        return uiLayer;
    }
    public void AddView(UiView uiView)
    {
        if(uiView != null)
        {
            UiLayer uiLayer = GetAddLayer(uiView.LayerType);
            if(uiLayer != null)
            {
                uiLayer.AddView(uiView);
            }
        }
    }
    public UiView ShowView(int viewId) 
    {
        UiConfig uiConfig = UiConfigManager.GetConfig(viewId);
        if(uiConfig != null && !string.IsNullOrEmpty(uiConfig.pathFileName))
        {
            for(int i = 0; i < uiConfig.closeLayerList.Count; ++i) 
            {
                OptimizeCloseLayer(uiConfig.closeLayerList[i]);
            }

            UiView uiView = GetView(uiConfig);
            if(uiView == null)
            {
                Object assetObject = Resources.Load(uiConfig.pathFileName);
                if(assetObject != null)
                {
                    GameObject uiGameObject = Instantiate(assetObject) as GameObject;
                    if(uiGameObject != null)
                    {
                        uiGameObject.transform.SetParent(transform, false);
                        UnityTools.ResetTransform(uiGameObject.transform);
                        Canvas canvas = uiGameObject.GetComponent<Canvas>();
                        canvas.worldCamera = uiCamera;

                        uiView = uiGameObject.GetComponent<UiView>();
                        if(uiView != null)
                        {
                            uiView.SetUiConfig(uiConfig);
                            uiView.OnLoad();

                            AddView(uiView);

                            uiView.SetActive(true);
                        }
                        else
                        {
                            Debug.Log(viewId + " Needs a UIView Script!!!");
                        }
                    }
                }
                else
                {
                    Debug.Log(uiConfig.pathFileName + " can't be loaded!!!");
                }
            }
            else
            {
                uiView.SetActive(true);
            }
            if(OnShowViewEvent != null && uiView != null )
            {
                OnShowViewEvent(uiView);
            }
            return uiView;
        }
        return null;
    }
    public UiView GetView(UiConfig uiConfig)
    {
        if(uiConfig != null)
        {
            UiLayer uiLayer = GetAddLayer(uiConfig.layerType);
            if(uiLayer != null)
            {
                UiView uiView = uiLayer.GetView(uiConfig.viewId);
                if(uiView != null)
                {
                    return uiView;
                }
            }
        }
        return null;
    }

    public UiView GetView(int viewId)
    {
        UiConfig uiConfig = UiConfigManager.GetConfig(viewId);
        UiView uiView = GetView(uiConfig);

        return uiView;
    }

    public void RemoveView(int viewId)
    {
        UiConfig uiConfig = UiConfigManager.GetConfig(viewId);
        if(uiConfig != null)
        {
            UiLayer uiLayer = GetAddLayer(uiConfig.layerType);
            if(uiLayer != null )
            {
                uiLayer.RemoveView(viewId);
            }
        }
    }

    public void RemoveView(UiView uiView)
    {
        if (uiView != null)
        {
            UiLayer uiLayer = GetAddLayer(uiView.LayerType);
            if(uiLayer != null)
            {
                uiLayer.RemoveView(uiView);
            }
            if(OnRemoveViewEvent != null)
            {
                OnRemoveViewEvent(uiView);
            }
        }
    }

    public bool HasView(int viewId)
    {
        UiConfig uiConfig = UiConfigManager.GetConfig(viewId);
        if(uiConfig != null )
        {
            UiLayer uiLayer = GetAddLayer(uiConfig.layerType);
            if(uiLayer != null && uiLayer.HasView(viewId))
            {
                return true;
            }
        }
        return false;
    }

    public void ClearLayer(int layerType)
    {
        UiLayer uiLayer = GetAddLayer(layerType);
        if (uiLayer != null)
        {
            uiLayer.ClearLayer();
        }
    }

    public void OptimizeCloseLayer(int layerType)
    {
        UiLayer uiLayer = GetAddLayer(layerType);
        if(uiLayer != null)
        {
            uiLayer.OptimizeCloseLayer();
        }
    }

    public void CloseAllLayer()
    {
        for(int i = 0;i<mLayerList.Count;i++)
        {
            mLayerList[i].ClearLayer();
        }
    }
    public void ClearRecordData()
    {
        mRecordDataStack.Clear();
    }
    public void SetRecordData(int viewId,object customeData = null)
    {
        ClearRecordData();
        UIRecordData uiRecordData = new UIRecordData();
        uiRecordData.viewId = viewId;
        uiRecordData.customData = customeData;

        mRecordDataStack.Push(uiRecordData);
    }
    public void PushRecordData(int viewId, object customeData )
    {
        UIRecordData uiRecordData = new UIRecordData();
        uiRecordData.viewId = viewId;
        uiRecordData.customData = customeData;

        mRecordDataStack.Push(uiRecordData);
    }
    public UIRecordData PopRecordData()
    {
        if(mRecordDataStack.Count != 0)
        {
            return mRecordDataStack.Pop();

        }
        return null;
    }

}
