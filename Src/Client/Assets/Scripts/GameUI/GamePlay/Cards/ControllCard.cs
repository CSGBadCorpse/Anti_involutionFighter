namespace GameUI.GamePlay.Cards
{
    /// <summary>
    /// 控制牌
    /// </summary>
    public class ControllCard:Card
    {
        public ControllCard(ulong id, string name, string description, int cost) : base(id, name, description, cost)
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