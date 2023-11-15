using YIUIFramework;

namespace ET.Client
{

    /// <summary>
    /// 由YIUI工具自动创建 请勿修改
    /// </summary>
    [YIUI(EUICodeType.Panel, EPanelLayer.Panel)]
    public partial class LobbyPanelSourceComponent : Entity, IDestroy, IAwake, IYIUIBind, IYIUIInitialize, IYIUIOpen
    {
        public const string PkgName = "Lobby";
        public const string ResName = "LobbyPanelSource";

        public YIUIComponent UIBase;
        public YIUIWindowComponent UIWindow;
        public YIUIPanelComponent UIPanel;

    }
}