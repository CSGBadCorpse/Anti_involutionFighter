using YIUIFramework;

namespace YIUICodeGenerated
{
    /// <summary>
    /// 由YIUI工具自动创建 请勿手动修改
    /// 用法: UIBindHelper.InternalGameGetUIBindVoFunc = YIUICodeGenerated.UIBindProvider.Get;
    /// </summary>
    public static class UIBindProvider
    {
        public static UIBindVo[] Get()
        {
            var BasePanel     = typeof(BasePanel);
            var BaseView      = typeof(BaseView);
            var BaseComponent = typeof(BaseComponent);
            var list          = new UIBindVo[1];
            list[0] = new UIBindVo
            {
                PkgName     = Fighter.Battle.BattlePanelBase.PkgName,
                ResName     = Fighter.Battle.BattlePanelBase.ResName,
                CodeType    = BasePanel,
                BaseType    = typeof(Fighter.Battle.BattlePanelBase),
                CreatorType = typeof(Fighter.Battle.BattlePanel),
            };

            return list;
        }
    }
}