using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour {
	enum HandleState { NEUTRAL, CLOCKWISE, COUNTERCLOCKWISE };

	// Handle state
	HandleState handleState;
	// Use this for initialization
	void Start () {
		handleState = HandleState.NEUTRAL;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
