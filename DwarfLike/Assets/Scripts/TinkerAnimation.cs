using UnityEngine;

using System.Collections;

[CreateAssetMenu(fileName="Tinker Animation", menuName="Tinker/Tinker Animation", order=2)]
public class TinkerAnimation : ScriptableObject {
	public string name;
	public Sprite[] sprites;
	
	public float timeBetweenFrames;
	
	public bool useMotionMulitplier = false;
	public float[] frameMovement;
	
	public bool useSoundEffects = false;
	public AudioClip[] clips;
	
	public bool useDamageColliders = false;
	public GameObject[] damageColliders;
}
