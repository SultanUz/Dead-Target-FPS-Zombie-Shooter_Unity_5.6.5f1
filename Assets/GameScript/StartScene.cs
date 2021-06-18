using UnityEngine;
using System.Collections;
using System.IO;


public class StartScene : MonoBehaviour
{
	//public GameObject admobInt;
	bool escape;
	public GameObject exit;
	public GameObject homeMenu;
	AudioSource audioS;
	public GameObject loadingpage;
	public GameObject soundOnBtn;
	public GameObject soundOffBtn;

	void Awake ()
	{
		//exit = GameObject.Find ("Exit");
		loadingpage.SetActive (false);
	}

   
       
	void Start ()
	{
		//PlayerPrefs.DeleteAll ();
		PlayerPrefs.GetInt ("sound", 0);
		Time.timeScale = 1;


	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			escape = !escape;
		}
		if (escape) {
			exit.gameObject.SetActive (true);
			homeMenu.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("sound") == 0) {
			AudioListener.volume = 1;
			soundOnBtn.SetActive (true);
			soundOffBtn.SetActive (false);
		} else if (PlayerPrefs.GetInt ("sound") == 1) {
			AudioListener.volume = 0;
			soundOnBtn.SetActive (false);
			soundOffBtn.SetActive (true);
		}
	}

	public void Play ()
	{


		StartCoroutine ("loadingscene");
		StartCoroutine ("levelscene");
		//sultan ManagerAds.Instance.AdmobShowInterstitialAd();
		#if !UNITY_EDITOR
		AdsManager.Instance.ShowUnityAdmobHeyzap();
		#endif
       
		

	}

	public void Rate ()
	{
		//audioS.PlayOneShot (audioS.clip);
		Application.OpenURL ("https://play.google.com/store/apps/details?id=com.ssggames.dead.target.fps.zombie.shooter");
	
	}

	public void More ()
	{
		//audioS.PlayOneShot (audioS.clip);
		Application.OpenURL ("https://play.google.com/store/apps/developer?id=SUZ+Games+Studio");
	}

	public void Setting ()
	{
		//audioS.PlayOneShot (audioS.clip);
	}

	public void Yes ()
	{
		//audioS.PlayOneShot (audioS.clip);
		Application.Quit ();
	}


	public void No ()
	{
		escape = false;
		//audioS.PlayOneShot (audioS.clip);
		exit.SetActive (false);
		homeMenu.SetActive (true);


	}




	IEnumerator loadingscene ()
	{
		for (int i = 0; i <= 2; i++) {
			yield return new WaitForSeconds (0);
		}

	}

												
	
	
	IEnumerator levelscene ()
	{
		for (int i = 0; i <= 60; i++) {
			yield return new WaitForSeconds (0);
		}
		Application.LoadLevel (2);
	}

	public void CrossMarketing (string url)
	{
		Application.OpenURL (url);
	}

	public void soundOn ()
	{
		PlayerPrefs.SetInt ("sound", 1);
	}

	public void soundOff ()
	{
		PlayerPrefs.SetInt ("sound", 0);
	}

}
