//using UnityEngine;
//using System.Collections;

//public class alladscallings : MonoBehaviour {
//    public static bool isadsOnetime = true;
//    // Use this for initialization
//    void Start () {
//        #if UNITY_IPHONE
//        StartAppWrapperiOS.unityOrientation(StartAppWrapperiOS.STAUnityOrientation.STAAutoRotation);
//        StartAppWrapperiOS.loadAd();
//        #endif
//    }
//    // Update is called once per frame
//    void Update () {
//        //	if(InApp.instance.isAdsRemovePurchased() && isadsOnetime){
//        //
//        //	AdsManager.SharedObject().HideAdmobInterstitial();
//        //	isadsOnetime =false;
//        //	}
//    }
//    public void admobcallings(){
//        StartCoroutine("admobcallingss");
//    }
//    public void unitycallings(){
//        StartCoroutine("unitycallingss");
//    }
//    public void startappcallings(){
//        StartCoroutine("startappcallingss");
//    }
//    public void HideAdmobBanners(){
//        print ("hiding banner");
////		AdsManager.SharedObject ().HideAdmobBanner ();
//    }
//    //        GameObject.Find("alladsCallings").gameObject.BroadcastMessage("admobcallings",SendMessageOptions.DontRequireReceiver);
//    //        GameObject.Find("alladsCallings").gameObject.BroadcastMessage("unitycallings",SendMessageOptions.DontRequireReceiver);
//    //        GameObject.Find("alladsCallings").gameObject.BroadcastMessage("startappcallings",SendMessageOptions.DontRequireReceiver);
//    //        GameObject.Find("alladsCallings").gameObject.BroadcastMessage("HideAdmobBanners",SendMessageOptions.DontRequireReceiver);
//    IEnumerator admobcallingss(){
//        for(int i=0;i<=10;i++){
//            yield return new WaitForSeconds(0);
//        }
	
////		if(!InApp.instance.isAdsRemovePurchased()) {
////			print ("admobbbbbbbbbbbbbbb");
////			AdsManager.SharedObject().ShowAdmobInterstitial();
////			AdsManager.SharedObject().ShowAdmobBanner();
////		}
//    }
//    IEnumerator unitycallingss(){
//        for(int i=0;i<=10;i++){
//            yield return new WaitForSeconds(0);
//        }

//        //if(!InApp.instance.isAdsRemovePurchased()) {
//            print ("unityyyyyyyyyyyyyyyyy");
////#if UNITY_IPHONE

//            //AdsManager.SharedObject ().ShowUnityAd ();
//            //AdsManager.SharedObject().ShowAdmobBanner();
//        //	#endif
//        //}
//    }
//    IEnumerator startappcallingss(){
//        for(int i=0;i<=10;i++){
//            yield return new WaitForSeconds(0);
//        }

//        //if (!InApp.instance.isAdsRemovePurchased ()) {
//        //	print ("starappppppppppppppppp");
//        //	#if UNITY_IPHONE
//            StartAppWrapperiOS.showAd ();
//            //AdsManager.SharedObject().ShowAdmobBanner();
//        //	#endif
//        //}
//    }
//}