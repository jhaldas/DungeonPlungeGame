﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

	private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		rb.AddForce(Vector3.up * 250f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
