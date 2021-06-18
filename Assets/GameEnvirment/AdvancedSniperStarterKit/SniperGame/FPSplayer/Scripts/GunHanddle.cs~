using UnityEngine;
using System.Collections;

public class GunHanddle : MonoBehaviour
{
	public Camera FPScamera;
	public Gun[] Guns;
	public int GunIndex;
	bool v= false;
	[HideInInspector]
	public Gun CurrentGun;
	public GUISkin mission;
	void Start ()
	{
		if (Guns.Length < 1) {
			Guns = this.gameObject.GetComponentsInChildren<Gun> ();
		}
		for (int i=0; i<Guns.Length; i++) {
			if (FPScamera)
			Guns[i].NormalCamera = FPScamera;	
			Guns[i].fovTemp = FPScamera.fieldOfView;
		}
		SwitchGun (0);
	}
	void Update()
	{

	}
	public void AK47()
	{
		BulletsCounter.pistal=false;
					BulletsCounter.gun=true;
					SwitchGun(0);
	}
	public void Pistal()
	{
		BulletsCounter.gun=false;
					BulletsCounter.pistal=true;
					SwitchGun(1);
	}
//	void OnGUI()
//	{
//		if(GUI.Button (new Rect (Screen.width * .80f, Screen.height * .17f, Screen.width * 0.17f, Screen.height * .15f),"",mission.customStyles[9]))
//		{
//			BulletsCounter.pistal=false;
//			BulletsCounter.gun=true;
//			SwitchGun(0);
//		}
//		if(GUI.Button (new Rect (Screen.width * .85f, Screen.height * .35f, Screen.width * 0.12f, Screen.height * .1f),"",mission.customStyles[10]))
//		{
//			BulletsCounter.gun=false;
//			BulletsCounter.pistal=true;
//			SwitchGun(1);
//		}
//	}
	void Hide (GameObject gameObject, bool show)
	{
		/*Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
    	foreach (Renderer r in renderers) {
        	r.enabled = show;
    	}*/
	}
	public void Zoom ()
	{
		if (CurrentGun)
			CurrentGun.Zoom ();
	}
	
	public void Reload ()
	{
		if (CurrentGun)
			CurrentGun.Reload ();
	}
	
	public void ZoomAdjust (int delta)
	{
		if (CurrentGun)
			CurrentGun.ZoomDelta (delta);
	}
	
	public void SwitchGun (int index)
	{
		if (FPScamera.enabled) {
			for (int i=0; i<Guns.Length; i++) {
				Hide (Guns [i].gameObject, false);
				Guns [i].SetActive (false);
			}
			if (Guns.Length > 0 && index < Guns.Length && index >= 0) {
				GunIndex = index;
				CurrentGun = Guns [GunIndex].gameObject.GetComponent<Gun> ();
				Hide (Guns [GunIndex].gameObject, true);
				Guns [GunIndex].SetActive (true);
			}
		}
	}

	public void SwitchGun ()
	{
		int index = GunIndex + 1;
		if (index >= Guns.Length)
			index = 0;
		
		SwitchGun (index);
	}
	
	public void Shoot ()
	{
		if (CurrentGun)
			CurrentGun.Shoot ();
	}
	
	public void HoldBreath (int noiseMult)
	{
		if (CurrentGun)
			CurrentGun.FPSmotor.Holdbreath (noiseMult);
	}
}
