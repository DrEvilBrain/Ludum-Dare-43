using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    #region Singleton

    public static ItemManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Item GenerateWeapon(Item weapon)
    {
        string weaponStat =  "";

        // generate weapon type
        int itemType = Random.Range(0, 3);
        if(itemType == 0)
        {
            weapon.strengthItem = true;
            weaponStat = "STR";
        }
        else if(itemType == 1)
        {
            weapon.dexterityItem = true;
            weaponStat = "DEX";
        }
        else if(itemType == 2)
        {
            weapon.wisdomItem = true;
            weaponStat = "WIS";
        }

        // generate weapon name
        if(weapon.strengthItem)
        {
            weapon.name = "Axe";
        }
        else if(weapon.dexterityItem)
        {
            weapon.name = "Sword";
        }
        else if(weapon.wisdomItem)
        {
            weapon.name = "Staff";
        }

        // generate damage
        int damage = Random.Range(1, 11);
        weapon.baseDamage = damage;

        // generate attack speed

        // generate attack range

        // generate descrption

        weapon.description = "+" + weapon.baseDamage + " " + weapon.name + " (" + weaponStat + " damage)";

        return weapon;
    }
}
