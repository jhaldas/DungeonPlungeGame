using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	private Vector2 startDirection;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		float x = Random.Range(-2, 2);
		startDirection = new Vector2 (x, 0);
	}
	
	// Update is called once per frame
	void Update () {
		//startDirection.Normalize ();
		//rb.transform = rb.position + startDirection;
	}




}
