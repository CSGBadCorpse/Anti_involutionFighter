using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UITools
{
    public static bool CheckArrayElement<T>(T[] itemArray,int index)
    {
        if(itemArray != null && index >=0 && index <= itemArray.Length - 1 && itemArray[index] != null)
        {
            return true;
        }
        return false;
    }
    public static bool ChackArrayBound<T>(T[] itemArray,int index)
    {
        if( itemArray != null && index >=0 && index <= itemArray.Length - 1)
        {
            return true;
        }
        return false;
    }

    public static bool Contains(IList<object> itemList,object item)
    {
        if(itemList!=null && item!= null)
        {
            int itemCount = itemList.Count;
            for(int i = 0; i < itemCount; i++)
            {
                if (itemList[i] == item)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public static bool Contains(IList<long> itemList, long item)
    {
        if (itemList != null)
        {
            int itemCount = itemList.Count;
            for (int i = 0; i < itemCount; i++)
            {
                if (itemList[i] == item)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public static bool CheckListElement<T>(List<T> itemList,int index)
    {
        if(itemList != null && index >= 0 && index <= itemList.Count - 1 && itemList[index] != null)
        {
            return true;
        }

        return false;
    }
    public static bool CheckListBound<T>(IList<T> itemList,int index)
    {
        if(itemList!=null && index >= 0 && index<=itemList.Count - 1)
        {
            return true;
        }
        return false;
    }
    public static void RemoveListHead<T>(List<T> tList, int maxCount)
    {

    }
}