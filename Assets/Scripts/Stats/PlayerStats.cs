using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public Stat vitality;
    public Stat strength;
    public Stat dexterity;
    public Stat wisdom;
    public Stat strengthDamage;
    public Stat dexterityDamage;
    public Stat wisdomDamage;
    public Item weapon;

    public int amountToChangeBy;

    private CharacterStats stats;

	// Use this for initialization
	void Start()
    {
        stats = this.GetComponent<CharacterStats>();
        stats.maxHealth = vitality.GetValue() * 10;
        strengthDamage.ChangeValueTo(strength.GetValue() / 2);
        dexterityDamage.ChangeValueTo(dexterity.GetValue() / 2);
        wisdomDamage.ChangeValueTo(wisdom.GetValue() / 2);
	}

    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }

    public void ChangeStats(Stat statToChange)
    {
        if(IsSacraficePossible(statToChange))
        {
            statToChange.ChangeValue(amountToChangeBy);

            if (statToChange == vitality)
            {
                maxHealth = vitality.GetValue() * 10;
            }
            else if (statToChange == strength)
            {
                strengthDamage.ChangeValueTo(strength.GetValue() / 2);
            }
            else if (statToChange == dexterity)
            {
                dexterityDamage.ChangeValueTo(dexterity.GetValue() / 2);
            }
            else if (statToChange == wisdom)
            {
                wisdomDamage.ChangeValueTo(wisdom.GetValue() / 2);
            }

            UpdateDamage();
            HealToMaxHealth();
            PlayerManager.instance.AfterSacrafice();
        }
    }

    public void ChangeWeapons(Item newWeapon)
    {
        weapon = newWeapon;

        UpdateDamage();
        HealToMaxHealth();
        PlayerManager.instance.AfterSacrafice();
    }

    private bool IsSacraficePossible(Stat statToChange)
    {
        if (statToChange.GetValue() <= 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void UpdateDamage()
    {
        if(weapon.GetItemType().IsStrengthItem())
        {
            damage.ChangeValueTo(strengthDamage.GetValue() + weapon.GetDamage());
        }
        else if (weapon.GetItemType().IsDexterityItem())
        {
            damage.ChangeValueTo(dexterityDamage.GetValue() + weapon.GetDamage());
        }
        else if (weapon.GetItemType().IsWisdomItem())
        {
            damage.ChangeValueTo(wisdomDamage.GetValue() + weapon.GetDamage());
        }
    }
}
