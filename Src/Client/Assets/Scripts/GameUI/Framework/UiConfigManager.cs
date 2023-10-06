using System.Collections.Generic;
using UnityEngine.Rendering;

public enum ViewId
{
    None,
    DemoUi=10,
    SuperList=20,
    SuperGrid = 30,
    Max,
}

public class UiConfigManager
{
    public const int None = -1;
    public const int Back = 100;
    public const int System = 200;
    public const int Menu = 300;
    public const int Dialog = 400;
    public const int MessageBox = 500;
    public const int MessageTip = 600;
    public const int Story = 700;
    public const int Guide = 800;
    public const int Loading = 900;
    public const int Max = 1000;

    private const string Demo_Path = "GameUi/DemoUi/prefab/DemoUi";//根目录是Resources
    private const string SuperList_Path = "GameUi/SuperListUi/prefab/SuperListUi";
    private const string SuperGrid_Path = "GameUi/SuperGridUi/prefab/SuperGridUi";

    private static Dictionary<int, UiConfig> uiDictionary = new Dictionary<int, UiConfig>()
    {
        { (int)ViewId.DemoUi,new UiConfig((int)ViewId.DemoUi,Demo_Path,System)},
        { (int)ViewId.SuperList,new UiConfig((int)ViewId.SuperList,SuperList_Path,System)},
        { (int)ViewId.SuperGrid,new UiConfig((int)ViewId.SuperGrid,SuperGrid_Path,System)},
    };
    public static UiConfig GetConfig(int viewId)
    {
        if(uiDictionary.ContainsKey(viewId))
        {
            return uiDictionary[viewId];
        }
        return null;
    }
    public static void AddConfig(UiConfig uiConfig)
    {
        if(uiConfig != null && !uiDictionary.ContainsKey(uiConfig.viewId))
        {
            uiDictionary.Add(uiConfig.viewId, uiConfig);
        }
    }
    public static void RemoveConfig(int viewId)
    {
        if (uiDictionary.ContainsKey(viewId))
        {
            uiDictionary.Remove(viewId);
        }
    }
}