using UnityEngine;
using System.Collections;

public class CursorLock : MonoBehaviour {
	public static bool isPaused = false;
	
	void Start () {
		LockCursor();
	}
	//Call these for anything that needs to change the cursor lock.
	public static void LockCursor(){
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	public static void UnLockCursor(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		
	}
	
	public static void PauseGame(){
		Time.timeScale = 0;
		isPaused = true;
	}
	public static void UnPauseGame(){
		Time.timeScale = 1;
		isPaused = false;
	}

	void Update ()
	{
		
	}
}