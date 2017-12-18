using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekinesisFluff : MonoBehaviour {
	private Vector3 pos1;
	private Vector3 pos2;
	public Telekinesis tele;
	public float scaleMod = 1;
	public GameObject[] FX;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (tele.gameObject.activeInHierarchy) {
			FX[0].SetActive(true);
			FX[1].SetActive(true);
			pos1 = tele.transform.position;
			pos2 = tele.targetPoint;
			transform.position = Vector3.Lerp(pos1, pos2, 0.5f);
			Vector3 scaleAdj = transform.localScale;
			scaleAdj.z = (Vector3.Distance(pos1, pos2) * scaleMod);
			transform.localScale = scaleAdj;
			transform.LookAt(pos2);
		}
		else {
			FX[0].SetActive(false);
			FX[1].SetActive(false);
		}
	}
}
