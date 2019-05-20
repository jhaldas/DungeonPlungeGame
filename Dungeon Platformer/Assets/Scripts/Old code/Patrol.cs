using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

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

	// Use this for initialization
	void Start () {
		walking = true;
		direction = Random.Range (0, 1);
		crocAnimator = GetComponent<Animator> ();
		if (direction == 0) {
			facingRight = false;	
		} else {
			facingRight = true;
		}
		rb = GetComponent<Rigidbody2D> ();
		//crocAnimator = GetComponent<Animator>;

		idleTime = Random.Range (minWalkingTime, maxWalkingTime);
		walkTime = Random.Range (minWalkingTime, maxWalkingTime);
	}
	
	// Update is called once per frame
	void Update () {
		//time = Time.deltaTime;
		//Flip ();

		ControlAnimator ();

		RaycastHit2D groundInfo = Physics2D.Raycast (groundDetection.position, Vector2.down, distance);

		if (groundInfo.collider == false) {
			speed = -speed;
			facingRight = !facingRight;
			Flip ();
		} 

		rb.velocity = new Vector2 (-speed, rb.velocity.y);
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

	void Flip(){
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	private void ControlAnimator(){
		if (walking == true) {
			crocAnimator.SetTrigger ("walking");
		} else {
			crocAnimator.ResetTrigger ("walking");
		}
	}
}
