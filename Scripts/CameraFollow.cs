using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject ball;
    // Distance between the camera and ball
    Vector3 offset;
    // Change camera position to follow the ball
    public float lerpRate; 
    public bool gameOver;

	void Start ()
    {
        offset = ball.transform.position - transform.position; 
	}
	
	void Update ()
    {
        if(!gameOver)
        {
            CamFollow();
        }
	}
   
    void CamFollow() 
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
