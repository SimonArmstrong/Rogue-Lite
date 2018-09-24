using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour {
	public float damage;
	public Entity sender;
	public bool screenShake = false;
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.GetComponent<Entity>() != sender)
		{
			Entity e = other.GetComponent<Entity>();
			//e.
		}
	}
	
	void Update(){
		if(screenShake)
			ScreenShake.scale = 1;
	}
	
	// Use this for initialization
	void OnEnable () {
		//damage = GameManager.instance.player.GetComponent<Entity>().stats.attackDamage;
	}
}
