using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GameUI.GamePlay
{
    
public class PlayerData
{
    private int _bloodMax;
    [SerializeField]
    private int _bloodCur;

    private int _energyMax;
    private int _energyCur;


    private int _puaValue;
    private string _name = "N/A";

    //private Dictionary<long, Card> m_cards ;
    private List<Card> _cards;

    public PlayerData(int bloodMax, int energyMax, int puaValue, string name)
    {
        _bloodMax = bloodMax;
        _bloodCur = bloodMax;
        _energyMax = energyMax;
        _energyCur = energyMax;
        _puaValue = puaValue;
        _name = name;
        //m_cards = new Dictionary<long,Card>();
        _cards = new List<Card>();
    }

    #region 属性

    public int Blood => _bloodCur;
    public int BloodMax => _bloodMax;
    public int Energy => _energyCur; 
    public int EnergyMax => _energyMax; 
    public int PuaValue => _puaValue; 
    public string Name =>  _name; 
    #endregion


    #region 方法

    public void GetHit(int damage)//受伤
    {
        Decrease(ref _bloodCur, damage);
    }

    public void Recover(int healValue)//恢复
    {
        Increase(ref _bloodCur, ref _bloodMax, healValue);
    }

    public void CostEnergy(int energyCost)
    {
        Decrease(ref _energyCur, energyCost);
    }

    public void RecoverEnergy(int energyValue)
    {
        Increase(ref _energyCur, ref _energyMax, energyValue);
    }

    public void PuaIncrease(int puaIncreaseValue)
    {
        Increase(ref _puaValue, puaIncreaseValue);
    }
    public void PuaDecrease(int puaDecreaseValue)
    {
        Decrease(ref _puaValue,puaDecreaseValue);
    }

    private void Increase(ref int dataCur, int amount)//无上限增加
    {
        int a=-1;
        Increase(ref dataCur, ref a, amount);
    }
    private void Increase(ref int dataCur, ref int dataMax, int amount)//有上限
    {
        if (dataMax < 0)
        {
            dataCur += amount;
            return;
        }
        if ( dataCur < dataMax && amount > 0)
        {
            if (dataCur + amount > dataMax)
            {
                dataCur = dataMax;
                return;
            }
            dataCur += amount;
        }
    }
    private void Decrease(ref int dataCur, int amount)
    {
        if (dataCur > 0 && amount > 0)
        {
            if (dataCur - amount < 0)
            {
                dataCur = 0;
                return;
            }
            dataCur -= amount;
        }
    }

    public bool IsCardEmpty()
    {
        return _cards.Count == 0;
    }
    public void AddCard(Card card)
    {
        this._cards.Add(card);
    }
    //public void RemoveCard(Card card)
    //{
    //    this.m_cards.Remove(card);
    //}
    public void UpdateCards(List<Card> cards)
    {
        _cards=cards;
    }
    public Card GetCard(int index)
    {
        return this._cards[index];
    }

    #endregion
}
}
 