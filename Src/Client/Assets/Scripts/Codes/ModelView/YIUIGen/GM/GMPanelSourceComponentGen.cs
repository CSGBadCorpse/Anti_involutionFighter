using YIUIFramework;

namespace ET.Client
{

    /// <summary>
    /// 由YIUI工具自动创建 请勿修改
    /// </summary>
    [YIUI(EUICodeType.Panel, EPanelLayer.Panel)]
    public partial class GMPanelSourceComponent : Entity, IDestroy, IAwake, IYIUIBind, IYIUIInitialize, IYIUIOpen
    {
        public const string PkgName = "GM";
        public const string ResName = "GMPanelSource";

        public YIUIComponent UIBase;
        public YIUIWindowComponent UIWindow;
        public YIUIPanelComponent UIPanel;
        public ET.Client.GMViewComponent u_UIGMView;

    }
}