using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class BattleLoop : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerLeft;//己方
    [SerializeField] 
    private PlayerController playerRight;//敌方

    private bool isSelf;//是否为己方回合
    private int turns;
    private void Start()
    {
        isSelf = true;//暂定，根据需求改
        turns = 0;
    }

    private void Update()
    {
        if(playerLeft.IsCardEmpty() && playerRight.IsCardEmpty())
        {
            //Debug.LogError("对局失败，双方卡牌为空");
        }
        bool result;//如果连续出牌就相当于还是这一方操作，回合数不增加
        switch (isSelf) 
        {
            case true:
                result = Battle(playerLeft, playerRight);
                if (result)
                {
                    isSelf=false;
                    turns++;//只有满足条件切换行动方，回合数才增加
                }
                break;
            case false:
                result = Battle(playerLeft, playerRight);
                if (result)
                {
                    isSelf = true;
                    turns++;//只有满足条件切换行动方，回合数才增加
                }
                break;
        }
    }

    public bool Battle(PlayerController playerController, PlayerController playerRight)
    {

        return false;
    }
}
