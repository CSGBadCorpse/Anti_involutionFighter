using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum CardType
{
    Damage,
    Recover,
}
#if UNITY_EDITOR
[CustomEditor(typeof(Card))]
public class CardInspector : Editor
{
    private SerializedObject obj;
    private Card card;
    private SerializedProperty iterator;
    private List<string> propertyNames;
    private CardType cardTypeGetValue;
    private Dictionary<string, CardType> specialPropertys
        = new Dictionary<string, CardType>
        {
            { "damage", CardType.Damage },//表示字段a只会在枚举值=typeA时显示
            { "recover", CardType.Recover }
        };
    void OnEnable()
    {
        obj = new SerializedObject(target);
        iterator = obj.GetIterator();
        iterator.NextVisible(true);
        propertyNames = new List<string>();
        do
        {
            propertyNames.Add(iterator.name);
        } while (iterator.NextVisible(false));
        card = (Card)target;
    }

    public override void OnInspectorGUI()
    {
        obj.Update();
        GUI.enabled = false;
        foreach (var name in propertyNames)
        {
            if (specialPropertys.TryGetValue(name, out cardTypeGetValue)
                && cardTypeGetValue != card.cardType)
                continue;
            EditorGUILayout.PropertyField(obj.FindProperty(name));
            if (!GUI.enabled)//让第1次遍历到的 Script 属性为只读
                GUI.enabled = true;
        }
        obj.ApplyModifiedProperties();
    }


}
#endif

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
    public CardType cardType;

    [SerializeField]
    private float damage;
    [SerializeField]
    private float recover;

    [SerializeField]
    private Image frontImage;
    [SerializeField]
    private Image backImage;

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
