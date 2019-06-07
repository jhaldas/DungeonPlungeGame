using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
	
	public Text text;
	public float score;

    // Update is called once per frame
    void Update()
    {
		text.text = "Final Score: " + score;
	}
}
