using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;//连接scriptableObject获取数据

    [SerializeField]
    private Text nameText;
    [SerializeField]
    private GameObject bloodUI;
    [SerializeField] 
    private GameObject energyUI;
    [SerializeField]
    private GameObject puaUI;
    
    [SerializeField]
    private new string name;
    [SerializeField]
    private int bloodMax;
    [SerializeField] 
    private int energyMax;
    [SerializeField]
    private int puaValue;

    Image bloodValue;
    Text bloodText;

    Image energyValue;
    Text energyText;

    Text puaText;
    private void Start()
    {
        playerData = new PlayerData();
        playerData.SetName(name);

        playerData.SetBlood(bloodMax);//暂时写死

        playerData.SetEnergy(energyMax);

        playerData.SetPuaValue(puaValue);

        nameText.text = playerData.Name;

        bloodValue = bloodUI.transform.GetChild(0).GetComponentInChildren<Image>();
        bloodValue.fillAmount = (float)playerData.Blood/ playerData.BloodMax;
        bloodText = bloodUI.transform.GetComponentInChildren<Text>();
        bloodText.text = playerData.Blood.ToString()+"/"+ playerData.BloodMax.ToString();

        energyValue = energyUI.transform.GetChild(0).GetComponent<Image>();
        energyValue.fillAmount = (float)playerData.Energy/ playerData.EnergyMax;
        energyText = energyUI.GetComponentInChildren<Text>();
        energyText.text = playerData.Energy.ToString()+"/"+playerData.EnergyMax.ToString();

        puaText = puaUI.GetComponentInChildren<Text>();
        puaText.text = "X"+playerData.PuaValue.ToString();
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
}
