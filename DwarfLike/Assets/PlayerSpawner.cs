using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
	public GameObject playerPrefab;
	// Use this for initialization
	void Start () {
		
		RespawnPlayer();
	}
	
	public void RespawnPlayer(){
		GameManager.instance.player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
		GameManager.instance.player.GetComponent<Player>().currentRoom = Dungeon.instance.dungeon_rooms[0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
