using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrols : MonoBehaviour {

	public float speed;
	public float aggroSpeed;

	public int direction;
	public bool facingRight;

	public float distance;

	public float minWalkingTime;
	public float maxWalkingTime;

	public bool aggro;

	public LayerMask platformMask;

	private Animator crocAnimator;
	private Rigidbody2D rb;

	private bool walking;

	private float idleTime;
	private float walkTime;

	public Transform groundDetection;

	Vector2 a;
	Vector2 b;

	private Collider2D collider;

	// Use this for initialization
	void Start () {
		walking = true;
		direction = 0;
		//crocAnimator = GetComponent<Animator> ();
		if (direction == 0) {
			facingRight = false;	
		} else {
			facingRight = true;
		}
		rb = GetComponent<Rigidbody2D> ();
		collider = GetComponent<Collider2D>();
		//crocAnimator = GetComponent<Animator>;

		idleTime = Random.Range (minWalkingTime, maxWalkingTime);
		walkTime = Random.Range (minWalkingTime, maxWalkingTime);
	}

	void Update(){
		Debug.Log("THERE IS A COLLISION HAPPENING.");

		Flip();
		
	}
	
	// Update is called once per frame
	public float PatrolArea() {
		Debug.Log("Apdsodjoasjdoiajsdio");
		//tim(e = Time.deltaTime;
		Flip ();

		//ControlAnimator ();

		a = new Vector2 (groundDetection.position.x - distance, groundDetection.position.y);

		Debug.DrawRay(a, Vector2.down, Color.white);

		//b = new Vector2(groundDetection.position.x - distance, groundDetection.position.y);

		RaycastHit2D groundInfo = Physics2D.Raycast(a, Vector2.down);

		Debug.Log("Collider: " + groundInfo.collider);

		if (groundInfo.collider == false) {
			speed = -speed;
			facingRight = !facingRight;
			Flip ();
		} else{
			Debug.Log("Hitting: " + groundInfo.collider.name);
		}
		//rb.velocity = new Vector2 (-speed, rb.velocity.y);
		return -speed;
	}

	
	
			
//		if(!aggro){
//
//			while(idleTime >= 0){
//				idleTime -= time;
//			}
//
//			float temp = targetTime;
//
//			temp -= time;
//		
//		}
//
/*
	void Flip(){
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
	*/
	
	void Flip(){
		// Switch the way the player is facing.
		facingRight = !facingRight;

		transform.Rotate(0f, 180f, 0f);
		distance = -distance;
	}

	public void Hello(){
		Debug.Log("Hello");
	}

	private void ControlAnimator(){
		if (walking == true) {
			//crocAnimator.SetTrigger ("walking");
		} else {
			//crocAnimator.ResetTrigger ("walking");
		}
	}

	

	
}
