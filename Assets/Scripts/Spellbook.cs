using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellbook : RecieveInvoke {
	private Animator myAnim;
	public Transform anchor;
	public float minAnchorDistance;
	public int currentPage = 0;
	public spell[] spells;
	public TextMesh spellName;
	public SpriteRenderer LeftSprite;
	public SpriteRenderer rightSprite;
	public string spellLinks;
	public TextMesh debugText;

	void Start () {
		myAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		debugText.text = spellLinks;
		if (Vector3.Distance(transform.position, anchor.position) > minAnchorDistance)
			SmoothMoveToAnchor();

	}

	//move to hover above the hand in a magic looking way
	void SmoothMoveToAnchor() {
		transform.position = Vector3.MoveTowards(transform.position, anchor.position, (Vector3.Distance(transform.position,anchor.position) * 0.1f) );
		transform.rotation = anchor.rotation;
	}

	void TurnPageLeft() {
		print("turn page left");
		myAnim.Play("TurnPageLeft",0,0);
		currentPage -= 1;
		UpdatePage();
	}
	void TurnPageRight() {
		print("turn page right");
		myAnim.Play("TurnPageRight",0,0);
		currentPage += 1;
		UpdatePage();
	}

	void UpdatePage() {
		currentPage = Mathf.Clamp(currentPage, 0, spells.Length -1);
		spellName.text = spells[currentPage].name;
		LeftSprite.sprite = spells[currentPage].leftPageTex;
		rightSprite.sprite = spells[currentPage].rightPageTex;
	}
}

[System.Serializable]
public class spell {
	public string name;
	public Sprite leftPageTex;
	public Sprite rightPageTex;
}
