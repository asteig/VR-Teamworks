using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCP : MonoBehaviour {
	public static MCP mcp;
	public static LineRender currentLineDraw;
	public Transform RightHandFinger;
	public List<GameObject> stuffToDelete;
	public Sporkle[] sporkles;
	public Spellbook spellbook;

	//spell objects
	public GameObject flamethrower;
	//spell objects
	void Awake () {
		mcp = this;
	}
	
	void Update () {
	}
	public void EndSpell() {
		flamethrower.SetActive(false);

	}
	public void CastSpell() {
		foreach(Sporkle sporkle in sporkles) {
			sporkle.linked = false;
		}

		for(int i = 0; i < stuffToDelete.Count; i++) {
			Destroy(stuffToDelete[i]);
		}

		stuffToDelete.TrimExcess();

		SpellCasted(spellbook.spellLinks);

		spellbook.spellLinks = "";
	}

	void SpellCasted(string which) {
		if(which == "642") {
			//telekenesis
		}
		if (which == "6325") {
			flamethrower.SetActive(true);
		}
	}
}
