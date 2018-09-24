using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public GameObject player;
	public bool gameOver;
	public GameObject playerSpawner;
	
	[HideInInspector]
	public int levelSeed;
	// Use this for initialization
	void Awake () {
		instance = this;
	}
	
	float go_t = 5;
	
	// Update is called once per frame
	void LateUpdate () {
		gameOver = (player == null);
		
		if(gameOver){
			go_t -= Time.deltaTime;
			if(go_t <= 0){
				playerSpawner.GetComponent<PlayerSpawner>().RespawnPlayer();
				go_t = 5;
			}
		}
	}
	
	
	
	public void LoadSeedOnMap(int seed){
		levelSeed = seed;
	}
}
