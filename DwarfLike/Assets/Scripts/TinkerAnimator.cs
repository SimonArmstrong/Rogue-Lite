using UnityEngine;
using System.Collections;

public class TinkerAnimator : MonoBehaviour {
	public TinkerAnimation[] animations;
	public int currentAnimation = 0;
	public bool destroyAfterPlayed;
	public SpriteRenderer renderer;
	public GameObject soundObject;

	[HideInInspector]
	public int frameIndex = 0;
	float timer;
	
	private bool isChild = false;

	private void Start(){
		timer = animations [currentAnimation].timeBetweenFrames;
	}
	GameObject dc = null;
	private void SwitchFrames (){
		// Reset frames if we've reached the end -- Creates Loop
		if (frameIndex > animations [currentAnimation].sprites.Length - 1) {
			if (destroyAfterPlayed)
				Destroy (gameObject);
			frameIndex = 0;
		}

		// If we haven't involved a renderer, involove it
		if (renderer == null) {
			renderer = GetComponent<SpriteRenderer> ();
		}

		// 
		if(animations[currentAnimation].useSoundEffects){
			if(animations[currentAnimation].clips[frameIndex] != null){
				soundObject.GetComponent<AudioSource>().clip = animations[currentAnimation].clips[frameIndex];
				GameObject so = Instantiate(soundObject, transform.position, Quaternion.identity);
			}
		}
		
		if(animations[currentAnimation].useDamageColliders){
			if(dc != null) Destroy(dc);
			if(animations[currentAnimation].damageColliders[frameIndex] != null){
				dc = Instantiate(animations[currentAnimation].damageColliders[frameIndex], transform.position, Quaternion.identity, transform);
			}
		}
		
		renderer.sprite = animations[currentAnimation].sprites [frameIndex];
	}

	private void Update(){
		if (animations.Length > 0) {
			timer -= Time.deltaTime;
			if (timer <= 0) {
				frameIndex++;
				SwitchFrames ();
				timer = animations [currentAnimation].timeBetweenFrames;
			}
		}
	}

	public float GetRootMotion(){
		if(!animations[currentAnimation].useMotionMulitplier) return 0.0f;
		if(frameIndex >= animations[currentAnimation].frameMovement.Length) return 0.0f;
		return animations[currentAnimation].frameMovement[frameIndex];
	}
	
	public TinkerAnimation GetCurrentAnimation(){
		return animations [currentAnimation];
	}

	public string GetAnimationName(){
		return animations [currentAnimation].name;
	}
}
