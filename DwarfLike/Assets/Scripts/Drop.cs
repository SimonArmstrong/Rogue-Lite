using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {
	float speed = 2;
	public float dropChance = 50;
	public AudioSource aSource;
	// Use this for initialization
	void Start () {
		aSource = GameManager.instance.player.transform.GetChild(2).GetComponent<AudioSource>();
	}
	float t = 0.5f;
	// Update is called once per frame
	void Update () {
		//speed += Time.deltaTime;
		t -= Time.deltaTime;
		if(t <= 0){
			speed += Time.deltaTime * 2;
			Vector3 dir = (GameManager.instance.player.transform.position - transform.position);
			float dist = dir.magnitude;
			dir.Normalize();
			transform.position += dir * Time.deltaTime * speed;
			if(dist < 0.2f){
				// increase something
				Destroy(gameObject);
				aSource.Play();
			}
		}
	}
}
