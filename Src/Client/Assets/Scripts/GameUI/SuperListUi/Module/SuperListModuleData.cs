using System.Collections.Generic;

public class SuperListItemData
{
    public int index;
    public string taskName;
}


public class SuperListModuleData
{
    public List<SuperListItemData> superListItemDataList = new List<SuperListItemData>();

    public void Initialize()
    {
        for(int i = 0; i < 500; i++)
        {
            SuperListItemData superListItemData = new SuperListItemData();
            superListItemData.index = i;
            superListItemData.taskName = "task: " + i;

            superListItemDataList.Add(superListItemData);
        }
    }
}
