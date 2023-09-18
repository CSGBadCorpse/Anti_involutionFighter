using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card 
{
    protected long id;
    protected string name;
    protected string description;

    [SerializeField]
    private Image frontImage;
    [SerializeField]
    private Image backImage;

    private bool turnState = false;//是否翻面
    private bool showState = false;


    public void TurnFront()
    {
        turnState = true;
    }
    public void TurnBack()
    {
        turnState = false;
    }
}
