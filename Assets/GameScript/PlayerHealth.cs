using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public GUISkin inGame;
	private float SH = Screen.height;
	private float SW = Screen.width;
	public static float health = 100;
	// static lets it be accessed by other scripts (eg: playerHealth.health = xxxxx)
	
	void  Update ()
	{
		if (PlayerPrefs.GetInt ("sound") == 0) {
			AudioListener.volume = 1;
		} else if (PlayerPrefs.GetInt ("sound") == 1) {
			AudioListener.volume = 0;
		}
	}


	void  Start ()
	{
		health = Screen.width * .175f;
	}

	void  OnGUI ()
	{
		//GUI.Box (new Rect (1f, SW * 0.19f, SW * 0.175f, SH * 0.04f), "", inGame.customStyles [0]);
		//GUI.Box (new Rect (1f, SW * 0.19f, health, SH * 0.04f), "", inGame.customStyles [1]);
		GUI.Box (new Rect (250f, SW * 0.05f, SW * 0.175f, SH * 0.04f), "", inGame.customStyles [0]);
		GUI.Box (new Rect (250f, SW * 0.05f, health, SH * 0.04f), "", inGame.customStyles [1]);
	}
}
