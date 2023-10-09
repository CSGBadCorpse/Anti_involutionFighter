using UnityEngine;
namespace GameUI.GamePlay.Cards
{
    public class DamageCard :  Card
    {
        private int _damage;
        public DamageCard(ulong id, string name, string description, int cost,int damage) :base(id, name, description, cost)
        {
            this._id = id;
            this._cardName = name;
            this._cardDescription = description;
            this._cost = cost;
            this._damage = damage;
        }
        public override int ProcessCardEffect(ActorController actionActor,ActorController reciveActor) 
        {
            
            return GamePlayUtil.Next;

        }
    }    
}