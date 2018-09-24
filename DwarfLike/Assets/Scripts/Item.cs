using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Item")]
public class Item : ScriptableObject {
	public Stats stats;
	public GameObject itemObject;
	
	public void Equip(Entity target){
		//itemObject.GetComponent<ItemObject>().item = this;
		
		target.stats.Add(stats);
	}
	
	public void Unequip(Entity target){
		target.stats.Subtract(stats);
	}
}
