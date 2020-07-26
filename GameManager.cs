using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public bool gameOver;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }


	void Start () {
        gameOver = false;		
	}
	

	void Update () {
		
	}

    public void GameStart()
    {
        UiManager.instance.GameStart(); //this will engage the ui manager gamestart() function...taptostart text will be deactivated and planeup animation will be run
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms(); // only start spawning new platforms when game starts
    }

    public void GameOver()
    {
        UiManager.instance.GameOver();
        ScoreManager.instance.StopScore();
        gameOver = true;
    }
}
