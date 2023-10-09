using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI.GamePlay
{
    public class BuffController:MonoBehaviour
    {
        public static BuffController Instance { get; private set; }
        [SerializeField]
        private BuffScriptableObjectList _buffsScriptableObject;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {

        }
        
        public Buff GetBuffScriptableObjectById(ulong id)
        {
            Buff buff = new Buff();
            buff.ID = _buffsScriptableObject._buffScriptableObjectsList[id]._id;
            buff.Name = _buffsScriptableObject._buffScriptableObjectsList[id]._name;
            buff.Description = _buffsScriptableObject._buffScriptableObjectsList[id]._description;
            buff.BuffType = _buffsScriptableObject._buffScriptableObjectsList[id]._buffType;
            buff.Count = _buffsScriptableObject._buffScriptableObjectsList[id]._count;
            return buff;
        }

        public void ProcessBuffLogic(ActorController actionActor, ActorController reciveActor)
        {
            
        }
    }
}