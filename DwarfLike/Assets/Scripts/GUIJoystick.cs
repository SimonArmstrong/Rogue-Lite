using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIJoystick : MonoBehaviour {
	[Header("Vectors")]
	public Vector2 screenPosition;
	public Vector2 inputPosition;
	
	[Header("Scaling")]
	public float baseWidth;
	public float knobWidth;
	
	[Header("Visuals")]
	public Sprite joystickBaseSprite; 
	public Sprite joystickKnobSprite;
	
	public Vector3 GetDirection(){
		Vector3 result = Vector3.zero;
		return result;
	}
	
	public void OnGUI(){
		Rect baseRect = new Rect(
			screenPosition.x - (baseWidth * 0.5f),
			screenPosition.y - (baseWidth * 0.5f),
			baseWidth,
			baseWidth
		);
		
		Rect joyRect = new Rect(
			inputPosition.x - (knobWidth * 0.5f),
			inputPosition.y - (knobWidth * 0.5f),
			knobWidth,
			knobWidth
		);
		
		GUI.DrawTexture(baseRect, joystickBaseSprite.texture);
		GUI.DrawTexture(joyRect, joystickKnobSprite.texture);
	}
}
