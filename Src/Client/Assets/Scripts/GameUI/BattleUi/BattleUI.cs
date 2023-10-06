using UnityEngine.U2D;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : UiView
{
    public RectTransform imageRectTransform;
    public RawImage rawImage;
    public Image spriteImage;
    public Text levelText;
    public Text nameText;
    public Image expImage;
    public Toggle toggle0;
    public Toggle[] toggleArray;
    public InputField inputField;
    public Slider slider;
    public Dropdown dropdown;
    public GameObject taskContentGameObject;
    public GameObject taskItemGameObject;

    //private 

    public override void Awake()
    {
        base.Awake();

    }
    private void Start()
    {
        rawImage.texture = Resources.Load<Texture>("");
        SetImageSprite("0");
        SetLevel(1);
        SetName("Test");
        SetExpPercent(0.5f);
        SetToggleOn(true);
        SetToggleOn(2, true);

        SetInputFieldText("Hello input");
        SetSliderValue(0.5f);
        //SetDropDownOption(1);

        for (int i = 0; i < 15; i++)
        {
            GameObject taskItemInstance = UnityTools.AddChild(taskContentGameObject, taskItemGameObject);
            if (taskItemInstance != null)
            {
                TaskItemView0 taskItemView0 = taskItemInstance.GetComponent<TaskItemView0>();

                if (taskItemView0 != null)
                {
                    taskItemView0.SetActive(true);
                    taskItemView0.SetName("每日任务" + i);
                }
            }
        }

    }
    public void SetImageSprite(string spriteName)
    {
        if (spriteImage != null)
        {
            SpriteAtlas spriteAtlas = Resources.Load("") as SpriteAtlas;
            spriteImage.sprite = spriteAtlas.GetSprite(spriteName);
        }
    }
    public void SetLevel(int level)
    {
        if (levelText != null)
        {
            levelText.text = level.ToString();
        }
    }
    public void SetName(string name)
    {
        if (nameText != null)
        {
            nameText.text = name;
        }
    }
    public void SetExpPercent(float percent)
    {
        if (expImage != null)
        {
            expImage.fillAmount = percent;
        }
    }
    public void SetToggleOn(bool isOn)
    {
        if (toggle0 != null)
        {
            toggle0.isOn = isOn;
        }
    }

    public void SetToggleOn(int index, bool isOn)
    {
        if (UITools.CheckArrayElement(toggleArray, index))
        {
            toggleArray[index].isOn = isOn;
        }
    }
    public void SetInputFieldText(string text)
    {
        if (inputField != null)
        {
            inputField.text = text;
        }
    }
    public void SetSliderValue(float value)
    {
        if (slider != null)
        {
            slider.value = value;
        }
    }

    public void SetDropdownOption(int optionIndex)
    {
        dropdown.value = optionIndex;
    }

    public void OnClickText()
    {
        Debug.Log("OnClickText");
    }
    public void OnToggleValueChanged(bool isOn)
    {
        Debug.Log("OnToggleValueChanged:" + isOn);
    }

    public void OnClickUpgradeButton()
    {
        Debug.Log("OnClickUpgradeButton");
    }

    public void OnInputValueChanged(string text)
    {
        Debug.Log("OnInputValueChanged:" + text);
    }
    public void OnEndEdit(string text)
    {
        Debug.Log("OnEndEdit:" + text);
    }
}
