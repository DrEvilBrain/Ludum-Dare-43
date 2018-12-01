using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackCooldown;
    private float currentAttackCooldown;
    public float attackRange;
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
            Debug.Log("enemy take damage");
            targetStats.TakeDamage(myStats.damage);
            currentAttackCooldown = attackCooldown;
        }
    }
}
