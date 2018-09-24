using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaySeed : MonoBehaviour {
	public TextMeshProUGUI text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		text.text = GameManager.instance.levelSeed.ToString();
	}
	
	public static void UpdateSeed(){
	}
}
