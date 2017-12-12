using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LineRender : MonoBehaviour {
	public Transform pos1;
	public Transform pos2;
	public float width;
	public Material material;
	private LineRenderer myRend;
	
	void Start () {
		myRend = GetComponent<LineRenderer>();
		if(myRend == null) {
			gameObject.AddComponent<LineRenderer>();
			myRend = GetComponent<LineRenderer>();
		}
	}
	
	//draws a constantly updated line between two defined points
	void Update () {
		if (myRend != null) {
			if(pos1 != null)
				myRend.SetPosition(0, pos1.position);
			if (pos2 != null)
				myRend.SetPosition(1, pos2.position);
			myRend.startWidth = width;
			myRend.endWidth = width;
			if (material != null)
				myRend.material = material;
		}
	}
}
