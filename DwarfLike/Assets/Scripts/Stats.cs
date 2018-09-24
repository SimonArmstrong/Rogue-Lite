using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats {
	public float attackDamage;
	public float attackSpeed;
	public float attackRange;
	
	public float movementSpeed;
	public float health;
	
	public void Add(Stats stats){
		this.attackDamage += stats.attackDamage;
		this.attackSpeed += stats.attackSpeed;
		this.attackRange += stats.attackRange;
		
		this.movementSpeed += stats.movementSpeed;
		this.health += stats.health;
	}
	
	public void Subtract(Stats stats){
		this.attackDamage -= stats.attackDamage;
		this.attackSpeed -= stats.attackSpeed;
		this.attackRange -= stats.attackRange;
		
		this.movementSpeed -= stats.movementSpeed;
		this.health -= stats.health;
	}
}
