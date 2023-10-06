using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class UnityTools
{
    public static GameObject AddChild(GameObject parent, GameObject assetGameObject)
    {
        if (parent != null && assetGameObject != null)
        {
            GameObject prefabGameObject = Object.Instantiate(assetGameObject);
            if(prefabGameObject != null)
            {
                Transform prefabTransform = prefabGameObject.transform;
                prefabTransform.SetParent(parent.transform);
                prefabTransform.localPosition = Vector3.zero;
                prefabTransform.localRotation = Quaternion.identity;
                prefabTransform.localScale = Vector3.one;
                prefabGameObject.layer=parent.layer;
            }
            return prefabGameObject;
        }
        return null;
    }

    public static void SetParent(GameObject parentGameObject,GameObject childGameObject, bool resetTransform = true)
    {
        if(parentGameObject != null && childGameObject != null)
        {
            Transform childTransform = childGameObject.transform;
            childTransform.SetParent(parentGameObject.transform);

            if(resetTransform)
            {
                childTransform.localPosition = Vector3.zero;
                childTransform.localRotation = Quaternion.identity;
                childTransform.localScale = Vector3.one;
                childGameObject.layer=parentGameObject.layer;
            }
        }
    }

    public static Transform ResetTransform(Transform targetTransform)
    {
        if(targetTransform != null)
        {
            targetTransform.localPosition = Vector3.zero;
            targetTransform.localRotation = Quaternion.identity;
            targetTransform.localScale = Vector3.one; 
            return targetTransform;
        }
        return null;
    }
    public static RectTransform ResetRectTransform(RectTransform targetTransform)
    {
        if(targetTransform != null)
        {
            targetTransform.anchoredPosition = Vector3.zero;
            targetTransform.anchorMax = Vector3.one;
            targetTransform.anchorMin = Vector3.zero;
            targetTransform.localScale = Vector3.zero;
            return targetTransform;
        }
        return null; 
    }
}
