using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField]
    private int baseDamage;
    private int baseAttackSpeed;
    private int baseAttackRange;

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
