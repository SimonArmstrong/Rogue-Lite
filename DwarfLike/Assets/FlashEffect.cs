using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashEffect : MonoBehaviour {
	public float scale = 0;
	public SpriteRenderer renderer;
	public float speed = 5;
	
	void Start () {
		renderer = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
		if(scale > 0){
			scale -= Time.deltaTime * speed;
		}
		renderer.color = new Color(1, 1, 1, scale);
	}
}
