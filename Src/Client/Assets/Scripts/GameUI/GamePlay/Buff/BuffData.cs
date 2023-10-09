namespace GameUI.GamePlay
{
    public enum BuffType//特效类型
    {
        Buff,
        Debuff
    }
    public enum AffectProperty//影响属性
    {
        Attack,
        Blood,
        Defense,
        Energy,
        Pua,
    }
    public class BuffData
    {
        private string _name;//buff名称
        private int _value;//buff值
        private string _description;//buff描述
        private string _buffType;//buff类型

        #region 属性
        public string Name => _name;

        public int Value => _value;

        public string Description => _description;

        #endregion
        
    }
}