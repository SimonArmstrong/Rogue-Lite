using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

	public float health_cur = 3;
	public float health_max = 3;
	
	public FlashEffect flashEffect;
	
	public Stats stats;
	
	public GameObject[] drops;
	bool dead;
	
	// Use this for initialization
	void Start () {
		
	}
	
	public virtual void OnTriggerEnter2D(Collider2D other){
		//Debug.Log(other.gameObject.name + " > " + gameObject.name);
		DamageCollider damageCollider = other.GetComponent<DamageCollider>();
		if(damageCollider != null){
			if(damageCollider.sender == this) return;
			if(other.gameObject.layer == 10){
				float dmg = damageCollider.damage;
				health_cur -= dmg;
			
				UI_WhiteScreen.alpha = 1;
				
				//if(flashEffect != null)
					//flashEffect.scale = 1;
				
				Vector3 dir = (other.transform.position - transform.position).normalized;
				GetComponent<Rigidbody2D>().AddForce(-dir * (30 + (dmg*50)));
				return;
			}
		}
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if(health_cur > health_max){
			health_cur = health_max;
		}
		
		if(health_cur <= 0){
			health_cur = 0;
			Die();
		}
	}
	int counter = 0;
	
	public virtual void Die(){
		Destroy(gameObject);
		int z = Random.Range(1, 1);
		if(counter < z){
			if(drops.Length == 0) return;
			//bool x = (Random.Range(0, 100) < drops[Random.Range(0, drops.Length)].GetComponent<Drop>().dropChance);
			//if(x){
				GameObject go = Instantiate(drops[Random.Range(0, drops.Length)], transform.position, Quaternion.identity);
				Vector3 forceDir = (go.transform.position - (new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0).normalized)).normalized;
				Vector3 dir = (GameManager.instance.player.transform.position - transform.position).normalized;
				go.GetComponent<Rigidbody2D>().AddForce(-dir * 500);
			//}
			counter++;
		}
		GetComponent<SpriteRenderer>().enabled = false;
		//GetComponent<Collider>().enabled = false;
		
		//if(counter == z)
	}
}
