using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LineRender : MonoBehaviour {
	public Transform pos1;
	public Transform pos2;
	private LineRenderer myRend;

	void Start () {
		myRend = GetComponent<LineRenderer>();
	}
	
	//draws a constantly updated line between two defined points
	void Update () {
		myRend.SetPosition(0, pos1.position);
		myRend.SetPosition(1, pos2.position);
	}
}
