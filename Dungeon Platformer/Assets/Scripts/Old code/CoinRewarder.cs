using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRewarder : MonoBehaviour {

	public GameObject coinPrefab;

	public static void Spawn(Transform enemy, int min, int max, GameObject coinPrefab){
		int count = Random.Range(min, max);

		for(int i = 0; i < count; i++){
			Instantiate(coinPrefab, enemy.position, Quaternion.identity);
		}

	}

}
