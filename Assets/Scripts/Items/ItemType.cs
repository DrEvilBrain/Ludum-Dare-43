using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemType
{
    public bool strengthItem;
    public bool dexterityItem;
    public bool wisdomItem;

    public bool IsStrengthItem()
    {
        if(strengthItem)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsDexterityItem()
    {
        if (dexterityItem)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsWisdomItem()
    {
        if (wisdomItem)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
