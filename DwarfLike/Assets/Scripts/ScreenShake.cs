using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {
	public AnimationCurve shakeX;
	public AnimationCurve shakeY;

	public float speed;

	float xTimeline;
	float yTimeline;

	public static float scale = 0.0f;

	void Update(){
		Play ();
	}

	public void Play(){
		if(scale > 0) scale -= Time.deltaTime * 2;
		if (scale <= 0.05f)
			scale = 0;

		if(xTimeline < 1) xTimeline += Time.deltaTime * speed;
		if(yTimeline < 1) yTimeline += Time.deltaTime * speed;

		if (xTimeline >= 1)	xTimeline = 0;
		if (yTimeline >= 1) yTimeline = 0;

		if (transform.position.magnitude > 1) {
			transform.position = Vector3.Lerp (transform.position, new Vector3 (0, 3, -10), Time.deltaTime * 10);
		}

		Vector3 shakeOffset = new Vector3(shakeX.Evaluate(xTimeline)*ScreenShake.scale, shakeY.Evaluate(yTimeline)*ScreenShake.scale, 0);
		transform.Translate (shakeOffset);
	}
}
