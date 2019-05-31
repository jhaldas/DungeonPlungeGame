using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : PhysicsObject
{
	
	public float speed = 2f;

	// Variable used to determine how quickly an enemy will return back to max velocity after taking knockback
	private float returnRate = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        targetVelocity = Vector2.left * speed;
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log("Target velocity: " + targetVelocity);

		
		returnToInitialVelocity();

		//targetVelocity = Vector2.left * speed;
    }

	public void TakeKnockback(Rigidbody2D rb, float knockback){
		
		Vector2 temp = targetVelocity;

		Debug.Log("" + rb.velocity.normalized * knockback);
		//Movement(rb.velocity.normalized * knockback, false);
		targetVelocity = rb.velocity.normalized * knockback;

	}

	void returnToInitialVelocity(){
		if(targetVelocity.x > Vector2.left.x * speed){
			targetVelocity.x -= returnRate;
			if(targetVelocity.x <= Vector2.left.x * speed){
				targetVelocity = Vector2.left * speed;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		
		if(col.gameObject.tag == "Player"){
			Debug.Log("HEREE");
		}
		
	}


}
