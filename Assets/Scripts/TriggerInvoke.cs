using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInvoke : MonoBehaviour {
	public RecieveInvoke myTarget;
	public string expectedTag;
	public string whatToInvoke;
	

	//if the object with the expected tag enters this trigger, invoke the named thing in target script
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == expectedTag) {
			myTarget.InvokeTheThing(whatToInvoke);
		}
	}
}
