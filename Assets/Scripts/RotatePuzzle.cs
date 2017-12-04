using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePuzzle : MonoBehaviour {
    public SteamVR_Controller.Device device;
	public SteamVR_TrackedObject rightHand;

	// Axis of Rotation
	public GameObject axis1;
	public GameObject axis2;
	public GameObject axis3;

	// Objects to be rotated
	public GameObject axis1Object;
	public GameObject axis2Object;
	public GameObject axis3Object;

	// Handles
	public GameObject handle1;
	public GameObject handle2;
	public GameObject handle3;

	// Solution Indicators
	public GameObject sol1;
	public GameObject sol2;
	public GameObject sol3;

	SteamVR_TrackedObject handle1Tracked;
	SteamVR_TrackedObject handle2Tracked;
	SteamVR_TrackedObject handle3Tracked;

	// Rotation Initial Displacement ( 0 - 11 )
	public int axis1Init = 1;
	public int axis2Init = 1;
	public int axis3Init = 1;

	// Handle 1 rotation factors
	public int handle1Axis2 = 1;
	public int handle1Axis3 = 1;

	// Handle 2 rotation factors
	public int handle2Axis1 = 1;
	public int handle2Axis3 = 1;

	// Handle 3 rotation factors
	public int handle3Axis1 = 1;
	public int handle3Axis2 = 1;

	// Rotation Solution ( 0 - 11 )
	public int axis1Solution;
	public int axis2Solution;
	public int axis3Solution;

	// Current location
	int currentAxis1;
	int currentAxis2;
	int currentAxis3;

	bool hasGrabbedObject = false;

	// Use this for initialization
	void Start () {
		// Modulo values to keep them in range (0 - 11)
		currentAxis1 = axis1Init % 12;
		currentAxis2 = axis2Init % 12;
		currentAxis3 = axis3Init % 12;

		axis1Solution = axis1Solution % 12;
		axis2Solution = axis2Solution % 12;
		axis3Solution = axis3Solution % 12;

		// Initial rotations and solution
		RotateXAxis(axis1, currentAxis1);
		RotateXAxis(axis2, currentAxis2);
		RotateXAxis(axis3, currentAxis3);
		RotateXAxis(sol1, axis1Solution);
		RotateXAxis(sol2, axis2Solution);
		RotateXAxis(sol3, axis3Solution);

		// Get Tracked Object
		handle1Tracked = handle1.GetComponent<SteamVR_TrackedObject>();
		handle2Tracked = handle2.GetComponent<SteamVR_TrackedObject>();
		handle3Tracked = handle3.GetComponent<SteamVR_TrackedObject>();
	}
	
	// Rotate along X-Axis based on divisions of 12
	void RotateXAxis(GameObject rotatedAxis, int rotateValue)
	{
		float rotateDegrees = (rotateValue + 1)/12f * 360f;
		
		rotatedAxis.transform.localRotation = Quaternion.Euler(new Vector3 (rotateDegrees, 0, 0));
	}

	// Update is called once per frame
	void Update () {
		device = SteamVR_Controller.Input ((int)rightHand.index);
	
	}

	private void OnTriggerStay(Collider obj)
	{
		if (obj.gameObject.tag == "Handle")
		{
			if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger) && !hasGrabbedObject)
			{
				GrabObject(obj);
			}
			if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad) && hasGrabbedObject)
			{
				ReleaseObject(obj);
			}
		}
	}

	public void GrabObject(Collider obj)
    { 
        Rigidbody coliRb = obj.gameObject.GetComponent<Rigidbody>();

        obj.gameObject.transform.SetParent(gameObject.transform);
    
        hasGrabbedObject = true;

        obj.transform.localPosition = new Vector3(0.00f, -0.02f, -0.16f);
        obj.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
    }
		
    public void ReleaseObject(Collider obj)
    {
		Rigidbody coliRb = obj.gameObject.GetComponent<Rigidbody>();

		coliRb.isKinematic = false;
		obj.gameObject.transform.SetParent(null);
    
    }

	bool CheckSolution()
	{
		return (currentAxis1 == axis1Solution && currentAxis2 == axis2Solution && currentAxis3 == axis3Solution );
	}
}
