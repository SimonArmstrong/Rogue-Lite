using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hulking : Enemy {
	
	public override Vector3 Movement(){
		// Fear effect...
		if(target == null)
			return Vector3.zero;
		
		return (target.transform.position - transform.position).normalized * animator.GetRootMotion();
	}
}
