using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : PhysicsObject
{
	
	public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
		targetVelocity = Vector2.left * speed;
    }

	public void TakeKnockback(Rigidbody2D rb, float knockback){
		
		Debug.Log("" + rb.velocity.normalized * knockback);
		Movement(rb.velocity.normalized * knockback, false);
	}


}
