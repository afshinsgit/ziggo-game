using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public GameObject diamondBreakParticle;
    public GameObject ballDragParticle;
    public GameObject startParticle;
    AudioSource pickUpSound;
    
    [SerializeField]
    float ballSpeed;   
    bool gameStarted;           
    bool gameOver;
    Rigidbody rb;  
    

    void Awake()
    {
        pickUpSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>(); 
    }

     void Start () 
    {
        gameStarted = false;
        gameOver = false;
    }
	
	void Update () {

        if (!gameStarted) 
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                rb.velocity = new Vector3(ballSpeed, 0, 0);
                gameStarted = true;
                ballDragParticle.SetActive(true);
                Destroy(startParticle, 5f); 

                GameManager.instance.StartGame();
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.yellow); 

        if (!Physics.Raycast(transform.position, Vector3.down, 1f)) 
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);
            Camera.main.GetComponent<CameraFollow> ().gameOver = true;

            GameManager.instance.GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && !gameOver) 
        {
            SwitchDirection();
        }
	}

    void SwitchDirection() 
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(ballSpeed, 0, 0);
        }
        else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, ballSpeed);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Diamond")
        {
            GameObject breakParticle = Instantiate(diamondBreakParticle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            
            Destroy(col.gameObject);
            pickUpSound.Play();
            Destroy(breakParticle, 1f);
        }
    }
}
