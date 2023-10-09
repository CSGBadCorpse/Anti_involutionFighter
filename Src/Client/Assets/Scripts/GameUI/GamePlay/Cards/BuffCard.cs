using UnityEngine;

namespace GameUI.GamePlay.Cards
{
    public class BuffCard:Card
    {
        [SerializeField] private ulong _buffId;
        [SerializeField] private int _value;
        [SerializeField] private AffectProperty _affectProperty;
        public BuffCard(ulong id, string name, string description, int cost, int value, ulong buffId) : base(id, name, description, cost)
        {
            this._id = id;
            this._cardName = name;
            this._cardDescription = description;
            this._cost = cost;
            this._value = value;
            this._buffId = buffId;
        }

        public override int ProcessCardEffect(ActorController actionActor, ActorController reciveActor)
        {
            Buff effectBuff = BuffController.Instance.GetBuffScriptableObjectById(_buffId);
            reciveActor.GainBuff(effectBuff);
            return GamePlayUtil.Next;
        }
    }
}