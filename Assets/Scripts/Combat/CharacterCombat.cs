﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackCooldown;
    private float currentAttackCooldown;
    public float attackRange;
    public float damageDelay;
    private CharacterStats myStats;

	// Use this for initialization
	void Start()
    {
        myStats = GetComponent<CharacterStats>();
        currentAttackCooldown = attackCooldown;
	}

    private void Update()
    {
        currentAttackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        if(currentAttackCooldown <= 0)
        {
            Debug.Log(targetStats + " takes " + myStats.damage.GetValue() + " damage");
            StartCoroutine(DoDamage(targetStats, damageDelay));
            currentAttackCooldown = attackCooldown;
        }
    }

    public bool IsAttackPossible()
    {
        if(currentAttackCooldown <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator DoDamage (CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(myStats.damage.GetValue());
    }
}
