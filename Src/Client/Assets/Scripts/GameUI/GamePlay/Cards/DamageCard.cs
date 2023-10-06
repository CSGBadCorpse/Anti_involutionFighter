using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCard : Card
{
    //[SerializeField]
    //private int damage;
    public DamageCard(long id, string name, CardType cardType, string description, int cost, int damage = 0, int recover = 0, bool isCountinued = false) : base(id, name, cardType, description, cost, damage, recover, isCountinued)
    {
    }
}
