using UnityEngine;
using System.Collections;

public class ExitMenu4mLevelsManager : MonoBehaviour {
	bool back;
	public GUISkin skin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			back = !back;
		}
		if(back==true)
		{
			Application.LoadLevel("StartScene");
			back=false;
		}
	}
	void OnGUI () {
				if (Slides.showloading) {
						GUI.Box (new Rect (Screen.width * 0.3f, Screen.height * 0.7f, Screen.width * 0.4f, Screen.height * 0.1f), "", skin.customStyles [8]);
				}
		}
}
