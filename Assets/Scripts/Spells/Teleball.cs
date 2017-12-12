using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleball : MonoBehaviour {
	public GameObject marker;
	public Teleport tp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag != "Player" && other.gameObject.tag != "PlayerHand" && other.gameObject.tag != "Finger") {
			RaycastHit hit;
			if (Physics.Raycast(transform.position, Vector3.down, out hit)) {
				if (hit.collider.gameObject.tag == "Floor") {
					Transform spot = Instantiate(marker, hit.point, transform.rotation).transform;
					tp.marker = spot;
					if (!SteamVR_Controller.Input(tp.myHand.myIndex).GetPress(SteamVR_Controller.ButtonMask.Trigger)) {
						tp.TeleportToMarker();
					}
				}
			}
			Destroy(gameObject);
		}
	}
}
