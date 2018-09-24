using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour {
	public Item item;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 dir = (GameManager.instance.player.transform.position - transform.position);
		float dist = dir.magnitude;
		dir.Normalize();
		if(dist < 0.5f){
			// increase something
			GameManager.instance.player.GetComponent<Player>().AddItem(item);
			Destroy(gameObject);
		}
	}
}
