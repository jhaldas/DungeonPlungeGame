using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public MyCharacterController controller;
	private Health playerHealth;

	//public HealthBar bar;

	public float runSpeed = 40f;

	public float maxHP;

	bool jump = false;

	float hMovement = 0f;

	int money = 0;

    // Start is called before the first frame update
    void Start()
    {
		playerHealth = new Health(maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        hMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
		Debug.Log(hMovement);

		if(Input.GetButtonDown("Jump")){
			jump = true;
		}else{
			jump = false;
		}

		Debug.Log("jump: " + jump);
		Debug.Log(playerHealth.GetCurrentHP());
	}

	void FixedUpdate(){
		controller.Move(hMovement * Time.fixedDeltaTime, jump);
		//jump = false;
	}

	void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
		if(col.gameObject.name == "Spikes"){
			playerHealth.TakeDamage(50);
			Debug.Log("MAXHP: " + maxHP);
			Debug.Log("CURRENT HP" + playerHealth.GetCurrentHP());
			//bar.SetSize(playerHealth.GetCurrentHP()/maxHP);
		}

		// Handels collisions with coin game object
		if(col.gameObject.tag == "Coin"){
			Destroy(col.gameObject);
			money += 5;
		}


	}




}
