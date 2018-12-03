using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public Stat vitality;
    public Stat strength;
    public Stat dexterity;
    public Stat wisdom;
    public Item weapon;

    public int amountToChangeBy;

    private CharacterStats stats;

	// Use this for initialization
	void Start()
    {
        stats = this.GetComponent<CharacterStats>();
        stats.maxHealth = vitality.GetValue() * 10;
	}

    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }

    public void ChangeStats(Stat statToChange)
    {
        statToChange.ChangeValue(amountToChangeBy);

        if(statToChange == vitality)
        {
            maxHealth = vitality.GetValue() * 10;
        }
        else if(statToChange == strength)
        {
            // change sword damage
        }
        else if(statToChange == dexterity)
        {
            // change bow damage
        }
        else if(statToChange == wisdom)
        {
            // change staff damage
        }

        HealToMaxHealth();
    }

    public void ChangeWeapons(Item newWeapon)
    {
        weapon = newWeapon;
    }
}
