using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

	public GameObject button;
	private bool paused = false;
	
	public void Pause(){
		paused = true;
		Time.timeScale = 0f;
		button.SetActive(false);
	}

	public void Unpause(){
		paused = false;
		Time.timeScale = 1f;
	}


	public void Update(){
		if(paused == true){
			 if(Input.GetButtonDown("Fire1")){
				Unpause();
				button.SetActive(true);
			 }
		}
	}
}
