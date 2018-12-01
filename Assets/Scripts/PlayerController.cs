using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

	// Use this for initialization
	void Start()
    {

	}
	
	// Update is called once per frame
	void Update()
    {
        // movement
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        transform.Translate(new Vector3(horizontal, 0, vertical));

        // attack
        if (Input.GetButtonDown("Attack"))
        {

        }

        // dodge
        if (Input.GetButtonDown("Dodge"))
        {
            
        }
    }
}
