using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelLocked : MonoBehaviour
{
	AudioSource audioS;
	Button Level2;
	Button Level3;
	Button Level4;
	Button Level5;
	Button Level6;
	Button Level7;
	Button Level8;
	Button Level9;
	Button Level10;
	Button Level11;
	Button Level12;
	Button Level13;
	Button Level14;
	Button Level15;
	Button Level16;
	Button Level17;
	Button Level18;
	int counter;

	private Timer timerClass;

	public void LoadLevel (int level)
	{
		//Timer.escape = false;
		///		Admob.intertialshow = true;  //ads
		audioS.PlayOneShot (audioS.clip);
		print ("start ap");
		//sultan GameObject.Find("alladsCallings").gameObject.BroadcastMessage("startappcallings",SendMessageOptions.DontRequireReceiver);
		StartCoroutine (Load (level));

	}

	IEnumerator Load (int level)
	{
//		#if UNITY_ANDROID
//		Handheld.SetActivityIndicatorStyle (AndroidActivityIndicatorStyle.Large);
//		#endif
		Handheld.StartActivityIndicator ();
		for (int i = 0; i <= 180; i++) {
			yield return new WaitForSeconds (0);
		}
//
//		yield return new WaitForSeconds (.5F);
		Application.LoadLevel ("Round " + level);
		print (level);
	}


	void Start ()
	{

		audioS = GetComponent<AudioSource> ();
		counter = 0;
		Time.timeScale = 1;
		Level2 = GameObject.Find ("2").GetComponent<Button> ();
		Level3 = GameObject.Find ("3").GetComponent<Button> ();
		Level4 = GameObject.Find ("4").GetComponent<Button> ();
		Level5 = GameObject.Find ("5").GetComponent<Button> ();
		Level6 = GameObject.Find ("6").GetComponent<Button> ();
		Level7 = GameObject.Find ("7").GetComponent<Button> ();
		Level8 = GameObject.Find ("8").GetComponent<Button> ();
		Level9 = GameObject.Find ("9").GetComponent<Button> ();
		Level10 = GameObject.Find ("10").GetComponent<Button> ();
		Level11 = GameObject.Find ("11").GetComponent<Button> ();
		Level12 = GameObject.Find ("12").GetComponent<Button> ();
		Level13 = GameObject.Find ("13").GetComponent<Button> ();
		Level14 = GameObject.Find ("14").GetComponent<Button> ();
		Level15 = GameObject.Find ("15").GetComponent<Button> ();
		Level16 = GameObject.Find ("16").GetComponent<Button> ();
		Level17 = GameObject.Find ("17").GetComponent<Button> ();
		Level18 = GameObject.Find ("18").GetComponent<Button> ();

	}

	void Update ()
	{
		if (PlayerPrefs.GetInt ("sound") == 0) {
			AudioListener.volume = 1;
		} else if (PlayerPrefs.GetInt ("sound") == 1) {
			AudioListener.volume = 0;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel (Application.loadedLevel - 1);
		}
		if (PlayerPrefs.GetInt ("Round 1") == 1) {
			Level2.interactable = true;
			Level2.GetComponent<Image> ().color = new Color (255, 255, 255, 255);
		}
		if (PlayerPrefs.GetInt ("Round 2") == 1) {
			Level3.interactable = true;
			Level3.GetComponent<Image> ().color = new Color (255, 255, 255, 255);
		}
		if (PlayerPrefs.GetInt ("Round 3") == 1) {
			Level4.interactable = true;
			Level4.GetComponent<Image> ().color = new Color (255, 255, 255, 255);
		}
		if (PlayerPrefs.GetInt ("Round 4") == 1) {
			Level5.interactable = true;
			Level5.GetComponent<Image> ().color = new Color (255, 255, 255, 255);
		}
		if (PlayerPrefs.GetInt ("Round 5") == 1) {
			Level6.interactable = true;
			Level6.GetComponent<Image> ().color = new Color (255, 255, 255, 255);
		}
		if (PlayerPrefs.GetInt ("Round 6") == 1) {
			Level7.interactable = true;
			Level7.GetComponent<Image> ().color = new Color (255, 255, 255, 255);
		}
		if (PlayerPrefs.GetInt ("Round 7") == 1) {
			Level8.interactable = true;
			Level8.GetComponent<Image> ().color = new Color (255, 255, 255, 255);
		}
		if (PlayerPrefs.GetInt ("Round 8") == 1) {
			Level9.interactable = true;
			Level9.GetComponent<Image> ().color = new Color (255, 255, 255, 255);
		}
		if (PlayerPrefs.GetInt ("Round 9") == 1) {
			Level10.interactable = true;
			Level10.GetComponent<Image> ().color = new Color (255, 255, 255, 255);
		}
		if (PlayerPrefs.GetInt ("Round 10") == 1) {
			Level11.interactable = true;
			Level11.GetComponent<Image> ().color = new Color (255, 255, 255, 255);
		}
		if (PlayerPrefs.GetInt ("Round 11") == 1) {
			Level12.interactable = true;
			Level12.GetComponent<Image> ().color = new Color (255, 255, 255, 255);
		}
		if (PlayerPrefs.GetInt ("Round 12") == 1) {
			Level13.interactable = true;
			Level2.GetComponent<Image> ().color = new Color (255, 255, 255, 255);
		}
		if (PlayerPrefs.GetInt ("Round 13") == 1) {
			Level14.interactable = true;
			Level14.GetComponent<Image> ().color = new Color (255, 255, 255, 255);
		}
		if (PlayerPrefs.GetInt ("Round 14") == 1) {
			Level15.interactable = true;
			Level15.GetComponent<Image> ().color = new Color (255, 255, 255, 255);
		}
		if (PlayerPrefs.GetInt ("Round 15") == 1) {
			Level16.interactable = true;
			Level16.GetComponent<Image> ().color = new Color (255, 255, 255, 255);
		}
		if (PlayerPrefs.GetInt ("Round 16") == 1) {
			Level17.interactable = true;
			Level17.GetComponent<Image> ().color = new Color (255, 255, 255, 255);
		}
		if (PlayerPrefs.GetInt ("Round 17") == 1) {
			Level18.interactable = true;
			Level18.GetComponent<Image> ().color = new Color (255, 255, 255, 255);
		}
	}
}