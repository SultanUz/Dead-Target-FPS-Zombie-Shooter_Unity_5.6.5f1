using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour
{
	
	public Texture2D CrosshairImg;
	public Texture2D Redcorss;
	bool fire = false;
	RaycastHit hit;

	void OnGUI ()
	{
		Vector3 fwd = transform.TransformDirection (Vector3.forward);		
		if (Physics.Raycast (transform.position, fwd, out hit)) {
			if (hit.collider.tag == "Enemy") {
				GUI.DrawTexture (new Rect ((Screen.width * 0.5f) - (Redcorss.width * 0.5f), (Screen.height * 0.5f) - (Redcorss.height * 0.5f), Redcorss.width, Redcorss.height), Redcorss);
			} else {
				GUI.DrawTexture (new Rect ((Screen.width * 0.5f) - (CrosshairImg.width * 0.5f), (Screen.height * 0.5f) - (CrosshairImg.height * 0.5f), CrosshairImg.width, CrosshairImg.height), CrosshairImg);
			}
		}
	}
}
