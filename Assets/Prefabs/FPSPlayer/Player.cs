using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	[Header("Player stats")]
	public float speed = 5;
	public float jumpStr = 5;

	[Header("References")]
	public PhysicMaterial[] physMats;
	public static Transform playerPosition;
	public static Player staticPlayer;
	
	private float distanceToGround = 0;
	private bool canMove = true;
	private Rigidbody myBody;
	private bool grounded;
	// Use this for initialization
	void Awake () {
		staticPlayer = this;
		myBody = GetComponent<Rigidbody> ();
		playerPosition = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		DistanceToGroundCheck ();
		if (canMove) {
			MoveManager();
			JumpManager();
		}

		
	}

	
	void MoveManager(){
		Vector3 moveAdj = transform.forward * Input.GetAxis("Vertical") * speed;
		moveAdj += transform.right * Input.GetAxis("Horizontal") * speed;
		if(Mathf.Abs(Input.GetAxis("Horizontal")) != 0 && Mathf.Abs(Input.GetAxis("Vertical")) != 0)
			moveAdj *= 0.75f;
		moveAdj.y = myBody.velocity.y;
		myBody.velocity = moveAdj;
	}
	void JumpManager(){
		if (Input.GetButton ("Jump") && grounded) {
			grounded = false;
			myBody.AddForce(0,jumpStr * 200,0);
		//	transform.parent = normalParent;
		}
	}


	void UnGround(){
		if(distanceToGround > 1.2f)
			grounded = false;
	}
	void DistanceToGroundCheck(){
		RaycastHit hit;
		if(Physics.Raycast(transform.position, Vector3.down, out hit)){
			distanceToGround = Vector3.Distance(transform.position,hit.point);
		}
		if (distanceToGround > 1.2f)
			Invoke ("UnGround", 0.3f);
		else if (distanceToGround < 1.2f && !Input.GetButton ("Jump"))
			grounded = true;
	}
}
