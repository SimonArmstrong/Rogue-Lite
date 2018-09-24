using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.GetComponent<Entity>() !=null)
		{
			Entity e = other.GetComponent<Entity>();
			if(e.gameObject.tag == "Player"){
				transform.parent.GetComponent<Enemy>().target = e;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
