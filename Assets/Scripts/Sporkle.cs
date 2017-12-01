using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sporkle : RecieveInvoke {
	public int whichSporkle;
	public bool linked = false;
	public Spellbook spellbook;
	public GameObject lineRenderer;

	public void AddToLink() {
	//	if (!linked) {
			linked = true;
			spellbook.spellLinks += ("" + whichSporkle);
			if (MCP.currentLineDraw != null)
				MCP.currentLineDraw.pos2 = transform;
			LineRender lastSpawn = Instantiate(lineRenderer, transform.position, transform.rotation).GetComponent<LineRender>();
			MCP.currentLineDraw = lastSpawn;
			lastSpawn.pos1 = transform;
			lastSpawn.pos2 = MCP.mcp.RightHandFinger.transform;
			MCP.mcp.stuffToDelete.Add(lastSpawn.gameObject);
		}
	//}
}
