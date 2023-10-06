using UnityEngine;

public class UiView : MonoBehaviour
{
    public Canvas canvas;
    public GameObject viewGameObject;

    private UiConfig mUiConfig;

    public int SelfViewId
    {
        get
        {
            if (mUiConfig != null)
            {
                return mUiConfig.viewId;
            }
            return 0;
        }
    }
    public int LayerType
    {
        get
        {
            if (mUiConfig != null)
            {
                return mUiConfig.layerType;
            }
            return UiConfigManager.None;
        }
    }
    public int SortingOrder
    {
        get
        {
            if (canvas != null)
            {
                return canvas.sortingOrder;
            }
            return 0;
        }
        set
        {
            if(canvas != null) 
            {
                canvas.sortingOrder = value;
            }
        }

    }
    public bool IsLarge
    {
        get
        {
            if (mUiConfig != null)
            {
                return mUiConfig.isLarge;
            }
            return false;
        }
    }

    protected RectTransform mCanvasRectTransform;
    protected RectTransform mViewRectTransform;

    protected void InnerInitialize()
    {
        if(mCanvasRectTransform == null && canvas != null)
        {
            mCanvasRectTransform = canvas.GetComponent<RectTransform>();
        }
        if(mViewRectTransform == null && canvas != null)
        {
            mViewRectTransform = viewGameObject.GetComponent<RectTransform>();
        }
    }


    public virtual void Awake()
    {
        InnerInitialize();
        UpdateBangHeight();
    }

    public void SetUiConfig(UiConfig uiConfig)
    {
        mUiConfig = uiConfig;
    }

    public virtual void OnLoad()
    {
        if (canvas == null)
        {
            canvas = GetComponent<Canvas>();
        }
        if(mUiConfig != null)
        {
            canvas.sortingLayerName = "Ui";
            canvas.sortingOrder = mUiConfig.layerType;
        }
    }

    public virtual void OnShow()
    {

    }

    public virtual void OnHide()
    {

    }
    public virtual void OnRemove()
    {

    }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
        if(active)
        {
            OnShow();
        }
        else
        {
            OnHide();
        }
    }
    public void SetViewActive(bool active)
    {
        if(viewGameObject != null)
        {
            viewGameObject.SetActive(active);
        }
    }
    public int GetViewId()
    {
        if (mUiConfig != null)
        {
            return mUiConfig.viewId;
        }
        return 0;
    }
    public void RemoveSelf()
    {
        GameUi.Instance.RemoveView(this);
    }
    public void UpdateBangHeight()
    {
        if(mViewRectTransform != null)
        {
            int bangHeight = GetBangHeight();
            mViewRectTransform.offsetMax -= new Vector2(0, bangHeight);
        }
    }
    public int GetBangHeight()
    {
#if UNITY_IOS
        if(UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhone11)
        {
            return 90;
        }
        else if(UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhone12)
        {
            return 90;
        }
        else if(UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhone12Pro)
        {
            return 90;
        }
        else if(UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhone12ProMax)
        {
            return 85;
        }
        else if(UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhone12Mini)
        {
            return 100;
        }
        else if (UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhoneX)
        {
            return 90;
        }
        else if (UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhoneXR)
        {
            return 90;
        }
        else if (UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhoneXS)
        {
            return 90;
        }
        else if (UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhoneXS)
        {
            return 80;
        }
#elif UNITY_ANDROID
        if(!string.IsNullOrEmpty(SystemInfo.deviceModel))
        {
            if(SystemInfo.deviceModel.Contains("HUAWEI EML-L29"))
            {
                return 80;
            }
        }
#endif
        if(mCanvasRectTransform != null && mViewRectTransform != null)
        {
            int bangHeight = Screen.height - (int)Screen.safeArea.height;
            return bangHeight;
        }
        return 0;
    }
}
