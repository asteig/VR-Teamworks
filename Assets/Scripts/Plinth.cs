﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plinth : MonoBehaviour {
	public Spellbook spell;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "PlayerHand") {
			spell.held = true;
		}
	}
}
