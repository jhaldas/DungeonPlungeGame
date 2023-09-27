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

    public GameObject newHighscoreText;
    public GameObject displayHighscoreText;

	private float timer = 0f;

	private bool gameStart = false;

	public double score;

	public Text finalScore;

    public int numCoins = 0;

    public int coinValue = 50;

    // Start is called before the first frame update
    void Start()
    {
		Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Highscore: " + PlayerPrefs.GetInt("Highscore"));
        displayHighscoreText.GetComponent<Text>().text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
        if (gameStart == false){
			
			//Debug.Log("Here");
			if(Input.anyKey){
				//Debug.Log("Key pressed");
				Time.timeScale = 1f;
				gameStart = true;
				startScreen.SetActive(false);
			}
		}else{

			score = System.Math.Round(timer, 1) * 10 + (numCoins * coinValue);

			scoreText.text = "Score: " + score.ToString();
			if(player.GetComponent<PlayerController>().IsDead()){
				finalScore.text = "Final Score: " + score.ToString();
				gameOver.SetActive(true);
			}else{
				timer += Time.deltaTime;
			}
		}
    
	
	}

    // Method used to determine whether or not the player set a highscore.
    // If so, a "New Highscore!" text will be displayed on gameover screen.
    public bool Highscore()
    {
        int highscore = PlayerPrefs.GetInt("Highscore");

        // Sets new highscore if player gets new personal best.
        if (score > highscore)
        {
            newHighscoreText.SetActive(true);
            PlayerPrefs.SetInt("Highscore", (int)score);
            // A new highscore
            return true;
        }
        else
        {
            newHighscoreText.SetActive(false);
            // Not a highscore
            return false;
        }
        
    }
}
