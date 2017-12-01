using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {
	private SteamVR_TrackedObject myTrack;
	public int myIndex;
	public Transform myAnchor;
	public bool trigger;
	public bool grip;
	public bool isHoldingObject = false;
	public bool left = false;
	public GameObject Pointer;
	private float snapTimer = 0;
	public static GameObject moveHand;
	// Use this for initialization
	void Awake() {
		if (!left)
			moveHand = gameObject;
	}
	void Start () {
		myTrack = GetComponent<SteamVR_TrackedObject> ();
		myIndex = (int)myTrack.index;
	}
	
	// Update is called once per frame
	void Update () {
		if (snapTimer > 0)
			snapTimer -= Time.deltaTime;
		if (SteamVR_Controller.Input (myIndex).GetPress (SteamVR_Controller.ButtonMask.Grip)) {
			grip = true;
		} 
		else {
			grip = false;
		}


		if (SteamVR_Controller.Input (myIndex).GetPress (SteamVR_Controller.ButtonMask.Trigger)) {
			trigger = true;
			Pointer.SetActive (true);
		} 
		else if(!SteamVR_Controller.Input (myIndex).GetPress (SteamVR_Controller.ButtonMask.Trigger)){
			trigger = false;
			Pointer.SetActive(false);
		}


		if (SteamVR_Controller.Input (myIndex).GetPressDown (SteamVR_Controller.ButtonMask.ApplicationMenu) && left) {
		//	if(theMenu.activeInHierarchy)
		//		theMenu.SetActive(false);
		//	else if(!theMenu.activeInHierarchy)
		//		theMenu.SetActive(true);
		}

		if ((SteamVR_Controller.Input (myIndex).GetPressDown (SteamVR_Controller.ButtonMask.Trigger) || Input.GetKeyDown(KeyCode.P))) {
			Snap ();
		}
		if (SteamVR_Controller.Input(myIndex).GetPressUp(SteamVR_Controller.ButtonMask.Trigger) && !left) {
			MCP.mcp.CastSpell();
		}
		if (SteamVR_Controller.Input(myIndex).GetPress(SteamVR_Controller.ButtonMask.Grip) && !left) {
			MCP.mcp.EndSpell();
		}
	}

	void Snap(){
		//snapTimer = 0;
		SteamVR_Controller.Input(myIndex).TriggerHapticPulse(2000);
		GetComponent<AudioSource> ().Play ();
	}

	void OnTriggerEnter(){
		SteamVR_Controller.Input(myIndex).TriggerHapticPulse(2000);
	}
}
