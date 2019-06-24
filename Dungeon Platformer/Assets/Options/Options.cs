using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    int sounds;
    int music;

    GameObject musicToggle;
    GameObject soundToggle;

    public void Awake()
    {
        sounds = PlayerPrefs.GetInt("Sounds");
        music = PlayerPrefs.GetInt("Music");

        musicToggle = GameObject.Find("Music");
        soundToggle = GameObject.Find("Sounds");

        // Sets Music toggle button to either true or false based on PlayerPrefs variable
        if (music == -1)
        {
            musicToggle.GetComponent<Toggle>().isOn = false;
        }
        else if (sounds == 1){
            musicToggle.GetComponent<Toggle>().isOn = true;
        }

        // Sets SFX toggle button to either true or false based on PlayerPrefs variable
        if (sounds == -1)
        {
            soundToggle.GetComponent<Toggle>().isOn = false;
        }
        else if (sounds == 1)
        {
            soundToggle.GetComponent<Toggle>().isOn = true;
        }

        Debug.Log(sounds = PlayerPrefs.GetInt("Sounds"));
        Debug.Log(music = PlayerPrefs.GetInt("Music"));

    }

    public void Update()
    {
        if (musicToggle.GetComponent<Toggle>().isOn == false)
        {
            PlayerPrefs.SetInt("Music", -1);
        }
        else {
            PlayerPrefs.SetInt("Music", 1);
        }

        if (soundToggle.GetComponent<Toggle>().isOn == false)
        {
            PlayerPrefs.SetInt("Sounds", -1);
        }
        else
        {
            PlayerPrefs.SetInt("Sounds", 1);
        }
    }

    /*
    public void ChangeSFX() {
        if (sounds == -1)
        {
            sounds = 1; 
        }
        else if(sounds == 1) {
            sounds = -1;
        }
        Debug.Log("Setting Int");
        PlayerPrefs.SetInt("Sounds", sounds);
    }

    public void ChangeMusic() {
        if (music == -1)
        {
            music = 1;
        }
        else if (music == 1)
        {
            music = -1;
        }

        Debug.Log("Setting Int");
        PlayerPrefs.SetInt("Music", music);
    }
    */

    // Start is called before the first frame update
    public void BackToMenu() {
        SceneManager.LoadScene("TitleScreen");
    }

}
