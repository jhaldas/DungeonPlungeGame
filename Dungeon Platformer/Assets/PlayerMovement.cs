using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public MyCharacterController controller;
	public float runSpeed = 40f;

	float hMovement = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
		Debug.Log(hMovement);
	}

	void FixedUpdate(){
		controller.Move(hMovement * Time.fixedDeltaTime) ;
	}
}
