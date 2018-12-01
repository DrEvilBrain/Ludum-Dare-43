using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterCombat))]
[RequireComponent(typeof(PlayerStats))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float dodgeDistance;
    public float dodgeCooldown;
    private float currentDodgeCooldown;
    private CharacterCombat playerCombat;
    private RaycastHit hit;
    private bool hitDetect;
    private Vector3 previousDirection;

    // Use this for initialization
    void Start()
    {
        currentDodgeCooldown = dodgeCooldown;
        playerCombat = this.GetComponent<CharacterCombat>();
        previousDirection = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        currentDodgeCooldown -= Time.deltaTime;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // movement
        float horizontalMovement = Input.GetAxis("Horizontal") * speed;
        float verticalMovement = Input.GetAxis("Vertical") * speed;
        transform.Translate(new Vector3(horizontalMovement, 0, verticalMovement));

        // attack
        if (Input.GetButtonDown("Attack"))
        {
            // sword

            // if player is not moving
            if(horizontal == 0 || vertical == 0)
            {
                Debug.Log("Use previous direction " + previousDirection);
                hitDetect = Physics.BoxCast(transform.position, new Vector3(playerCombat.attackRange / 2, 0, playerCombat.attackRange / 2),
                    previousDirection, out hit, transform.rotation, playerCombat.attackRange);
            }
            else
            {
                hitDetect = Physics.BoxCast(transform.position, new Vector3(playerCombat.attackRange / 2, 0, playerCombat.attackRange / 2),
                    new Vector3(horizontal, 0, vertical), out hit, transform.rotation, playerCombat.attackRange);
            }
            if (hitDetect)
            {
                playerCombat.Attack(hit.collider.GetComponent<CharacterStats>());
            }
        }

        // dodge
        if (Input.GetButtonDown("Dodge"))
        {
            if (currentDodgeCooldown <= 0)
            {
                transform.Translate(new Vector3(horizontal * dodgeDistance, 0, vertical * dodgeDistance));
                currentDodgeCooldown = dodgeCooldown;
            }
        }

        // update previous direction
        if(horizontal != 0 || vertical != 0)
        {
            previousDirection = new Vector3(horizontal, 0, vertical);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Draw a Ray forward from GameObject toward the maximum distance
        Gizmos.DrawRay(transform.position, new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * playerCombat.attackRange);
        //Draw a cube at the maximum distance
        Gizmos.DrawWireCube(transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * playerCombat.attackRange, transform.localScale);
    }
}
