using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekinesis : MonoBehaviour {
	public bool drawRay;
	private LineRenderer targetLine;
	public Rigidbody target;
	public Hand myHand;
	public bool start;
	private GameObject grabPoint;
	public float followSpeed = 1f;
	public Material[] mats;
	// Use this for initialization
	void Start () {
		targetLine = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(grabPoint == null)
			TargetRay();
		if (start && target != false)
			GrabObject();

		if(grabPoint != null && target != null) {
			target.velocity = ((grabPoint.transform.position - target.transform.position) * (Vector3.Distance(target.transform.position, grabPoint.transform.position) + 0.1f)) * followSpeed;
			targetLine.SetPosition(0, transform.position);
			targetLine.SetPosition(1, target.transform.position);
			target.transform.rotation = transform.rotation;
		}

		if (SteamVR_Controller.Input(myHand.myIndex).GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && target != null) {
			GrabObject();
		}
		if (SteamVR_Controller.Input(myHand.myIndex).GetPressUp(SteamVR_Controller.ButtonMask.Trigger) && grabPoint != null) {
			ReleaseObject();
		}
	}

	void TargetRay() {
		RaycastHit hit = new RaycastHit();
		if(Physics.Raycast(transform.position,transform.forward, out hit)){
			if (hit.collider.gameObject.tag == "Movable") {
				if (drawRay) {
					targetLine.SetPosition(0, transform.position);
					targetLine.SetPosition(1, hit.point);
					targetLine.material = mats[0];
				}
				target = hit.collider.gameObject.GetComponent<Rigidbody>();

			}
			else {
				target = null;
				targetLine.SetPosition(0, transform.position);
				targetLine.SetPosition(1, hit.point);
				targetLine.material = mats[1];
			}
		}
		else {
			target = null;
		}
	}
	void GrabObject() {
		start = false;
		grabPoint = Instantiate(new GameObject(), target.transform.position, target.transform.rotation);
		grabPoint.transform.parent = transform;
		target.useGravity = false;
	}

	void ReleaseObject() {
		target.useGravity = true;
		target = null;
		Destroy(grabPoint);
	}

}
