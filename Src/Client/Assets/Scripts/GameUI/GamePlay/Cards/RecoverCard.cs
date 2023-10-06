using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverCard : Card
{
    [SerializeField]
    private int recover;

    public RecoverCard(long id, string name, CardType cardType, string description, int cost, int damage = 0, int recover = 0, bool isCountinued = false) : base(id, name, cardType, description, cost, damage, recover, isCountinued)
    {
    }
}
