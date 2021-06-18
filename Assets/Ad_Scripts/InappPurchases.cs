using UnityEngine;
using System.Collections;
using OnePF;
using System.Collections.Generic;
using UnityEngine.UI;

public class InappPurchases : MonoBehaviour {

	// Use this for initialization
	const string SKU = "sku";
	private Text dollars;
	private Text con;
	private string Pid;
	public string PublicKey;
	Inventory _inventory = null;

	private void OnEnable()
	{
		// Listen to all events for illustration purposes
		OpenIABEventManager.billingSupportedEvent += billingSupportedEvent;
		OpenIABEventManager.billingNotSupportedEvent += billingNotSupportedEvent;
		OpenIABEventManager.queryInventorySucceededEvent += queryInventorySucceededEvent;
		OpenIABEventManager.queryInventoryFailedEvent += queryInventoryFailedEvent;
		OpenIABEventManager.purchaseSucceededEvent += purchaseSucceededEvent;
		OpenIABEventManager.purchaseFailedEvent += purchaseFailedEvent;
		OpenIABEventManager.consumePurchaseSucceededEvent += consumePurchaseSucceededEvent;
		OpenIABEventManager.consumePurchaseFailedEvent += consumePurchaseFailedEvent;
	}
	private void OnDisable()
	{
		// Remove all event handlers
		OpenIABEventManager.billingSupportedEvent -= billingSupportedEvent;
		OpenIABEventManager.billingNotSupportedEvent -= billingNotSupportedEvent;
		OpenIABEventManager.queryInventorySucceededEvent -= queryInventorySucceededEvent;
		OpenIABEventManager.queryInventoryFailedEvent -= queryInventoryFailedEvent;
		OpenIABEventManager.purchaseSucceededEvent -= purchaseSucceededEvent;
		OpenIABEventManager.purchaseFailedEvent -= purchaseFailedEvent;
		OpenIABEventManager.consumePurchaseSucceededEvent -= consumePurchaseSucceededEvent;
		OpenIABEventManager.consumePurchaseFailedEvent -= consumePurchaseFailedEvent;
	}


	void Start () 
	{
		OpenIAB.mapSku(SKU, OpenIAB_Android.STORE_GOOGLE, "sku");

	//	PublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAjtUDbP5XPzQI72I2Jq4qsWL+0uDVIE2qu0CWdkkZnK2xv2sHIRvVtGVWZv3hwXegovZdSyp2kyJIR6sXGTvbi6rLf8K1oXABa93grPCQt/SXWnCrJR3fe6irE4YC/nqS1QvvmSqIjfhLzJiqbVTEWixcRVqr/q/g/kHKLzbgiumMx6QnpRuM/pRaD1mTFhlm0JCCuTAGzOWV4KXNq7PqTUaXSIEf+f+mdE9Ow45SN2HXV3nd53/cP+0xghACIXJAKCHvUQuIH5UzMdB+9MO+mnkirIORlR0+XF8GGhyYLs1a67kP/bHz44jLIt560QlS6k6lk8qCoHoemdgyXOuMmQIDAQAB";

		var options = new Options();

		options.checkInventoryTimeoutMs = Options.INVENTORY_CHECK_TIMEOUT_MS * 2;
		options.discoveryTimeoutMs = Options.DISCOVER_TIMEOUT_MS * 2;
		options.checkInventory = false;
		options.verifyMode = OptionsVerifyMode.VERIFY_SKIP;
		options.prefferedStoreNames = new string[] { OpenIAB_Android.STORE_GOOGLE };
		options.availableStoreNames = new string[] { OpenIAB_Android.STORE_GOOGLE };
		options.storeKeys = new Dictionary<string, string> { {OpenIAB_Android.STORE_GOOGLE, PublicKey} };
		options.storeSearchStrategy = SearchStrategy.INSTALLER_THEN_BEST_FIT;
		
		// Transmit options and start the service
		OpenIAB.init(options);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Purchase(string sku)
	{
		OpenIAB.purchaseProduct(sku);
		Pid = sku;

	}
	public void Consume(string sku)
	{
		if (_inventory != null && _inventory.HasPurchase(sku))
			OpenIAB.consumeProduct(_inventory.GetPurchase(sku));
		
	}

	private void billingSupportedEvent()
	{

		Debug.Log("billingSupportedEvent");
	}
	private void billingNotSupportedEvent(string error)
	{
		Debug.Log("billingNotSupportedEvent: " + error);

	}
	private void queryInventorySucceededEvent(Inventory inventory)
	{
		Debug.Log("queryInventorySucceededEvent: " + inventory);

		if(con)
		con.text = "qs";
		
		if (inventory != null)
		{
			_inventory = inventory;
		}

		Consume (Pid);


	}
	private void queryInventoryFailedEvent(string error)
	{

		Debug.Log("queryInventoryFailedEvent: " + error);

		if(con)
		con.text = "qf";
		
		query ();

	}
	private void purchaseSucceededEvent(Purchase purchase)
	{
		if(con)
		con.text = "purchased";
		
		Debug.Log("purchaseSucceededEvent: " + purchase);

		if(Pid == "android.test.purchased")
		{
			PlayerPrefs.SetInt("cash",PlayerPrefs.GetInt("cash")+100);
			if(dollars)
			dollars.text = PlayerPrefs.GetInt("cash").ToString();
		}


		if (Pid == "removeads") 
		{

			if(dollars)
			PlayerPrefs.SetInt("cash",PlayerPrefs.GetInt("cash")+100);
			dollars.text = PlayerPrefs.GetInt("cash").ToString();

		}
		if (Pid == "unlockalllevels") 
		{
			
		

			
		}
		query ();

	}
	private void purchaseFailedEvent(int errorCode, string errorMessage)
	{
		Debug.Log("purchaseFailedEvent: " + errorMessage);

		if(con)
		con.text = "purchasefailed";
		
		query ();

	}
	private void consumePurchaseSucceededEvent(Purchase purchase)
	{
		Debug.Log("consumePurchaseSucceededEvent: " + purchase);
		if(con)
		con.text = "consumed";


	}
	private void consumePurchaseFailedEvent(string error)
	{
		Debug.Log("consumePurchaseFailedEvent: " + error);
		if(con)
		con.text = "ntcnsmd";
		query ();

	}
	public void query()
	{
		OpenIAB.queryInventory(new string[] { SKU });
	}
}
