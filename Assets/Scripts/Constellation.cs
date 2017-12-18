using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constellation : MonoBehaviour {

	public GameObject StarA;
	public GameObject StarB;

	private GameObject star;

	// Use this for initialization
	void Start () {

		foreach (Transform child in transform) {
			child.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
			star = Instantiate(StarA, child.transform.position+new Vector3(0,0,0),Quaternion.identity) as GameObject;
			star.SetActive(true);
			star.transform.parent = gameObject.transform;
		}
			
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	void Spark (Color color) {
		
	}
}
