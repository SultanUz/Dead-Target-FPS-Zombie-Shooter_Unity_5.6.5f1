using UnityEngine;
using System.Collections;
using admob;
using UnityEngine.Advertisements;
using StartApp;
using Heyzap;


public class AdsManager : MonoBehaviour 
{
	private static AdsManager _instance;
	string zoneId="rewardedVideoZone";
	public static AdsManager Instance
	{

		get
		{

			if(_instance==null)
			{
				#if !UNITY_EDITOR
				_instance= GameObject.FindObjectOfType<AdsManager>();
				DontDestroyOnLoad(_instance.gameObject);
				#endif
			}
			return _instance;

		}



	}


	void Awake()
	{

		#if !UNITY_EDITOR

		if(_instance == null)
		{

		_instance = this;
		DontDestroyOnLoad(this);
		}
		else
		{

		if(this != _instance)
		Destroy(this.gameObject);
		}

		#endif



	}
	// Use this for initialization
	void Start () 
	{

		#if !UNITY_EDITOR
		Admob.Instance().interstitialEventHandler += onInterstitialEvent;
		AppLovin.SetUnityAdListener(gameObject.name);

		//      Admob.Instance().rewardedVideoEventHandler += onRewardedVideoEvent;
		//		Admob.Instance().bannerEventHandler += onBannerEvent;
		#endif

	}

	public void ShowUnityAdmob()
	{
		#if !UNITY_EDITOR
		if (Advertisement.IsReady()) 
		{
		ShowUnityAdd ();
		return;
		}
		else 
		{
		Admob ad = Admob.Instance();
		if (ad.isInterstitialReady())
		{
		ad.showInterstitial();
		return;
		}
		}

		#endif
	}

