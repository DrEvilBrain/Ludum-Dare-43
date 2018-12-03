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

	// Use this for initialization
	void Start()
    {
        playerManager = PlayerManager.instance;
        target = playerManager.player.transform;
        characterCombat = GetComponent<CharacterCombat>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.stoppingDistance = characterCombat.attackRange;
        attackedCooldown = attackDelay;
    }
	
	// Update is called once per frame
	void Update()
    {
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
                
                // face player
                FaceTarget();
            }
        }
        else
        {
            // reset cooldown if not in range
            attackedCooldown = attackDelay;
        }
	}

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector2(direction.x, 0));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
