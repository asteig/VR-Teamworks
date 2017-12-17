using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Flamethrower : NetworkBehaviour {
	public float damage;
	public GameObject myLight;
	public Hand myHand;
	private ParticleSystem myFire;
	// Use this for initialization
	void Start () {
		myFire = GetComponent<ParticleSystem>();
	}

	void Update() {
		if (myHand.trigger) {
			myFire.Play();
		}
		else {
			myFire.Stop();
		}
		if (myFire.isPlaying) {
			myLight.SetActive(true);
		}
		if (!myFire.isPlaying) {
			myLight.SetActive(false);
		}

	}
	void OnParticleCollision (GameObject other) {
		if(other.gameObject.tag == "Burnable") {
			other.gameObject.GetComponent<Burnable>().Burn();
		}
	}
}
