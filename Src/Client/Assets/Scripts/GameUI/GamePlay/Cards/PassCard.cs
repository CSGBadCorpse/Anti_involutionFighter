using UnityEngine;
namespace GameUI.GamePlay.Cards
{
    /// <summary>
    /// 过卡牌，再抽一张卡
    /// </summary>
    public class PassCard : Card
    {
        [SerializeField]
        private int _damage;
        public PassCard(ulong id, string name, string description, int cost, int damage) : base(id, name, description, cost)
        {
            this._id = id;
            this._cardName = name;
            this._cardDescription = description;
            this._cost = cost;
            this._damage = damage;
        }
        public override int ProcessCardEffect(ActorController actionActor, ActorController reciveActor)
        {

            return GamePlayUtil.Hold;

        }
    }
}