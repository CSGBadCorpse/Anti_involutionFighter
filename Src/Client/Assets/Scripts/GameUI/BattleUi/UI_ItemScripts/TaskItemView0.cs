using UnityEngine.UI;
using UnityEngine;

public class TaskItemView0 : MonoBehaviour
{
    public Text nameText;
    private void Start()
    {

    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    public void SetName(string name)
    {
        if(nameText != null)
        {
            nameText.text = name;
        }
    }
}
