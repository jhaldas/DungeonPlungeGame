using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRewarder : MonoBehaviour {

	private int minimumCoinReward = 5;
	private int maximumCoinReward = 10;

	public GameObject coinPrefab;

	public void Spawn(){
		int count = Random.Range(this.minimumCoinReward, this.maximumCoinReward);

		for(int i = 0; i < count; i++){
			Instantiate(this.coinPrefab, this.transform.position, Quaternion.identity);
		}

	}

}
