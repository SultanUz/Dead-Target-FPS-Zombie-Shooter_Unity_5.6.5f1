using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//using StartApp;

public class Timer : MonoBehaviour
{
	public static bool soundbnd;
	GameObject pausewindow, successwindow, failedwindow;
	AudioSource audioS;
	public GameObject[] zombie;
	public static int zombieLength;
	RadarSystem rs;
	GameObject txtZ, txtB, BG, pistak, ak47;
	PlayerHealth ph;
	FPSInputController fps;
	public static bool escape = false;
	int counter;
	public static bool adbool = false;
	GameObject joyStick;
	GameObject pauseButton;

	void GUIHandler (bool value)
	{
		rs.enabled = value;
		txtZ.gameObject.SetActive (value);
		txtB.gameObject.SetActive (value);
		BG.gameObject.SetActive (value);
		pistak.gameObject.SetActive (value);
		ak47.gameObject.SetActive (value);
		ph.enabled = value;
		fps.enabled = value;
	}

	public void Awake ()
	{
		escape = false;
		audioS = GetComponent<AudioSource> ();
		txtZ = GameObject.Find ("Z");
		pistak = GameObject.Find ("Pistal");
		ak47 = GameObject.Find ("AK47");
		txtB = GameObject.Find ("B");
		BG = GameObject.Find ("BulletZombieGUI");
		rs = Object.FindObjectOfType<RadarSystem> ();
		ph = Object.FindObjectOfType<PlayerHealth> ();
		fps = Object.FindObjectOfType<FPSInputController> ();
		pausewindow = GameObject.Find ("Pause");
		failedwindow = GameObject.Find ("Failed");
		successwindow = GameObject.Find ("Success");
		counter = 0;
	}

	public void Resume ()
	{
		Time.timeScale = 1;
		soundbnd = false;
		audioS.PlayOneShot (audioS.clip);
		escape = false;
		GUIHandler (true);
		joyStick.SetActive (true);
	}

	public void Replay ()
	{
        
		//Application.LoadLevel (Application.loadedLevel);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		audioS.PlayOneShot (audioS.clip);
		escape = false;
		joyStick.SetActive (true);
	}

	public void Next ()
	{
		//Time.timeScale = 1;
		//Application.LoadLevel (Application.loadedLevel + 1);
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		//SceneManager.LoadScene (SceneManager.lo + 1);
		Application.LoadLevel (Application.loadedLevel + 1);
		audioS.PlayOneShot (audioS.clip);
		escape = false;
		
	}

	public void Levels ()
	{
		audioS.PlayOneShot (audioS.clip);
		Application.LoadLevel (2);
		escape = false;
	}

	public void Home ()
	{
      
		audioS.PlayOneShot (audioS.clip);
		Application.LoadLevel (1);
		escape = false;
	}

	void  Start ()
	{
		Time.timeScale = 1;
		adbool = false;
		soundbnd = false;
		failedwindow.gameObject.SetActive (false);
		successwindow.gameObject.SetActive (false);
		pausewindow.gameObject.SetActive (false);
		counter = 0;
		//escape = true;
		GUIHandler (true);
		joyStick = GameObject.FindGameObjectWithTag ("Joystick");
		//joyStick.SetActive (false);
		pauseButton = GameObject.FindGameObjectWithTag ("pauseButton");
	}

	public void pausedd ()
	{
		
		Time.timeScale = 0;
		escape = true;
		joyStick.SetActive (false);
		pausewindow.SetActive (true);
		#if !UNITY_EDITOR
		AdsManager.Instance.ShowUnityAdmobHeyzap();
		#endif

     
	}

	void  Update ()
	{
		if (joyStick.activeSelf) {
			pauseButton.SetActive (true);
		} else {
			pauseButton.SetActive (false);
		}
//		if (Application.loadedLevel > 2) {
//			escape = false;
//			Resume ();
//		}
//				if(Input.GetMouseButtonDown(0) && startpanel.activeSelf )
//				{
//
//						escape=false;
//						startpanel.SetActive(false);
//						Resume();
//				}

		zombieLength = zombie.Length;
		if (Input.GetKeyDown (KeyCode.Escape)) {
			escape = true;
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
		zombie = GameObject.FindGameObjectsWithTag ("Enemy");
		//sultan if (BulletsCounter.bullet_G < 0 && BulletsCounter.bullet_P < 0 && zombie.Length > 0 || PlayerHealth.health <= 0) {
		if (BulletsCounter.bullet_P <= 0 && BulletsCounter.bullet_G <= 0 && zombie.Length > 0 || PlayerHealth.health <= 0) {
			
			Time.timeScale = 0;
			if (adbool == false) {
				Debug.Log ("Heyzap Ads");
				//sultan  ManagerAds.Instance.AdmobShowInterstitialAd();
				#if !UNITY_EDITOR
				AdsManager.Instance.ShowOnlyHeyzappadd();
				#endif
				adbool = true;
			}
			if (counter < 1) {
				counter++;
				soundbnd = true;
			}
			GUIHandler (false);
			failedwindow.gameObject.SetActive (true);
			joyStick.SetActive (false);

		} else
			failedwindow.gameObject.SetActive (false);
		if (BulletsCounter.bullet_G >= 0 && BulletsCounter.bullet_P >= 0 && zombie.Length == 0) {
			Time.timeScale = 0;
			if (adbool == false) {
				//sultan ManagerAds.Instance.AdmobShowInterstitialAd();
				#if !UNITY_EDITOR
				AdsManager.Instance.ShowUnityAdmobHeyzap();
				#endif
				adbool = true;
			}
			if (counter < 1) {
				counter++;
			}
			GUIHandler (false);
           
			PlayerPrefs.SetInt (Application.loadedLevelName, 1);
			joyStick.SetActive (false);
			successwindow.gameObject.SetActive (true);
			soundbnd = true;
                       
		} else
			successwindow.gameObject.SetActive (false);
		if (escape) {
			Time.timeScale = 0;
			GUIHandler (false);
			pausewindow.gameObject.SetActive (true);
			soundbnd = true;
			joyStick.SetActive (false);
		} else
			pausewindow.gameObject.SetActive (false);
	}

	IEnumerator firstAdmobCalling ()
	{
		for (int i = 0; i <= 10; i++) {
			yield return new WaitForSeconds (0);
		}
	
	}

}
