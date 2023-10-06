using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoView : UiView
{


    public override void Awake()
    {
        base.Awake();


    }

    public void OnClickShowListView()
    {
        SuperListModule superListView = GameModuleManager.Instance.GetOpenModule<SuperListModule>();
        superListView.ShowSuperListView();
    }

}
