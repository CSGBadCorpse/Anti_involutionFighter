namespace GameUI.GamePlay
{
    public enum BuffType//特效类型
    {
        Buff,
        Debuff
    }
    public enum AffectProperty//影响属性
    {
        Blood,
        Defense,
        Energy,
        Pua,
    }
    public class Buff
    {
        private ulong _id;//buff唯一标识
        private string _name;//buff名称
        private int _value;//buff值
        private string _description;//buff描述
        private BuffType _buffType;//buff类型
        private int _count;//buff个数
        
        #region 属性

        public ulong ID
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Value
        {
            get => _value;
            set => _value = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public BuffType BuffType
        {
            get => _buffType;
            set => _buffType = value;
        }

        public int Count
        {
            get => _count;
            set => _count = value;
        }

        #endregion
        
        
        
    }
}