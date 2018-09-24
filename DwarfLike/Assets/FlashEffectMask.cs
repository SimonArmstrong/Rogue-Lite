using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashEffectMask : MonoBehaviour {
	public SpriteRenderer renderer;
	private SpriteMask spriteMask;
	// Use this for initialization
	void Start () {
		spriteMask = GetComponent<SpriteMask>();
	}
	
	// Update is called once per frame
	void Update () {
		spriteMask.sprite = renderer.sprite;
	}
}
