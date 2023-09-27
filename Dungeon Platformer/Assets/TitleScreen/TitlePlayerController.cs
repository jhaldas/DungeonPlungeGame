using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePlayerController : MonoBehaviour
{

	public Vector3 offset;
	public GameObject camera;


    // Start is called before the first frame update
    void Start()
    {
        //Screen.SetResolution(480, 480, true);
        offset = transform.position - camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = camera.transform.position + offset;
    }
}
