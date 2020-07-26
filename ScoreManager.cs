using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;
    public int score;
    public int highScore;

	void Awake () {
        if (instance == null)
            instance = this;
	}

    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score); // score is value stored in "score"
    }

    
    void Update () {
		
	}

    public void IncrementScore()
    {
        score += 1;
    }

    public void DiamondScore()
    {
        score += 2;
    }

    public void StopScore()
    {
       
        PlayerPrefs.SetInt("score", score); 

        if (PlayerPrefs.HasKey("highScore")) 
        {
            if(score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score); 
            }
        }
        else 
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
