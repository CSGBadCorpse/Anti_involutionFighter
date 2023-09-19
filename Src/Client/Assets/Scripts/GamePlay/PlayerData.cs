using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerData
{
    private int m_bloodMax;
    private int m_bloodCur;

    private int m_energyMax;
    private int m_energyCur;


    private int m_puaValue;
    private string m_name = "N/A";

    //private Dictionary<long, Card> m_cards ;
    private List<Card> m_cards;

    public PlayerData(int bloodMax, int energyMax, int puaValue, string name)
    {
        m_bloodMax = bloodMax;
        m_bloodCur = bloodMax;
        m_energyMax = energyMax;
        m_energyCur = energyMax;
        m_puaValue = puaValue;
        m_name = name;
        //m_cards = new Dictionary<long,Card>();
        m_cards = new List<Card>();
    }

    #region 属性
    public int Blood{ get{ return m_bloodCur; } }
    public int BloodMax{ get{ return m_bloodMax; } }
    public int Energy{ get{ return m_energyCur; } }
    public int EnergyMax{ get { return m_energyMax; } }
    public int PuaValue{ get{ return m_puaValue; } }
    public string Name{ get{ return m_name; } }
    #endregion


    #region 方法

    public void GetHit(int damage)//受伤
    {
        Decrease(ref m_bloodCur, damage);
    }

    public void Recover(int healValue)//恢复
    {
        Increase(ref m_bloodCur, ref m_bloodMax, healValue);
    }

    public void CostEnergy(int energyCost)
    {
        Decrease(ref m_energyCur, energyCost);
    }

    public void RecoverEnergy(int energyValue)
    {
        Increase(ref m_energyCur, ref m_energyMax, energyValue);
    }

    public void PuaIncrease(int puaIncreaseValue)
    {
        Increase(ref m_puaValue, puaIncreaseValue);
    }
    public void PuaDecrease(int puaDecreaseValue)
    {
        Decrease(ref m_puaValue,puaDecreaseValue);
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
        return m_cards.Count == 0;
    }
    public void AddCard(Card card)
    {
        this.m_cards.Add(card);
    }
    //public void RemoveCard(Card card)
    //{
    //    this.m_cards.Remove(card);
    //}
    public void UpdateCards(List<Card> cards)
    {
        m_cards=cards;
    }
    public Card GetCard(int index)
    {
        return this.m_cards[index];
    }

    #endregion
}
 