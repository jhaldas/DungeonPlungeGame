using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	
	public float damage = 50f;
	public float speed = 20f;

	private float knockback = 10f;

	public Transform firePoint;
	public GameObject bullet;

	public PlayerController PlayerController;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
			Shoot();
		}
    }

	void Shoot(){
		if(!PlayerController.IsDead()){
			Instantiate(bullet, firePoint.position, firePoint.rotation);
		}
	}
}
