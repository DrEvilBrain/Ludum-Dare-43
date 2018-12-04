using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterCombat))]
[RequireComponent(typeof(EnemyStats))]
public class EnemyController : MonoBehaviour
{
    public float speed;
    public float lookRadius;
    public float turnSpeed;
    public float attackDelay;
    private float attackedCooldown;
    private Transform target;
    private NavMeshAgent agent;
    private PlayerManager playerManager;
    private CharacterCombat characterCombat;
    private EnemyStats enemyStats;

    public SpriteRenderer healthBar;

	// Use this for initialization
	void Start()
    {
        playerManager = PlayerManager.instance;
        target = playerManager.player.transform;
        characterCombat = GetComponent<CharacterCombat>();
        enemyStats = GetComponent<EnemyStats>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.stoppingDistance = characterCombat.attackRange;
        attackedCooldown = attackDelay;
    }
	
	// Update is called once per frame
	void Update()
    {
        // update HP
        Vector3 healthBarScale = healthBar.transform.localScale;
        healthBarScale.x = enemyStats.GetCurrentHealth() / enemyStats.GetMaxHealth();
        healthBar.transform.localScale = healthBarScale;

        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {
                // decrease attackCooldown
                attackedCooldown -= Time.deltaTime;

                // attack player
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if(targetStats != null && attackedCooldown <= 0)
                {
                    characterCombat.Attack(targetStats);
                }
            }
        }
        else
        {
            // reset cooldown if not in range
            attackedCooldown = attackDelay;
        }
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
