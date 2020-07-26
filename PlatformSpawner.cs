using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    public GameObject platform;
    public GameObject diamonds;
    public bool gameOver;
    Vector3 lastPosition; // last platform position
    float size; // size of platform

	
	void Start () {
        lastPosition = platform.transform.position;
        size = platform.transform.localScale.x; 	

        for (int i = 0; i < 20; i++) //initialing first set of platform
            SpawnPlatform();
	}
	
	void Update () {
        if (GameManager.instance.gameOver == true)
            CancelInvoke("SpawnPlatform");    //cancel calling spawnplatform whcih means dont spawn new platforms
	}
    
    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatform", 0.1f, 0.2f); // begin creating the next ones   after 0.1 seconds and every 0.2 seconds
    }

    void SpawnPlatform()
    {
        int rand = Random.Range(0, 6); 
        if (rand < 3)
            SpawnX();
        else if (rand >= 3)
            SpawnZ();
    }

    void SpawnX() // spawn platform in X direction
    {
        Vector3 pos = lastPosition;
        pos.x += size; 
        Instantiate(platform, pos, Quaternion.identity); //duplicating the platform with new pos
        lastPosition = pos;
        int rand = Random.Range(0, 4);
        if (rand < 1)
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1.0f, pos.z), diamonds.transform.rotation);
    }

    void SpawnZ() // spawn platform in Z direction
    {
        Vector3 pos = lastPosition;
        pos.z += size;
        Instantiate(platform, pos, Quaternion.identity);
        lastPosition = pos;
        int rand = Random.Range(0, 4);
        if (rand < 1)
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1.0f, pos.z), diamonds.transform.rotation);
    }
}
