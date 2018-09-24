using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Entity {
	public float speed = 2;
	public float timer = 3;
	float t = 3;
	// Use this for initialization
	void Start () {
		t = timer;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += Wander() * Time.deltaTime * speed;
	}
	

	
	int i = 0;
	Vector3 Wander(){
		Vector3[] dirs = {Vector3.up, Vector3.down, Vector3.left, Vector3.right};
		t -= Time.deltaTime;
		
		if(t <= 0){
			i = Random.Range(0, 4);	
			t = timer;
		}
		Vector3 movement = dirs[i];
		
		return movement;
	}
}
