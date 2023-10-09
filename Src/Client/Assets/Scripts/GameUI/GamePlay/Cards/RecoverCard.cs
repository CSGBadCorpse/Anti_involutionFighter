using UnityEngine;

namespace GameUI.GamePlay.Cards
{
    public class RecoverCard : Card
    {
        private int _recover;
        public RecoverCard(ulong id, string name, string description, int cost, int recover) : base(id, name, description, cost)
        {
            this._id = id;
            this._cardName = name;
            this._cardDescription = description;
            this._cost = cost;
            this._recover = recover;
        }
        public override int ProcessCardEffect(ActorController actionActor, ActorController reciveActor)
        {
            
            return GamePlayUtil.Next;

        }
    }
}