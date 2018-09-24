using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staircase : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			Progress();
		}
	}
	
	void Progress(){
		Dungeon.instance.Progress();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
