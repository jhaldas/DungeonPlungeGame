using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    int sounds;
    int music;

    float musicVolume;
    float soundsVolume;

    GameObject musicToggle;
    GameObject soundToggle;

    GameObject musicVolumeSlider;
    GameObject soundsVolumeSlider;

    public void Awake()
    {
        if (PlayerPrefs.HasKey("MusicVolume") && PlayerPrefs.HasKey("SoundsVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            soundsVolume = PlayerPrefs.GetFloat("SoundsVolume");
        }
        else 
        {
            PlayerPrefs.SetFloat("MusicVolume", 0.5f);
            PlayerPrefs.SetFloat("SoundsVolume", 0.5f);
        }

/*        sounds = PlayerPrefs.GetInt("Sounds");
        music = PlayerPrefs.GetInt("Music");*/

        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        soundsVolume = PlayerPrefs.GetFloat("SoundsVolume"); 

/*        musicToggle = GameObject.Find("Music");
        soundToggle = GameObject.Find("Sounds");*/

        musicVolumeSlider = GameObject.Find("MusicSlider");
        soundsVolumeSlider = GameObject.Find("SoundsSlider");

/*        // Sets Music toggle button to either true or false based on PlayerPrefs variable
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
        }*/

        if (musicVolumeSlider != null) 
        {
            musicVolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");
        }

        if (soundsVolumeSlider != null)
        {
            soundsVolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SoundsVolume");
        }
    }

    public void Update()
    {
/*        if (musicToggle.GetComponent<Toggle>().isOn == false)
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
        }*/

        if (musicVolumeSlider != null)
        {
            musicVolume = musicVolumeSlider.GetComponent<Slider>().value;
            PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        }

        if (soundsVolumeSlider != null)
        {
            soundsVolume = soundsVolumeSlider.GetComponent<Slider>().value;
            PlayerPrefs.SetFloat("SoundsVolume", soundsVolume);
        }
    }

    public void Menu() {
        SceneManager.LoadScene("TitleScreen");
    }

    // Start is called before the first frame update
    public void BackToMenu() {
        SceneManager.LoadScene("TitleScreen");
    }

}
