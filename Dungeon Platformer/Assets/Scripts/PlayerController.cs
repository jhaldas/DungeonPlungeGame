using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{

	public float jumpTakeOffSpeed = 7;
	public float maxSpeed = 7;

	private bool facingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void ComputeVelocity(){
		Vector2 move = Vector2.zero;

		move.x = Input.GetAxis("Horizontal");

		if(move.x > 0 && !facingRight){
			Flip();
			facingRight = true;

		}else if(move.x < 0 && facingRight){
			Flip();
			facingRight = false;
		}


		if(Input.GetButtonDown("Jump") && grounded){
			velocity.y = jumpTakeOffSpeed;
		}
		else if (Input.GetButtonUp("Jump")){
			if(velocity.y > 0){
				velocity.y = velocity.y *.5f;
			}
		}

		targetVelocity = move * maxSpeed;

	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		transform.Rotate(0f, 180f, 0f);
	}

	void OnTriggerEnter2D(Collider2D col)
    {
		if(col.gameObject.tag == "Coin"){
			Destroy(col.gameObject);
			//money += 5;
		}
	}
}
