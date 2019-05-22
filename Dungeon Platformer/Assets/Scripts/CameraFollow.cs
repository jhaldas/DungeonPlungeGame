using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public GameObject player;
	[Range(1, 50f)]public float cameraDistance = 30f;
	private Vector3 offset;
	[Range(1, 1000f)] public float cameraSpeed = 50;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height/2) / cameraDistance);
		offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if(!player.GetComponent<PlayerController>().IsDead()){
			transform.position = transform.position + (((Vector3.right) / 100) * cameraSpeed);//player.transform.position + offset;
		}
        
    }
}
