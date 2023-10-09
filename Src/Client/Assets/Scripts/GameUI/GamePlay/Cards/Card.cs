using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GameUI.GamePlay.Cards
{
    public enum CardType
    {
        Common,//通用
        Programmer,//程序员
        Art,//美术
        MasterMind,//策划
    }
    #if UNITY_EDITOR //inspector面板显示
    // [CustomEditor(typeof(Card))]
    // public class CardInspector : Editor
    // {
    //     private SerializedObject obj;
    //     private Card card;
    //     private SerializedProperty iterator;
    //     private List<string> propertyNames;
    //     private CardType cardTypeGetValue;
    //     private Dictionary<string, CardType> specialPropertys
    //         = new Dictionary<string, CardType>
    //         {
    //             { "damage", CardType.Damage },//表示字段a只会在枚举值=typeA时显示
    //             { "recover", CardType.Recover }
    //         };
    //     void OnEnable()
    //     {
    //         obj = new SerializedObject(target);
    //         iterator = obj.GetIterator();
    //         iterator.NextVisible(true);
    //         propertyNames = new List<string>();
    //         do
    //         {
    //             propertyNames.Add(iterator.name);
    //         } while (iterator.NextVisible(false));
    //         card = (Card)target;
    //     }
    //
    //     public override void OnInspectorGUI()
    //     {
    //         obj.Update();
    //         GUI.enabled = false;
    //         foreach (var name in propertyNames)
    //         {
    //             if (specialPropertys.TryGetValue(name, out cardTypeGetValue)
    //                 && cardTypeGetValue != card.cardType)
    //                 continue;
    //             EditorGUILayout.PropertyField(obj.FindProperty(name));
    //             if (!GUI.enabled)//让第1次遍历到的 Script 属性为只读
    //                 GUI.enabled = true;
    //         }
    //         obj.ApplyModifiedProperties();
    //     }
    // }
    #endif

    public abstract class  Card :MonoBehaviour
    {
        [SerializeField]
        protected ulong _id;

        [SerializeField]
        [Header("卡牌名称")]
        protected string _cardName = "N/A";

        [SerializeField]
        [Header("卡牌描述")]
        protected string _cardDescription = "N/A";

        [SerializeField]
        [Header("卡牌消耗点数")]
        protected int _cost;
        //
        // [SerializeField]
        // [Header("卡牌类型")]
        // public CardType cardType;
        //
        // [SerializeField]
        // [Header("卡牌伤害值")]
        // private int damage;
        // [SerializeField]
        // [Header("卡牌恢复值")]
        // private int recover;
        //
        // [SerializeField] 
        // [Header("卡牌是否继续轮次")]
        // private bool isCoutinued;//是否继续使用者轮次

        [SerializeField]
        [Header("卡牌正面图")]
        private Image _frontImage;
        [SerializeField]
        [Header("卡牌反面图")]
        private Image _backImage;

        private bool _turnState = false;//是否翻面
        private bool _showState = false;

        public Card(ulong id, string name, string description, int cost)
        {
            this._id = id;
            this._cardName = name;
            // this.cardType = cardType;
            this._cardDescription = description;
            this._cost = cost;
            // // this.damage = damage;
            // // this.recover = recover;
            // // this.isCoutinued = isCountinued;
        }

        // protected Card()
        // {
        //     throw new NotImplementedException();
        // }


        #region 属性
        public ulong Id{ get { return _id; } }
        public string Name{get { return _cardName; } }
        public string Description{ get { return _cardDescription; } }
        public int Cost{ get { return _cost; } }
        // public int Damage{ get { return damage; } }
        // public int Recover{ get { return recover; } }
        // public bool IsCoutinued { get {  return isCoutinued; } }
        #endregion

        #region 方法
        public void TurnFront()
        {
            _turnState = true;
            //animation
        }
        public void TurnBack()
        {
            _turnState = false;
            //animation
        }

        public virtual void Show()
        {
            _showState = true;
        }
        public virtual void Hide()
        {
            _showState = false;
        }
        public abstract int ProcessCardEffect(ActorController actionActor, ActorController reciveActor);
        

        #endregion
    }
}

