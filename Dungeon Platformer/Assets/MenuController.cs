using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{


    public void Start()
    {

        // Only runs on game start and won't repeat when going back to main menu
        if (PlayerPrefs.GetInt("Sounds") == 0) {
            PlayerPrefs.SetInt("Sounds", 1);
        }

        if (PlayerPrefs.GetInt("Music") == 0)
        {
            PlayerPrefs.SetInt("Music", 1);
        }

        Debug.Log("Sounds: " + PlayerPrefs.GetInt("Sounds"));
        Debug.Log("Music: " + PlayerPrefs.GetInt("Music"));
    }

    public void StartGame(){
		SceneManager.LoadScene("Runner");
		//Debug.Log("Bruh");
	}

    public void Options() {
        SceneManager.LoadScene("Options");
        //Debug.Log("BRUHHHH");
    }


}
