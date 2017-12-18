using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constellation : MonoBehaviour {

	public GameObject StarA;
	public GameObject StarB;

	private Transform[] childList;
	// Use this for initialization
	void Start () {

		Debug.Log("I am a constellation and I will do constellationy things.");

		childList = transform.GetComponentsInChildren<Transform>();

		for (int i = 1; i < childList.Length; i++) {

			//if material is default {}
			if (childList[i].GetComponent<MeshRenderer>() != null) {
				childList[i].GetComponent<MeshRenderer>().enabled = false;
				GameObject star = Instantiate(StarA, childList[i].transform.position, transform.rotation, tra);
				star.transform.parent = transform;
				star.transform.position = childList[i].transform.position;
			}
		}
			
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	void Dazzle (Color color) {
		
	}
}
