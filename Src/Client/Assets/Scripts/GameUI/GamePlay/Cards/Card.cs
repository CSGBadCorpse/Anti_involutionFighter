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
        Damage,
        Recover,
        Pass,

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

    public partial class  Card :MonoBehaviour
    {
        [SerializeField]
        protected ulong id;

        [SerializeField]
        [Header("卡牌名称")]
        protected string cardName = "N/A";

        [SerializeField]
        [Header("卡牌描述")]
        protected string cardDescription = "N/A";

        [SerializeField]
        [Header("卡牌消耗点数")]
        protected int cost;
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
        private Image frontImage;
        [SerializeField]
        [Header("卡牌反面图")]
        private Image backImage;

        private bool turnState = false;//是否翻面
        private bool showState = false;

        public Card(ulong id, string name, string description, int cost)
        {
            this.id = id;
            this.cardName = name;
            // this.cardType = cardType;
            this.cardDescription = description;
            this.cost = cost;
            // // this.damage = damage;
            // // this.recover = recover;
            // // this.isCoutinued = isCountinued;
        }

        // protected Card()
        // {
        //     throw new NotImplementedException();
        // }


        #region 属性
        public ulong Id{ get { return id; } }
        public string Name{get { return cardName; } }
        public string Description{ get { return cardDescription; } }
        public int Cost{ get { return cost; } }
        // public int Damage{ get { return damage; } }
        // public int Recover{ get { return recover; } }
        // public bool IsCoutinued { get {  return isCoutinued; } }
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
}

