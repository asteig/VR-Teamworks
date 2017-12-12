using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
	public Transform player;
	public GameObject teleBall;
	public Hand myHand;
	public Transform marker;
	public float power;
	public bool testShot1;
	public bool testShot2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (testShot1) {
			testShot1 = false;
			FireTeleball();
		}
		if (testShot2) {
			testShot2 = false;
			TeleportToMarker();
		}
		if (SteamVR_Controller.Input(myHand.myIndex).GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
			FireTeleball();
		}
		if (SteamVR_Controller.Input(myHand.myIndex).GetPressUp(SteamVR_Controller.ButtonMask.Trigger) && marker != null) {
			TeleportToMarker();
		}
	}

	void FireTeleball() {
		GameObject ball = Instantiate(teleBall, transform.position, player.rotation);
		ball.GetComponent<Rigidbody>().velocity = transform.forward * power;
		ball.GetComponent<Teleball>().tp = this;

	}

	public void TeleportToMarker() {
		player.position = new Vector3(marker.position.x, player.position.y, marker.position.z);
		Destroy(marker.gameObject);
	}
}
