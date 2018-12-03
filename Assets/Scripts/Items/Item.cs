using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int baseDamage;
    public int baseAttackSpeed;
    public int baseAttackRange;
    private ItemType itemType;

    public int GetDamage()
    {
        return baseDamage;
    }

    public int GetAttackSpeed()
    {
        return baseAttackSpeed;
    }

    public int GetAttackRange()
    {
        return baseAttackRange;
    }

    public ItemType GetItemType()
    {
        return itemType;
    }

    public void ChangeDamage(int numberToChangeTo)
    {
        baseDamage = numberToChangeTo;
    }

    public void ChangeAttackSpeed(int numberToChangeTo)
    {
        baseAttackSpeed = numberToChangeTo;
    }

    public void ChangeAttackRange(int numberToChangeTo)
    {
        baseAttackRange = numberToChangeTo;
    }
}
