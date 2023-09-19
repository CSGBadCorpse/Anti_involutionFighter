using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card: MonoBehaviour
{
    [SerializeField]
    protected long id;
    [SerializeField]
    protected string name = "N/A";
    [SerializeField]
    protected string description = "N/A";
    [SerializeField]
    protected int cost;

    [SerializeField]
    private SpriteRenderer frontImage;
    [SerializeField]
    private SpriteRenderer backImage;

    private bool turnState = false;//是否翻面
    private bool showState = false;

    

    //public Card(long id, string name, string descript, int cost)
    //{
    //    this.id = id;
    //    this.name = name;
    //    this.description = descript;
    //    this.cost = cost;
    //}


    #region 属性
    public long Id{ get { return id; } }
    public string Name{get { return name; } }
    public string Description{ get { return description; } }
    public int Cost{ get { return cost; } }
    #endregion

    #region 方法
    public void TurnFront()
    {
        turnState = true;
    }
    public void TurnBack()
    {
        turnState = false;
    }

    public virtual void Show()
    {
        showState = true;
    }
    public virtual void Hide()
    {
        showState = false;
    }
    #endregion
}
