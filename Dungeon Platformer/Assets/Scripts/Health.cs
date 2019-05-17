using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class will be used anytime an object has a certain amount of health.  Health will be referred to as HP (hitpoints).
public class Health : MonoBehaviour
{ 

	//[SerializeField] private HealthBar healthBar;
	public float maxHP;
	private float currentHP;

	public Health(float maxHP){
		this.maxHP = maxHP;
		currentHP = maxHP;
	}

	public float GetHealthPercentage(){
		return currentHP / maxHP;
	}

	// The following method takes health away from the targets current HP and returns true the target took lethal damage
	public bool TakeDamage(float dmgDealth){
		currentHP = currentHP - dmgDealth;
		//healthBar.printHello();
		if(currentHP <= 0){
			currentHP = 0;
			return true;
		}
		return false;
	}


	public float GetCurrentHP(){
		return currentHP;
	}


	// Adds a certain amount of health to an object and will not go over the max amount of HP, no return statement is needed as of right now since we don't have a reason
	// to need to know whether or not an object has restored a certain amount of health.
	public void GiveHealth(float healthGiven){
		currentHP = currentHP + healthGiven;

		if(currentHP > maxHP){
			currentHP = maxHP;
		}
	}

}
