using SuperScrollView;
using UnityEngine;
using UnityEngine.UI;

public class SuperListItemView : LoopListViewItem2
{
    public Text nameText;

    private SuperListItemData mSuperLisItemData;

    private void Start()
    {

    }

    public void SetData(SuperListItemData superListItemData)
    {
        mSuperLisItemData = superListItemData;
    }
    public void Initialize()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        //RectTransform rectTransform = GetComponent<RectTransform>();
        //rectTransform.
    }
    public void UpdateView()
    {
        SetName(mSuperLisItemData.taskName);
    }

    public void SetName(string name)
    {
        if (nameText != null)
        {
            nameText.text = name;
        }
    }

}
