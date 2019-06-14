using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	private float speed = 20f;
	private float damage = 50f;
	private float knockback = 3f;

	public Vector2 velocity;

	private Vector3 bulletForce;

	public Rigidbody2D rb;

	// Constructor for the bullet.  This is used with an Object that uses the Weapon script, that way, when the gun shoots, you will be able to change the
	// speed, knockback, and damage depending on which weapon you happen to be using at the time. 
	public void BulletAttributes(float damage, float speed, float knockback){
		this.damage = damage;
		this.speed = speed;
		//this.knockback = knockback;
	}

    // Bullet will move forward indefinately
    void Start()
    {
        velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = velocity;
    }

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Enemy"){
			GameObject enemy = col.gameObject;
			enemy.GetComponent<EnemyHandler>().TakeDamage(damage);

			bulletForce = rb.velocity;

			enemy.GetComponent<EnemyMove>().TakeKnockback(rb, knockback);
		}
		Destroy(gameObject);
	}
}
