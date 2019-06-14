using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{	

	public Health enemyHealth;
	public float maxHP = 100;

	public Animator animator;

	private Rigidbody2D rb;
	//public HealthBar bar;

	public GameObject coinPrefab;

	

    // Start is called before the first frame update
    void Start()
    {
		rb  = gameObject.GetComponent<Rigidbody2D>();
		//enemyHealth = new Health(maxHP);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if(enemyHealth.GetCurrentHP() <= 0){
			Die();
		}
		
    }

	void Die(){
		CoinRewarder.Spawn(gameObject.transform, 2, 5, coinPrefab);
		Destroy(gameObject);
	}

	public void TakeDamage(float damage){
		animator.SetBool("isHit", true);
		enemyHealth.TakeDamage(damage);
		//animator.SetBool("isHit", false);
	}

	public void Knockback(Vector3 force){
		rb.AddForce(force);
	}

	public void hitEnded(){
		animator.SetBool("isHit", false);
	}

	


}
