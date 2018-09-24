using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class Attack {
	public float cooldown;
	public float range;
}

public class Enemy : Entity {
	public Entity target;
	[HideInInspector]
	public TinkerAnimator animator;
	
	public delegate void AIBehaviour();
	public AIBehaviour aiBehaviour;
	
	public Attack attack;
	public float at_t;
	
	public float distToTarget;
	bool attacking = false;
	
	public void Start(){
		animator = GetComponent<TinkerAnimator>();
		at_t = 0;
		aiBehaviour = SeekPlayer;
		//target = GameObject.FindWithTag("Player");
	}
	
	public override void Update(){
		base.Update();
		if(target != null)
			distToTarget = (transform.position - target.transform.position).magnitude;
		else
			distToTarget = 999;
		HandleBehaviour();
		aiBehaviour();
		at_t -= Time.deltaTime;
	}
	
	public void SeekPlayer(){
		Vector3 movement = Movement();
		if(target.transform.position.x < transform.position.x){
			animator.renderer.flipX = true;
		}
		else{
			animator.renderer.flipX = false;
		}
		transform.position += movement * Time.deltaTime * stats.movementSpeed;
		animator.currentAnimation = 1;
	}
	
	public virtual void HandleBehaviour(){
		if(attacking) return;
		if(attack.range >= distToTarget && at_t <= 0){
			aiBehaviour = Attack;
			return;
		} 
		else if(at_t <= 0 && target != null){
			aiBehaviour = SeekPlayer;
			return;
		}
		else {
			aiBehaviour = Idle;
			return;
		}
	}
	
	public void Attack(){
		animator.currentAnimation = 2;		
		transform.position += Movement() * Time.deltaTime * stats.movementSpeed;
		
		if(!attacking){	 // If we weren't already attacking
			animator.frameIndex = 0;
			attacking = true;
		}
		
		if(animator.frameIndex >= animator.animations[animator.currentAnimation].sprites.Length - 1){
			attacking = false;
			at_t = attack.cooldown;
		}
	}
	
	public void Idle(){
		animator.currentAnimation = 0;
		
		if(at_t <= 0){
			
		}
	}
	
	public virtual Vector3 Movement(){
		// Fear effect...
		return (transform.position - target.transform.position).normalized;
	}
}
