using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkHandler : MonoBehaviour
{

	public GameObject[] chunkArray = new GameObject[4];	

	public GameObject[] chunks;

	public CameraFollow camera; 

	public int totalChunks;

	int lastChunkIndex = 0;

	// What position the camera has to cross in order to spawn the next chunk down the road
	private float startingSpawn = 32f;


	void Start(){
		totalChunks = chunks.Length;
		
		CreateChunk(chunks[0], new Vector3(0, 0, 0), 0);
		
		lastChunkIndex = CreateChunk(new Vector3(16, 0, 0), 1, lastChunkIndex);

		lastChunkIndex = CreateChunk(new Vector3(32, 0, 0), 2, lastChunkIndex);
		
		lastChunkIndex = CreateChunk(new Vector3(48, 0, 0), 3, lastChunkIndex);
	}

    // Update is called once per frame
    void Update()
    {
		Debug.Log("" + camera.GetCameraPositionX());
		Debug.Log("" + startingSpawn);
        if(camera.GetCameraPositionX() > startingSpawn){
			Debug.Log("Creating and Deleting a thing");
			
			DeleteChunk();
			lastChunkIndex = CreateChunk(new Vector3(startingSpawn + 32, 0, 0), 3, lastChunkIndex);
			startingSpawn += 16;
		}
    }

	// For choosing a specific chunk index
	void CreateChunk(GameObject newChunk, Vector3 position, int arrayPos){
		chunkArray[arrayPos] = Instantiate(newChunk);
		chunkArray[arrayPos].transform.position = position;
	}

	// For choosing a random chunk different from the previous
	int CreateChunk(Vector3 position, int arrayPos, int lastChunkIndex){
		int chunkSelect = Random.Range(0, totalChunks);
		while(chunkSelect == lastChunkIndex){
			chunkSelect = Random.Range(0, totalChunks);
		}
		chunkArray[arrayPos] = Instantiate(chunks[chunkSelect]);
		chunkArray[arrayPos].transform.position = position;

		return chunkSelect;
	}

	void DeleteChunk(){
		Destroy(chunkArray[0]);
		chunkArray[0] = chunkArray[1];
		chunkArray[1] = chunkArray[2];
		chunkArray[2] = chunkArray[3];
	}


}
