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
    private PlayerStats playerStats;
    private RaycastHit hit;
    private bool hitDetect;
    private Vector3 previousDirection;

    // Use this for initialization
    void Start()
    {
        currentDodgeCooldown = dodgeCooldown;
        playerCombat = this.GetComponent<CharacterCombat>();
        playerStats = this.GetComponent<PlayerStats>();
        previousDirection = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // cancel all input if in menu
        if(UIManager.instance.inMenu)
        {
            return;
        }

        currentDodgeCooldown -= Time.deltaTime;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // movement
        float horizontalMovement = horizontal * speed;
        float verticalMovement = vertical * speed;
        transform.Translate(new Vector3(horizontalMovement, 0, verticalMovement));

        // keep player within camera bounds
        CameraManager.instance.KeepItemWithinCameraBounds(transform);

        // attack
        if (Input.GetButtonDown("Attack"))
        {
            // strength weapons
            if(playerStats.weapon.strengthItem)
            {
                // if player is not moving
                if (horizontal == 0 || vertical == 0)
                {
                    hitDetect = Physics.BoxCast(transform.position, new Vector3(playerCombat.attackRange / 2 - 0.5f, 0, playerCombat.attackRange / 2 - 0.5f),
                        previousDirection, out hit, transform.rotation, playerCombat.attackRange);
                }
                else
                {
                    hitDetect = Physics.BoxCast(transform.position, new Vector3(playerCombat.attackRange / 2 - 0.5f, 0, playerCombat.attackRange / 2 - 0.5f),
                        new Vector3(horizontal, 0, vertical), out hit, transform.rotation, playerCombat.attackRange);
                }
                if (hitDetect)
                {
                    playerCombat.Attack(hit.collider.GetComponent<CharacterStats>());
                }
            }

            // dexterity weapons
            if (playerStats.weapon.dexterityItem)
            {
                // if player is not moving
                if (horizontal == 0 || vertical == 0)
                {
                    hitDetect = Physics.BoxCast(transform.position, new Vector3(playerCombat.attackRange / 2 - 0.5f, 0, playerCombat.attackRange / 2 - 0.5f),
                        previousDirection, out hit, transform.rotation, playerCombat.attackRange);
                }
                else
                {
                    hitDetect = Physics.BoxCast(transform.position, new Vector3(playerCombat.attackRange / 2 - 0.5f, 0, playerCombat.attackRange / 2 - 0.5f),
                        new Vector3(horizontal, 0, vertical), out hit, transform.rotation, playerCombat.attackRange);
                }
                if (hitDetect)
                {
                    playerCombat.Attack(hit.collider.GetComponent<CharacterStats>());
                }
            }

            // wisdom weapons
            if (playerStats.weapon.wisdomItem)
            {
                // if player is not moving
                if (horizontal == 0 || vertical == 0)
                {
                    hitDetect = Physics.BoxCast(transform.position, new Vector3(playerCombat.attackRange / 2 - 0.5f, 0, playerCombat.attackRange / 2 - 0.5f),
                        previousDirection, out hit, transform.rotation, playerCombat.attackRange);
                }
                else
                {
                    hitDetect = Physics.BoxCast(transform.position, new Vector3(playerCombat.attackRange / 2 - 0.5f, 0, playerCombat.attackRange / 2 - 0.5f),
                        new Vector3(horizontal, 0, vertical), out hit, transform.rotation, playerCombat.attackRange);
                }
                if (hitDetect)
                {
                    playerCombat.Attack(hit.collider.GetComponent<CharacterStats>());
                }
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

    // show player hitbox
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        //Draw a Ray forward from GameObject toward the maximum distance
        Gizmos.DrawRay(transform.position, new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * playerCombat.attackRange);
        //Draw a cube at the maximum distance
        Gizmos.DrawWireCube(transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * playerCombat.attackRange, transform.localScale);
    }
}
