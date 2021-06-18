using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdShow : MonoBehaviour 
{



	// Use this for initialization
	void Start () 
	{


		
	}


	public	void ShowAppLovin()
	{
		AdsManager.Instance.ShowAppLovin();

	}

	public	void ShowInterstitial()
	{
		AdsManager.Instance.ShowInterstitial ();

	}

	void ShowNextLevel()
	{
		Application.LoadLevel (Application.loadedLevel + 1);

	}


	public void ShowBanner()
	{
		AdsManager.Instance.ShowBannerAtBottom();

	}

	public void HideBanner()
	{
		AdsManager.Instance.HideBanner();

	}


	public void Splash()
	{

		Application.LoadLevel (0);
	}

	public void LoadInterstitial()
	{
		AdsManager.Instance.LoadInterstitial();

	}


	public void ShowUnity()
	{
	
		AdsManager.Instance.ShowUnityAdd ();

	}

	public void ShowStartapp()
	{
		AdsManager.Instance.ShowStartApp ();
	}

	public void ShowHeyzapp()
	{
		AdsManager.Instance.ShowHeyzappadd();
	}


}
