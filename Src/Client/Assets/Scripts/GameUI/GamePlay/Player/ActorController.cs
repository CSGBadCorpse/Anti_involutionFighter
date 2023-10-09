using System.Collections.Generic;
using GameUI.GamePlay.Cards;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI.GamePlay
{
            
    public class ActorController :MonoBehaviour
    {
        [SerializeField]
        public ActorData playerData;//连接scriptableObject获取数据
        //这里写playerAnimation和spineAssetData

        [SerializeField]
        private Text _nameText;

        [SerializeField]
        private GameObject bloodUI;
        private Image _bloodValue;
        private Text _bloodText;
        
        [SerializeField] 
        private GameObject _energyUI;
        private Image _energyValue;
        private Text _energyText;

        [SerializeField]
        private GameObject puaUI;
        private Text _puaText;

        [Header("初始化数据")]
        [SerializeField]
        private new string name;
        [SerializeField]
        private int bloodMax;
        [SerializeField] 
        private int energyMax;
        [SerializeField]
        private int puaValue;

        [SerializeField]
        public List<Card> cards;//暂时做成开放

        private void Start()
        {
            playerData = new ActorData(bloodMax, energyMax, puaValue, name);

            _nameText.text = playerData.Name;

            _bloodValue = bloodUI.transform.GetChild(0).GetComponentInChildren<Image>();
            _bloodText = bloodUI.transform.GetComponentInChildren<Text>();

            _energyValue = _energyUI.transform.GetChild(0).GetComponent<Image>();
            _energyText = _energyUI.GetComponentInChildren<Text>();

            _puaText = puaUI.GetComponentInChildren<Text>();

            // if (cards.Count > 0)
            // {
            //     for (int i = 0; i < cards.Count; i++)
            //     {
            //         playerData.AddCard(cards[i].GetComponent<Card>());
            //     }
            // }

        }
        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
                //playerData.PuaDecrease(1);
                //playerData.CostEnergy(1);
                
                // Debug.Log(playerData.Blood.ToString());
                // Debug.Log(playerData.PuaValue.ToString());

                
            //}
            //if (Input.GetKeyDown(KeyCode.I))
            //{
                //playerData.Recover(4);
                //playerData.PuaIncrease(2);
                //playerData.RecoverEnergy(2);

                //Debug.Log(playerData.Blood);
                //Debug.Log(playerData.PuaValue);

            //}

            //UpdateUI();
        }


        private void UpdateUI()
        {
            _bloodValue.fillAmount = (float)playerData.BloodCur / playerData.BloodMax;
            _bloodText.text = playerData.BloodCur.ToString() + "/" + playerData.BloodMax.ToString();

            _energyValue.fillAmount = (float)playerData.EnergyCur / playerData.EnergyMax;
            _energyText.text = playerData.EnergyCur.ToString() + "/" + playerData.EnergyMax.ToString();

            _puaText.text = "X" + playerData.PuaValue.ToString();

        }
        public bool IsCardEmpty()
        {
            return playerData.IsCardEmpty();
        }
        public Card DrawCard(int index)
        {
            return playerData.GetCard(index);
        }
        //public int ProcessCard(Card actionCard)
        //{
        //    actionCard.ProcessCardAffect(this);
        //    if (actionCard is DamageCard)
        //    {
                
        //    }
        //    // if (actionCard.cardType== CardType.Damage)
        //    // {
        //    //     GetHit(actionCard.Damage);
        //    // }
        //    // else if (actionCard.cardType == CardType.Recover)
        //    // {
        //    //     Recover(actionCard.Recover);
        //    // }
        //    // CostEnergy(actionCard.Cost);
        //    // PuaIncrease(2);
        //    // UpdateUI();
        //    // if (actionCard.IsCoutinued)
        //    // {
        //    //     return GamePlayUtil.DontTurn;
        //    // }        
        //    return GamePlayUtil.NextTurn;
        //}

        private void GetHit(int value)
        {
            Debug.Log("受到"+value+"伤害");
            playerData.GetHit(value);
        }
        private void Recover(int value)
        {
            Debug.Log("恢复" + value + "点");
            playerData.Recover(value);
        }
        private void PuaIncrease(int value)
        {
            Debug.Log("pua增加" + value + "点");
            playerData.PuaIncrease(value);
        }
        private void CostEnergy(int value)
        {
            Debug.Log("消耗" + value + "精力");
            playerData.CostEnergy(value);
        }

        public bool IsDead()
        {
            return playerData.BloodCur == 0;
        }

        public void AddCard(Card newCard)
        {
            playerData.AddCard(newCard);
        }
    }

}