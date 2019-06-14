using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	private Vector2 startDirection;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		float x = Random.Range(-50, 50);
		startDirection = new Vector2 (x, 0);
		rb.AddForce(startDirection);
	}
	
	// Update is called once per frame
	void Update () {
		
	}




}
