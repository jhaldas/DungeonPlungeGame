using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkHandler : MonoBehaviour
{

	public GameObject[] chunkArray = new GameObject[4];	

	public GameObject[] chunks;

	public GameObject camera; 

	public int totalChunks;

	int lastChunkIndex = 0;

	// What position the camera has to cross in order to spawn the next chunk down the road
	private float startingSpawn = 16f;


	void Start(){
		totalChunks = chunks.Length;
		
		CreateChunk(chunks[0], new Vector3(-16f, 0, 0), 0);

        CreateChunk(chunks[0], new Vector3(0f, 0, 0), 1);

        lastChunkIndex = CreateChunk(new Vector3(16f, 0, 0), 2, lastChunkIndex);
		
		lastChunkIndex = CreateChunk(new Vector3(32f, 0, 0), 3, lastChunkIndex);
	}

    // Update is called once per frame
    void Update()
    {
		Debug.Log("" + camera.transform.position.x);
		Debug.Log("" + startingSpawn);
        if(camera.transform.position.x > startingSpawn){
			Debug.Log("Creating and Deleting a thing");
			DeleteChunk();
			lastChunkIndex = CreateChunk(new Vector3(startingSpawn + 32, 0, 0), 3, lastChunkIndex);
			startingSpawn += 16;
		}
    }

	// For choosing a specific chunk index, and spawning it at position
	void CreateChunk(GameObject newChunk, Vector3 position, int arrayPos){
		chunkArray[arrayPos] = Instantiate(newChunk);
		chunkArray[arrayPos].transform.position = position;
	}

	// For choosing a random chunk different from the previous, and spawning it at position.
    // Returns an integer of the last chunk index so the next call can choose a different chunk.
    // This prevents the Chunk Handler from spawning 2 of the same chunk consecutively and making
    // the platforms appear more random.
	int CreateChunk(Vector3 position, int arrayPos, int lastIndex){
		int chunkSelect = Random.Range(0, totalChunks);
		while(chunkSelect == lastIndex){
			chunkSelect = Random.Range(0, totalChunks);
		}
		chunkArray[arrayPos] = Instantiate(chunks[chunkSelect]);
		chunkArray[arrayPos].transform.position = position;

		return chunkSelect;
	}

    // Deletes the chunk in position zero and moves all other chunks 1 up in the array.
	void DeleteChunk(){
		Destroy(chunkArray[0]);
		chunkArray[0] = chunkArray[1];
		chunkArray[1] = chunkArray[2];
		chunkArray[2] = chunkArray[3];
	}


}
