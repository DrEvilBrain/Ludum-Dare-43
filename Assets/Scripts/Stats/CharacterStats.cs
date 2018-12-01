using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth { get; private set; }
    public int damage;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // To be overwritten
        Debug.Log(this + " died");
    }
}
