using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

// [CreateAssetMenu()]
public class BuffScriptableObjectList : SerializedScriptableObject
{
    public Dictionary<ulong, BuffScriptableObject> _buffScriptableObjectsList;
}
