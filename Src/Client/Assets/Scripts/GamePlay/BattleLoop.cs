using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

//public class Test
//{
//    [JsonProperty("o")]
//    string o = "123";
//    [JsonProperty("p")]
//    string p = "456";
//    public Test(string o, string p) { this.o = o; this.p = p; }
//}

public enum PlayerTurnState
{
    Draw,
    CardAction,
    UltrAction,
    End
} 

public class BattleLoop : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerLeft;//己方
    [SerializeField] 
    private PlayerController playerRight;//敌方

    private bool isSelf;//是否为己方回合
    private int turns;
    private bool turnFinished;
    private PlayerTurnState playerTurnState;
    private void Start()
    {
        playerTurnState = PlayerTurnState.Draw;
        isSelf = true;//暂定，根据需求改
        turns = 0;
        turnFinished = false;
        List<Card> list = new List<Card>();
        DamageCard card = new DamageCard();
        RecoverCard recoverCard = new RecoverCard();
        list.Add(card);
        list.Add(recoverCard);
        //Debug.Log(list[0].ToString());

    }

    private void Update()
    {
        //Test a = new Test("zzz", "zzz");
        //string b = JsonConvert.SerializeObject(a, Formatting.Indented);
        //Debug.Log(b);
        if (playerLeft.IsCardEmpty() && playerRight.IsCardEmpty())
        {
            //Debug.LogError("对局失败，双方卡牌为空");
        }
        //bool result;//如果连续出牌就相当于还是这一方操作，回合数不增加
        switch (isSelf)
        {
            case true:
                //if (result)
                //{
                //    isSelf = false;
                //    turns++;//只有满足条件切换行动方，回合数才增加
                //}
                PlayerTurn(playerLeft, playerRight);
                break;
            case false:
                //result = Battle(playerLeft, playerRight);
                //if (result)
                //{
                //    isSelf = true;
                //    turns++;//只有满足条件切换行动方，回合数才增加
                //}
                PlayerTurn(playerRight, playerLeft);
                break;
        }

    }

    private void PlayerTurn(PlayerController playerAction,//行动方
                            PlayerController playerReceiving)//被动方
    {
        switch (playerTurnState)
        {
            case PlayerTurnState.Draw:
                //dataProcess
                Card card = playerAction.DrawCard(turns);
                //if(card.)
                //animation
                break;
            case PlayerTurnState.CardAction:
                break;
            case PlayerTurnState.UltrAction:
                break;
            case PlayerTurnState.End:
                break;
        }
    }
}
