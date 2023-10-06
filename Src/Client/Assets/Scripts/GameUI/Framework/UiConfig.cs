using System.Collections.Generic;

public class UiConfig
{
    public int viewId;
    public string pathFileName;
    public int layerType;
    public bool isLarge;

    public List<int> closeLayerList = new List<int>();

    public UiConfig(int viewId, string pathFileName, int layerType, bool isLarge = false, int[] closeLayerArray = null) 
    {
        this.viewId = viewId;
        this.pathFileName = pathFileName;
        this.layerType = layerType;
        this.isLarge = isLarge;
        
        if(closeLayerArray != null)
        {
            closeLayerList.AddRange(closeLayerArray);
        }
        else
        {
            if(layerType == UiConfigManager.System)
            {
                closeLayerList.Add(UiConfigManager.System);
            }
        }
    }
}