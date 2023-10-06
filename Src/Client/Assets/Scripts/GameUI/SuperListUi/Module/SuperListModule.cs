using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperListModule : GameModule
{
    public SuperListView superListView;
    public SuperListModuleData mSuperListModuleData = new SuperListModuleData();

    public override void OnOpen()
    {
        mSuperListModuleData.Initialize();
    }
    public override void OnClose()
    {

    }

    public SuperListView ShowSuperListView()
    {
        if(superListView == null)
        {
            superListView = GameUi.Instance.ShowView((int)ViewId.SuperList) as SuperListView;
        }
        if(superListView!=null)
        {
            superListView.SetModule(this);
            superListView.SetModuleData(mSuperListModuleData);
            superListView.Initialize();
            //superListView.UpdateState();
            superListView.UpdateView();
        }
        return superListView;
    }

    public void RemoveSuperListView()
    {
        if (superListView != null)
        {
            superListView.RemoveSelf();
            superListView = null;
        }
    }

    public void SendXXXRequest()
    {

    }
    public void SendXXXResponse() 
    { 
        if(superListView != null)
        {
            superListView.UpdateView();
        }
    }
}
