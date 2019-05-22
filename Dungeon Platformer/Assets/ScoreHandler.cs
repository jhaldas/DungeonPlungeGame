using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler: MonoBehaviour
{
	
	public PlayerController player;
	public Text scoreText;
	public GameObject gameOver;
	

    // Start is called before the first frame update
    void Start()
    {
		       
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + player.GetMoney().ToString("0");
		if(player.GetComponent<PlayerController>().IsDead()){
			gameOver.SetActive(true);
		}
    }
}
