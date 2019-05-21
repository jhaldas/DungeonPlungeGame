using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

		if(Input.GetButtonDown("Left")){
			targetVelocity = Vector2.left;   
		}else if(Input.GetButtonDown("Right")){
			targetVelocity = Vector2.right;   
		}

		//targetVelocity = Vector2.left;   
    }
}
