using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public AudioSource music;
    public static GameManager instance;
    public bool gameOver;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
       
    void Start ()
    {
        music = GetComponent<AudioSource>();
        gameOver = false;
	}

	void Update () {
		
	}

    public void StartGame()
    {
        UiManager.instance.GameStart();
        ScoreManager.instance.StartScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().SpawnPlatform();
        music.Play();
    }

    public void GameOver()
    {
        UiManager.instance.GameOver();
        ScoreManager.instance.StopScore();
        gameOver = true;
        music.Stop();
    }
}
