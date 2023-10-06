using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperScrollView;


public class SuperListView : UiView
{
    private static string prefabName = "DamageCardItem";


    private SuperListModule mSuperListModule;
    private SuperListModuleData mSuperListModuleData;

    public LoopListView2 loopListView2;

    public void SetModule(SuperListModule superListModule)
    {
        mSuperListModule = superListModule;
    }

    public void SetModuleData(SuperListModuleData superListModuleData)
    {
        mSuperListModuleData = superListModuleData;
    }

    public void Initialize()
    {
        loopListView2.InitListView(0, OnGetItemByIndex);
    }
    public void UpdateState()
    {

    }
    public void UpdateView()
    {
        if(loopListView2.ItemTotalCount != mSuperListModuleData.superListItemDataList.Count)
        {
            loopListView2.SetListItemCount(mSuperListModuleData.superListItemDataList.Count);
        }
        else
        {
            loopListView2.RefreshAllShownItem();
        }
    }

    public void SetName()
    {

    }
    public void SetLevel()
    {

    }

    public void SetExp()
    {

    }
    private LoopListViewItem2 OnGetItemByIndex(LoopListView2 loopListView2, int rowIndex)
    {
        if (rowIndex >= 0)
        {
            if (UITools.CheckListElement(mSuperListModuleData.superListItemDataList, rowIndex))
            {
                SuperListItemData superListItemData = mSuperListModuleData.superListItemDataList[rowIndex];
                SuperListItemView superListItemView = loopListView2.NewListViewItem(prefabName) as SuperListItemView;
                if (superListItemView != null)
                {
                    superListItemView.SetData(superListItemData);
                    superListItemView.Initialize();
                    superListItemView.UpdateView();

                    return superListItemView;
                }
            }
        }
        return null;
    }

    public void OnClickCloseButton()
    {
        mSuperListModule.RemoveSuperListView();
    }
    
}
