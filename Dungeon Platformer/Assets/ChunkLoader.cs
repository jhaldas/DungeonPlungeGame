using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkLoader : MonoBehaviour
{
	public GameObject[] chunkArray = new GameObject[0];	

	public GameObject[] numChunks;

	public GameObject camera; 

	private int totalChunks;

	int lastChunkIndex = 0;

	public float chunkSize;

	// What position the camera has to cross in order to spawn the next chunk down the road
	private float startingSpawn;


	void Start(){
		startingSpawn = chunkSize;
		totalChunks = numChunks.Length;


		CreateChunk(numChunks[0], new Vector3(-chunkSize, 0, 0), 0);
		CreateChunk(numChunks[0], new Vector3(0, 0, 0), 1);
		CreateChunk(numChunks[0], new Vector3(chunkSize, 0, 0), 2);
		CreateChunk(numChunks[0], new Vector3(chunkSize * 2, 0, 0), 3);

	}

    // Update is called once per frame
    void Update()
    {
		//Debug.Log("" + camera.transform.position.x);
		//Debug.Log("" + chunkSize);
        if(camera.transform.position.x > startingSpawn){
			//Debug.Log("Creating and Deleting a thing");
			DeleteChunk();
			lastChunkIndex = CreateChunk(new Vector3(startingSpawn + (chunkSize * 2), 0, 0), 3, lastChunkIndex);
			startingSpawn += chunkSize;
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
		chunkArray[arrayPos] = Instantiate(numChunks[chunkSelect]);
		chunkArray[arrayPos].transform.position = position;

		return chunkSelect;
	}

	void DeleteChunk(){
		Destroy(chunkArray[0]);

		for(int i = 1; i < chunkArray.Length; i++){
			chunkArray[i - 1] = chunkArray[i];
		}
	}


}

