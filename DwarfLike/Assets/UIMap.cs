using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMap : MonoBehaviour {

	public Camera mapCamera;
	bool zoomed = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(zoomed){
			mapCamera.orthographicSize = Mathf.Lerp(mapCamera.orthographicSize, 35, Time.deltaTime * 10);
			if(GameManager.instance.player != null){
				if(GameManager.instance.player.GetComponent<Player>().currentRoom != null)
					mapCamera.GetComponent<MapCamera>().target = GameManager.instance.player.GetComponent<Player>().currentRoom.transform.position;
			}
		}
		else{
			Vector3 point = new Vector3 (Dungeon.instance.centerPoint.x, Dungeon.instance.centerPoint.y, mapCamera.transform.position.z);
			mapCamera.GetComponent<MapCamera>().target = point;
			mapCamera.orthographicSize = Mathf.Lerp(mapCamera.orthographicSize, 70, Time.deltaTime * 10);
		}
	}
	
	public void ToggleZoom(){
		zoomed = !zoomed;
	}
	
}
