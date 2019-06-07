using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler: MonoBehaviour
{
	
	public PlayerController player;
	public Text scoreText;
	public GameObject gameOver;
	public GameObject startScreen;

	private float timer = 0f;

	private bool gameStart;

	private double score;

	public Text finalScore;

    // Start is called before the first frame update
    void Start()
    {
		gameStart = false;
		Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {

		if(gameStart == false){
			
			Debug.Log("Here");
			if(Input.anyKey){
				Debug.Log("Key pressed");
				Time.timeScale = 1f;
				gameStart = true;
				startScreen.SetActive(false);
			}
		}else{

			score = System.Math.Round(timer, 1) * 10;

			scoreText.text = "Score: " + score.ToString();
			if(player.GetComponent<PlayerController>().IsDead()){
				finalScore.text = "Final Score: " + score.ToString();
				gameOver.SetActive(true);
				
			}else{
				timer += Time.deltaTime;
			}
		}
    
	
	}
}
