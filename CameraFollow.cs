using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject ball;
    Vector3 offset; // distance from camera
    public float lerpRate; // linear interpolation rate
    public bool gameOver;

	
	void Start () {
        offset = ball.transform.position - transform.position;
        gameOver = false;
	}
	
	
	void Update () {
        if (!gameOver)
            Follow();
	}

    void Follow()
    {
        Vector3 pos = transform.position; // current camera pos
        Vector3 targetPos = ball.transform.position - offset; // distance from ball
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime); // using linear interpolated values from two point.. moves on from one value to another value at a certain rate
        transform.position = pos;
    }
}
