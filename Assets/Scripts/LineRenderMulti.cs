using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LineRenderMulti : MonoBehaviour {
	public Transform[] positions;
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
		if (myRend != null && positions.Length > 0 && material != null) {
			myRend.positionCount = positions.Length;
			for(int i = 0; i < positions.Length; i++) {
				myRend.SetPosition(i, positions[i].position);
			}
			myRend.startWidth = width;
			myRend.endWidth = width;
			if (material != null)
				myRend.material = material;
		}
	}
}
