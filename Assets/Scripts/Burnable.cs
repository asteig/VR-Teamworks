using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burnable : MonoBehaviour {
	private ParticleSystem burnParticle;
	public float burnTime = 1.5f;
	// Use this for initialization
	void Start () {
		burnParticle = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Burn() {
		burnParticle.Play();
		Destroy(gameObject, burnTime);
	}
}
