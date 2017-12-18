using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodGate : MonoBehaviour {
	public NewtonVR.NVRButton button;
	public Animator myAnim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		myAnim.SetBool("Open", button.ButtonIsPushed);
		
	}
}
