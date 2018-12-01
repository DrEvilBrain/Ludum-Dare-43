using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public int health;
    public int vitality;
    public int strength;
    public int dexterity;
    public int intelligence;

	// Use this for initialization
	void Start()
    {
        health = vitality * 10;
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}
}
