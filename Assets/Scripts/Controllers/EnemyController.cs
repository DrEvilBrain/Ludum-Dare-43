using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterStats))]
public class EnemyController : MonoBehaviour
{
    public float speed;
    public float lookRadius;
    public float turnSpeed;
    private Transform target;
    private NavMeshAgent agent;
    private PlayerManager playerManager;
    private CharacterStats myStats;

	// Use this for initialization
	void Start()
    {
        playerManager = PlayerManager.instance;
        target = playerManager.player.transform;
        agent = GetComponent<NavMeshAgent>();
        myStats = GetComponent<CharacterStats>();
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
                // attack player

                // face player
                FaceTarget();
            }
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
