using UnityEngine;
namespace GameUI.GamePlay.Cards
{
    public class DamageCard :  Card
    {
        private int _damage;
        public DamageCard(ulong id, string name, string description, int cost,int damage) :base(id, name, description, cost)
        {
            this.id = id;
            this.cardName = name;
            this.cardDescription = description;
            this.cost = cost;
        }
    }    
}