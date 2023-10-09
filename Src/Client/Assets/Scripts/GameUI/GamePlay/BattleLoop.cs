//using Newtonsoft.Json;
//using System.Collections;
//using UnityEditor.PackageManager;
using UnityEngine;
using GameUI.GamePlay.Cards;

//public class Test
//{
//    [JsonProperty("o")]
//    string o = "123";
//    [JsonProperty("p")]
//    string p = "456";
//    public Test(string o, string p) { this.o = o; this.p = p; }
//}
namespace GameUI.GamePlay
{
    
    public enum PlayerTurnState
    {
        OtherSide,
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

        private bool _isSelf;//是否为己方回合
        private int _turns;
        private bool _turnFinished;
        private PlayerTurnState _playerTurnState;
        private Card _actionCard = null;
        private void Start()
        {
            _playerTurnState = PlayerTurnState.Draw;
            _isSelf = true;//暂定，根据需求改
            _turns = 0;
            _turnFinished = false;
            //List<Card> list = new List<Card>();
            //DamageCard card = new DamageCard();
            //RecoverCard recoverCard = new RecoverCard();
            //list.Add(card);
            //list.Add(recoverCard);
            //Debug.Log(list[0].ToString());
            playerLeft.AddCard(new DamageCard(0, "需求不合理",  "程序员提出该需求不合理", 2, 2));
            playerRight.AddCard(new DamageCard(0, "今天是DeadLine",  "策划说今天是deadline", 2,2));
            
        }

        private void Update()
        {
            if (playerLeft.IsDead() && playerRight.IsDead())
            {
                Debug.Log("Draw!!!");
            }
            else if (!playerLeft.IsDead() && playerRight.IsDead())
            {
                Debug.Log("Win!!!");
            }
            else if (playerLeft.IsDead() && !playerRight.IsDead())
            {
                Debug.Log("Lose!!!");
            }
            //Test a = new Test("zzz", "zzz");
            //string b = JsonConvert.SerializeObject(a, Formatting.Indented);
            //Debug.Log(b);
            if (playerLeft.IsCardEmpty() && playerRight.IsCardEmpty())
            {
                //Debug.LogError("对局失败，双方卡牌为空");
            }
            //bool result;//如果连续出牌就相当于还是这一方操作，回合数不增加
            switch (_isSelf)
            {
                case true:

                    _turnFinished = false;
                    Debug.Log("你的回合");
                    
                    PlayerTurn(playerLeft, playerRight);

                    if (_turnFinished)
                    {
                        _isSelf = false;
                    }
                    break;
                case false:
                   
                    _turnFinished = false;
                    Debug.Log("敌方回合");
                    PlayerTurn(playerRight, playerLeft);
                    if (_turnFinished)
                    {
                        _isSelf = true;
                    }
                    break;
            }
            

        }

        private void PlayerTurn(PlayerController playerAction,//行动方
                                PlayerController playerReceiving)//被动方
        {
            switch (_playerTurnState)
            {
                case PlayerTurnState.Draw:
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Debug.Log("抽牌");
                        //dataProcess
                        _actionCard = playerAction.DrawCard(_turns);
                        //animation 多线程 
                        //changeState
                        _playerTurnState = PlayerTurnState.CardAction;
                    }

                    break;
                case PlayerTurnState.CardAction:
                    Debug.Log("卡牌效果");

                    int result = playerReceiving.ProcessCard(_actionCard);
                    //animation
                    //changeState
                    Debug.Log("结果："+result);
                    if(result == GamePlayUtil.NextTurn)
                    {
                        _playerTurnState = PlayerTurnState.End;
                    }
                    else if(result == GamePlayUtil.DontTurn)
                    {
                        _playerTurnState = PlayerTurnState.Draw;
                    }

                    break;
                case PlayerTurnState.UltrAction:
                    //animation
                    //changeState
                    Debug.Log("超级技能");
                    break;
                case PlayerTurnState.End:
                    Debug.Log("回合结束");
                    //changeState
                    _playerTurnState = PlayerTurnState.Draw;
                    Debug.Log("第"+_turns+"回合结束");
                    _turns++;
                    if (_turns >= 1)
                    {
                        _turns = 0;
                    }
                    _turnFinished = true;

                    break;
            }
        }
    }
}
