using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterCombat))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float dodgeDistance;
    public float dodgeCooldown;
    private float currentDodgeCooldown;
    private CharacterCombat playerCombat;
    private Collider collider;

	// Use this for initialization
	void Start()
    {
        currentDodgeCooldown = dodgeCooldown;
        playerCombat = this.GetComponent<CharacterCombat>();
        collider = this.GetComponentInChildren<Collider>();
	}
	
	// Update is called once per frame
	void Update()
    {
        currentDodgeCooldown -= Time.deltaTime;

        // movement
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        transform.Translate(new Vector3(horizontal, 0, vertical));

        // attack
        if (Input.GetButtonDown("Attack"))
        {
            // sword
            Ray ray = new Ray(transform.position, new Vector3(horizontal, 0, vertical));
            RaycastHit hit;
            if(collider.Raycast(ray, out hit, playerCombat.attackRange))
            {
                playerCombat.Attack(hit.collider.GetComponent<CharacterStats>());
            }
        }

        // dodge
        if (Input.GetButtonDown("Dodge"))
        {
            if(currentDodgeCooldown <= 0)
            {
                transform.Translate(new Vector3(horizontal * dodgeDistance, 0, vertical * dodgeDistance));
                currentDodgeCooldown = dodgeCooldown;
            }
        }
    }
}
