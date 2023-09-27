using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	  public float speed;


    // Update is called once per frame
    void Update()
    {
		    Vector3 movespeed = new Vector3(speed, 0, 0);
        gameObject.transform.position = gameObject.transform.position + movespeed;
    }
}
