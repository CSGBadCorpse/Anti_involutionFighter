using GameUI.GamePlay;
using UnityEngine;

[CreateAssetMenu()]
public class BuffScriptableObject:ScriptableObject
{
    public ulong _id;//buff唯一标识
    public string _name;//buff名称
    public int _value;//buff值
    public string _description;//buff描述
    public BuffType _buffType;//buff类型
    public int _count;//buff个数
}