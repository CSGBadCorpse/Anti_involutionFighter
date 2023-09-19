using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;//连接scriptableObject获取数据
    //这里写playerAnimation和spineAssetData

    [SerializeField]
    private Text nameText;

    [SerializeField]
    private GameObject bloodUI;
    Image bloodValue;
    Text bloodText;
    
    [SerializeField] 
    private GameObject energyUI;
    Image energyValue;
    Text energyText;

    [SerializeField]
    private GameObject puaUI;
    Text puaText;

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
    private List<GameObject> cards;//暂时做成开放

    private void Start()
    {
        playerData = new PlayerData(bloodMax, energyMax, puaValue, name);

        nameText.text = playerData.Name;

        bloodValue = bloodUI.transform.GetChild(0).GetComponentInChildren<Image>();
        bloodText = bloodUI.transform.GetComponentInChildren<Text>();

        energyValue = energyUI.transform.GetChild(0).GetComponent<Image>();
        energyText = energyUI.GetComponentInChildren<Text>();

        puaText = puaUI.GetComponentInChildren<Text>();

        for(int i=0;i < cards.Count; i++)
        {
            playerData.AddCard(cards[i].GetComponent<Card>());
        }
        UpdateUI();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerData.GetHit(3);
            playerData.PuaDecrease(1);
            playerData.CostEnergy(1);
            
            Debug.Log(playerData.Blood);
            Debug.Log(playerData.PuaValue);

            
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            playerData.Recover(4);
            playerData.PuaIncrease(2);
            playerData.RecoverEnergy(2);

            Debug.Log(playerData.Blood);
            Debug.Log(playerData.PuaValue);

        }

        UpdateUI();
    }


    private void UpdateUI()
    {
        bloodValue.fillAmount = (float)playerData.Blood / playerData.BloodMax;
        bloodText.text = playerData.Blood.ToString() + "/" + playerData.BloodMax.ToString();

        energyValue.fillAmount = (float)playerData.Energy / playerData.EnergyMax;
        energyText.text = playerData.Energy.ToString() + "/" + playerData.EnergyMax.ToString();

        puaText.text = "X" + playerData.PuaValue.ToString();

    }
    public bool IsCardEmpty()
    {
        return playerData.IsCardEmpty();
    }
    public Card DrawCard(int index)
    {
        return playerData.GetCard(index);
    }
}
