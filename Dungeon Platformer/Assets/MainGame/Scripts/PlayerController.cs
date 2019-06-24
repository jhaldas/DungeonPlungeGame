using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{

	public Animator animator;

	public float jumpTakeOffSpeed = 7;
	public float maxSpeed = 7;

	private bool facingRight = true;

	private int money = 0;

	private bool isDead = false;

	Vector2 move;

	public GameObject death;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void ComputeVelocity(){

        // Toggles music based on whether or not player has selected music or not
        if (PlayerPrefs.GetInt("Music") == -1)
        {
            GetComponent<AudioSource>().mute = true;
            Debug.Log("Playing Music");
        }
        else {
            GetComponent<AudioSource>().mute = false;
            Debug.Log("Not Playing Music");
        }

		if(isDead != true){
			move = Vector2.zero;

			move.x = Input.GetAxis("Horizontal");

			if(move.x > 0 && !facingRight){
				Flip();
				facingRight = true;
				
			}else if(move.x < 0 && facingRight){
				Flip();
				facingRight = false;
			}
			
			if(move.x != 0f){
				animator.SetBool("isWalking", true);
			}else{
				animator.SetBool("isWalking", false);
			}

			if(grounded){
				animator.SetBool("isGrounded", true);
			}else{
				animator.SetBool("isGrounded", false);
			}


			if(Input.GetButtonDown("Jump") && grounded){
				velocity.y = jumpTakeOffSpeed;
                FindObjectOfType<AudioManager>().Play("Jump");
			}
			else if (Input.GetButtonUp("Jump")){
				if(velocity.y > 0){
					velocity.y = velocity.y *.5f;
				}
			}

			targetVelocity = move * maxSpeed;

			if(transform.position.y <= -8){
				Die();
			}
		}else{
			velocity.x = 0f;
			velocity.y = 0f;
		}
	}

	private void Flip()
	{
		// Switch the way the player is facing.
		facingRight = !facingRight;

		transform.Rotate(0f, 180f, 0f);
	}

	void OnTriggerEnter2D(Collider2D col)
    {
		Debug.Log("Here");

		if(col.gameObject.tag == "Coin"){
			Destroy(col.gameObject);
			money += 5;
            FindObjectOfType<AudioManager>().Play("Coin");
        }

		if(col.gameObject.tag == "Enemy"){
			PlayerTakeKnockback(col.gameObject.GetComponent<PhysicsObject>().velocity, 50f);
			//move = Vector2.zero;
		}

		if(col.gameObject.name == "Traps"){
			Die();
		}
	}

	public int GetMoney(){
		return money;
	}

	public bool IsDead(){
		return isDead;
	}

	public void Die(){
        FindObjectOfType<AudioManager>().Play("Death");
        isDead = true;
		Instantiate(death, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f), transform.rotation);
		gameObject.SetActive(false);
		
	}

	protected void PlayerTakeKnockback(Vector2 velocity, float knockback){
		Debug.Log("" + velocity * knockback);
		//Movement(rb2.velocity.normalized * knockback, false);
		targetVelocity = velocity * knockback;
	}

	void OnCollisionEnter2D(Collision2D col){
		//Debug.Log("Here");
		
	}

	
}
