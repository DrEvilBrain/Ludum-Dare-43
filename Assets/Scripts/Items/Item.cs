using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int baseDamage;
    public int baseAttackSpeed;
    public int baseAttackRange;
    public bool strengthItem;
    public bool dexterityItem;
    public bool wisdomItem;
    public string name;
    public string description;

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

    public bool IsStrengthItem()
    {
        return strengthItem;
    }

    public bool IsDexterityItem()
    {
        return dexterityItem;
    }

    public bool IsWisdomItem()
    {
        return wisdomItem;
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
