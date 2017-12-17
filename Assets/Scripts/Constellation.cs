using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constellation : MonoBehaviour {

	public GameObject StarA;
	public GameObject StarB;

	private GameObject star;

	// Use this for initialization
	void Start () {
		Debug.Log("I am a constellation and I will do constellationy things.");

		foreach (Transform child in transform) {
			//if material is default {}
			child.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
			star = Instantiate(StarA, child.transform.position+new Vector3(0,0,0),Quaternion.identity) as GameObject;
			star.SetActive(true);
			Debug.Log (star);

		}
			
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	void Dazzle (Color color) {
		
	}
}
