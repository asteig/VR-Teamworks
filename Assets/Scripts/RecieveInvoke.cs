using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveInvoke : MonoBehaviour {

	//extend this in other scripts to use them with TriggerInvoke

	public void InvokeTheThing(string what) {
		Invoke(what, 0);
	}
}