	public void ShowUnityRewardedvideo()
	{
		#if !UNITY_EDITOR
		if (Advertisement.IsReady ()) 
		{
			ShowOptions options = new ShowOptions ();
			options.resultCallback = HandleShowResult;
			Advertisement.Show (zoneId, options);
		}
		
		else 
		{
			Debug.Log("ads not avaivable");
			///ShowInterstitial ();
		}
		#endif
	}
	private void HandleShowResult (ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			
			//	Debug.Log ("Video completed. User rewarded " + " credits.");
			break;
		case ShowResult.Skipped:
			//	Debug.LogWarning ("Video was skipped.");
			break;
		case ShowResult.Failed:
			//	Debug.LogError ("Video failed to show.");
			break;
		}
	}


	public void InitUnityadd(string _unityid)
	{
		#if !UNITY_EDITOR

		if(!Advertisement.isInitialized)
		Advertisement.Initialize (_unityid);
		#endif
	}

	public void ShowHeyzappUnityAndAdmob()
	{
		#if !UNITY_EDITOR
		if (HZInterstitialAd.IsAvailable ()) {
		ShowHeyzappadd ();
		} else {

		ShowUnityAddAndAdmob();
		}
		#endif

	}

	public void InitHeyzappadd(string _heyzappid)
	{
		#if !UNITY_EDITOR

		HeyzapAds.Start (_heyzappid, HeyzapAds.FLAG_NO_OPTIONS);
		HZInterstitialAd.Fetch();
		#endif

	}


	public void InitAppLovin(string sdk_key)
	{
		#if !UNITY_EDITOR
		AppLovin.SetSdkKey(sdk_key); 
		AppLovin.InitializeSdk();
		#endif

	}


	public void LoadApLovinRewardedVideo()
	{
		#if !UNITY_EDITOR
		AppLovin.LoadRewardedInterstitial();
		#endif

	}

	public void ShowApLovinRewardedVideo()
	{

		#if !UNITY_EDITOR
		if(AppLovin.IsIncentInterstitialReady()){
		AppLovin.ShowRewardedInterstitial ();

		}
		#endif


	}

	public void LoadAppLovin()
	{
		#if !UNITY_EDITOR
		AppLovin.PreloadInterstitial();
		#endif
	}

	public void ShowAppLovin()
	{



		#if !UNITY_EDITOR
		if(AppLovin.HasPreloadedInterstitial())
		{
		AppLovin.ShowInterstitial();
		AppLovin.PreloadInterstitial();
		}
		#endif
	}



	public void ShowHeyzappadd()
	{
		#if !UNITY_EDITOR
		HZInterstitialAd.Show ();
		#endif
	}
	public void ShowOnlyHeyzappadd()
	{
		Debug.Log ("Heyzap Ads");
		#if !UNITY_EDITOR
		if (HZInterstitialAd.IsAvailable ()) 
		{
		ShowHeyzappadd ();
		Time.timeScale = 0;
		} 
		#endif


	}
	public void ShowUnityAdd()
	{
		#if !UNITY_EDITOR
		if (Advertisement.IsReady())
		Advertisement.Show ();
		#endif
	}

	public void ShowUnityAddAndHeyzapp()
	{
		#if !UNITY_EDITOR
		if (Advertisement.IsReady ())
		Advertisement.Show ();
		else 
		{
		ShowHeyzappadd ();
		}

		#endif
	}

	public void ShowUnityAddAndAdmob()
	{
		#if !UNITY_EDITOR
		if (Advertisement.IsReady ()) 
		{
		ShowOptions options = new ShowOptions ();
		options.resultCallback = HandleShowResult;
		Advertisement.Show (zoneId, options);
		}

		else 
		{

		ShowInterstitial ();
		}
		#endif
	}



	public void InitStartApp()
	{
		#if !UNITY_EDITOR
		StartAppWrapper.init ();
		StartAppWrapper.loadAd ();
		#endif

	}


	public void ShowStartApp()
	{
		#if !UNITY_EDITOR
		StartAppWrapper.showAd();
		StartAppWrapper.loadAd();
		#endif

	}

	public void InitAdmob(string _BannerId,string _InterstitialId)
	{
		#if !UNITY_EDITOR
		Admob ad = Admob.Instance();
		ad.initAdmob(_BannerId,_InterstitialId);
		ad.loadInterstitial ();
		//	ad.setTesting(true);
		#endif

	}

	public void LoadInterstitial()
	{
		#if !UNITY_EDITOR
		Admob ad = Admob.Instance();
		ad.loadInterstitial ();
		#endif

	}

	public void ShowInterstitial()
	{
		#if !UNITY_EDITOR
		Admob ad = Admob.Instance();
		if (ad.isInterstitialReady())
		{
		ad.showInterstitial();
		}
		#endif
	}



	public void ShowSmartBannerAtBottom()
	{
		#if !UNITY_EDITOR
		Admob.Instance().showBannerRelative(AdSize.SmartBanner, AdPosition.BOTTOM_CENTER, 0);
		#endif

	}


	public void ShowSmartBannerAtTop()
	{
		#if !UNITY_EDITOR
		Admob.Instance().showBannerRelative(AdSize.SmartBanner, AdPosition.TOP_CENTER, 0);
		#endif

	}


	public void ShowBannerAtBottom()
	{
		#if !UNITY_EDITOR
		Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 0);
		#endif

	}

	public void ShowBannerAtTop()
	{
		#if !UNITY_EDITOR
		Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.TOP_CENTER, 0);
		#endif

	}


	public void HideBanner()
	{
		#if !UNITY_EDITOR
		Admob.Instance().removeBanner();
		#endif
	}


	public void ShowUnityAdmobHeyzap()
	{
		#if !UNITY_EDITOR
		if (Advertisement.IsReady ()) 
		{
		ShowUnityAdd ();
		Time.timeScale = 0;
		return;
		} 
		else 
		{
		Admob ad = Admob.Instance ();
		if (ad.isInterstitialReady ()) 
		{
		ad.showInterstitial ();
		Time.timeScale = 0;
		return;
		} 
		else 
		{

		if (HZInterstitialAd.IsAvailable ()) 
		{
		ShowHeyzappadd ();
		Time.timeScale = 0;
		} 
		return;
		}
		}

		#endif
	}



	void onInterstitialEvent(string eventName, string msg)
	{

		Admob ad = Admob.Instance();
		//     Debug.Log("handler onAdmobEvent---" + eventName + "   " + msg);

		if (eventName == AdmobEvent.onAdClosed)
		{
			if (Application.loadedLevel == 0)
				Application.LoadLevel (Application.loadedLevel + 1);

			ad.loadInterstitial();
		}



	}


	void onAppLovinEventReceived(string ev)
	{
		// The format would be "REWARDAPPROVEDINFO|AMOUNT|CURRENCY"
		if (ev.Contains("REWARDAPPROVEDINFO")) 
		{
			// For this example, assume the event is "REWARDAPPROVEDINFO|10|Coins"
			char[] delimiter = { '|' };

			// Split the string based on the delimeter
			string[] split = ev.Split(delimiter);

			// Pull out the currency amount
			double amount = double.Parse(split[1]);

			// Pull out the currency name
			string currencyName = split[2];

			// Do something with the values from above.  For example, grant the coins to the user.

			//			updateBalance(amount, currencyName);
		}

		else if(ev.Contains("LOADEDREWARDED")) 
		{


		}

		else if(ev.Contains("LOADREWARDEDFAILED")) 
		{



			// A rewarded video failed to load.
		}
		else if(ev.Contains("HIDDENREWARDED")) 
		{
			LoadApLovinRewardedVideo();
		}
	}

	void onBannerEvent(string eventName, string msg)
	{
		//  Debug.Log("handler onAdmobBannerEvent---" + eventName + "   " + msg);
	}
	void onRewardedVideoEvent(string eventName, string msg)
	{
		//  Debug.Log("handler onRewardedVideoEvent---" + eventName + "   " + msg);
	}
}
