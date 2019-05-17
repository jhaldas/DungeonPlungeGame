using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{	

	public Health enemyHealth;
	public float maxHP = 100;
	//public HealthBar bar;

    // Start is called before the first frame update
    void Start()
    {
		enemyHealth = new Health(maxHP);
    }

    // Update is called once per frame
    void Update()
    {
		if(enemyHealth.GetCurrentHP() <= 0){
			Die();
		}
    }

	void Die(){
		Destroy(gameObject);
	}

	public void TakeDamage(float damage){
		enemyHealth.TakeDamage(damage);
	}



}
