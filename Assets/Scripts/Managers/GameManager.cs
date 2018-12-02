using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerManager playerManager;
    private EnemyManager enemyManager;

    [SerializeField] private int round;
    [SerializeField] private int enemiesPerRound;
    [SerializeField] private int enemiesStillAlive;

	// Use this for initialization
	void Start ()
    {
        playerManager = this.GetComponent<PlayerManager>();
        enemyManager = this.GetComponent<EnemyManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
