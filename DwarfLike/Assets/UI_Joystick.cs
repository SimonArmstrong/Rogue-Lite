using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Joystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnDrag(PointerEventData e){
		GetComponent<RectTransform>().anchoredPosition = (e.position - transform.parent.GetComponent<RectTransform>().anchoredPosition) + (transform.parent.GetComponent<RectTransform>().anchoredPosition / 2);
	}
	
	public void OnEndDrag(PointerEventData e){
		GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
	}
	
	public void OnBeginDrag(PointerEventData e){}
}
