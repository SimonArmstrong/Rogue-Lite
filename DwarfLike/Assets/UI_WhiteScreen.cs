using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_WhiteScreen : MonoBehaviour {
	public static float alpha;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(alpha > 0)
			alpha = Mathf.Lerp(alpha, 0, Time.deltaTime * 10);
		
		GetComponent<Image>().color = new Color(1, 1, 1, alpha);
	}
}
