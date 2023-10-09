namespace GameUI.GamePlay.Cards
{
    /// <summary>
    /// 消耗牌
    /// 使用一次就消失
    /// </summary>
    public class ConsumingCard:Card
    {
        public ConsumingCard(ulong id, string name, string description, int cost) : base(id, name, description, cost)
        {
            this._id = id;
            this._cardName = name;
            this._cardDescription = description;
            this._cost = cost;
        }

        public override int ProcessCardEffect(ActorController actionActor, ActorController reciveActor)
        {
            return GamePlayUtil.Next;
        }
    }
}