using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {
	public RoomObject currentRoom;
	public GameObject swingObject;
	public float sceneTransitionDelay = 1;
	public Camera cam;
	Vector3 mousePos;
	
	RoomObject tempCurrentRoom;
	Door tempDoor;
	float t;
	
	float a_t = 0.0f; // atk cooldwn
	
	public Transform target;
	
	public float veloSpeed;
	public bool hasMap = false;
	bool click = false;
	
	public List<Item> items = new List<Item>();
	
	public TinkerAnimator animator;
	
	// Use this for initialization
	void Start () {
		t = 0;
		currentRoom = Dungeon.instance.dungeon_rooms[0];
		animator = GetComponentInChildren<TinkerAnimator>();
		cam = Camera.main;
	}
	
	Vector3 initPos = Vector3.zero;
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetMouseButtonDown(0)) initPos = Input.mousePosition;
		if(Input.GetMouseButton(0)){
			if(t < 0.1f)
				transform.Translate(GetMove() * Time.deltaTime * stats.movementSpeed);
		}
		else{ veloSpeed = 0;}
		
		HandleTargeting();
	}
	
	void HandleTargeting(){
		a_t -= Time.deltaTime;
		if(target != null){
			transform.Translate(GetMove() * Time.deltaTime * stats.movementSpeed);
			float dist = (target.position - transform.position).magnitude;
			if(target.GetComponent<Entity>() == false) return;
			if(Input.GetMouseButtonDown(0)){ target = null; return; }
			if(dist < 1.5f)
				Attack();
		}
	}
	
	public override void OnTriggerEnter2D(Collider2D col){
		base.OnTriggerEnter2D(col);
		if(col.GetComponent<Door>() != null){
			currentRoom.room.isCurrent = false;
			tempDoor = col.GetComponent<Door>();
			tempCurrentRoom = tempDoor.roomObject;
			tempCurrentRoom.room.seen = true;
			t = sceneTransitionDelay;
		}
	}
	bool tick = true;
	
	
	Vector3 GetMovementFromDrag(){
		Vector3 currentPos = Input.mousePosition;
		
		Vector3 total = (currentPos - initPos);
		veloSpeed = Vector3.ClampMagnitude(total.normalized * (total.magnitude * 0.01f), 1.0f).magnitude;
		return Vector3.ClampMagnitude(total.normalized * (total.magnitude * 0.01f), 1.0f);
	}
	
	
	public override void Update (){
		base.Update();
		if(t > 0){
			t -= Time.deltaTime;
			if(t < 0.1f){
				currentRoom = tempCurrentRoom;
				currentRoom.room.isCurrent = true;
				transform.position =  tempDoor.spawnPoint.position;
				target = null;
				Dungeon.instance.UpdateRooms();
			}
		}
		if(Camera.main.GetComponent<DungeonCamera>().locked){
			if(currentRoom != null) Camera.main.GetComponent<DungeonCamera>().target = currentRoom.transform.position;
		}
		
		if(hasMap) Dungeon.instance.ReadMap();
		click = false;
		if(Input.GetMouseButton(0)){
			click = true;
		}

		HandleInteraction();
		// transform.GetChild(0).GetComponent<Animator>().SetFloat("hopSpeed", veloSpeed);
		
		if(currentRoom == null) currentRoom = Dungeon.instance.dungeon_rooms[0];
	}
	
	public void AttackTarget(){
		
	}
	
	public void Attack(){		
		if(a_t <= 0){
			Vector3 dir = (target.position - transform.position).normalized;

			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion rot = Quaternion.AngleAxis (angle + 90, Vector3.forward);

			DamageCollider dc = Instantiate (swingObject, ZeroZ ((transform.position + (dir * 1.4f))), rot).GetComponent<DamageCollider>();
			dc.damage = stats.attackDamage;
			dc.sender = this;
			
			GetComponent<Rigidbody2D>().AddForce(dir * 500);
			a_t = stats.attackSpeed;
		}
	}

	Vector3 ZeroZ(Vector3 inVec){
		return new Vector3 (inVec.x, inVec.y, 0);
	}

	public void AddItem(Item item){
		item.Equip(this);
		
		//GameObject go = MonoBehaviour.Instantiate(item.itemObject, Vector3.zero, Quaternion.identity, target.transform);
		//go.transform.localPosition = Vector3.zero;
		
		items.Add(item);
	}
	
	public void RemoveItem(Item item){
		item.Unequip(this);
		
		GameObject go = MonoBehaviour.Instantiate(item.itemObject, Vector3.zero, Quaternion.identity, target.transform);
		go.transform.localPosition = Vector3.zero;
		
		items.Remove(item);
	}
	
	Vector3 GetMove(){
		
		Vector3 result = GetMovementFromDrag();
		//Vector3 result = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
		if(target != null)
			result = Vector3.ClampMagnitude((target.position - transform.position).normalized, 1.0f);
		
		if(result.y < 0.3f){	// DOWN
			animator.renderer.flipX = false;
			animator.currentAnimation = 1;
		}
		else if(result.x > 0){	// RIGHT
			animator.renderer.flipX = true;
			animator.currentAnimation = 2;
		}
		if(result.y > 0.3f){	// UP
			animator.renderer.flipX = false;
			animator.currentAnimation = 0;
		}
		else if(result.x < 0){	// LEFT
			animator.renderer.flipX = false;
			animator.currentAnimation = 2;
		}
		
		return result;
	}
	
	void HandleInteraction(){
		Vector2 rayPos = new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit=Physics2D.Raycast(rayPos, Vector2.zero, 0f);
        //mousePos = (rayPos)
		mousePos = rayPos;
		
		if(Input.GetMouseButtonDown(0)){	
			if(!hit) return;
			if(hit.transform.gameObject.layer != 2){
				target = hit.transform;
			}
		}
	}
	
	public override void Die(){
		GameManager.instance.playerSpawner.GetComponent<PlayerSpawner>().RespawnPlayer();
		base.Die();
	}
	
	void OnGUI(){
		if(click){
			GUI.Box(new Rect(initPos.x - 10, -((initPos.y + 10) - Screen.height), 20, 20), "memes");			
		}
	}
}
