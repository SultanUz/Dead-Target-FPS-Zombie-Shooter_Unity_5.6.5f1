using UnityEngine;
using System.Collections;

public class Slides : MonoBehaviour {
	public static bool showloading;

	// Use this for initialization
	void Start () 
	{
		showloading = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void loadLevel (int LevelToLoad)
	{
		Application.LoadLevel ("Round " + LevelToLoad);
		showloading = true;
	}
}
