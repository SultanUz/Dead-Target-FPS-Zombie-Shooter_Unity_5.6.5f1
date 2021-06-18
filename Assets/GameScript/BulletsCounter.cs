using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BulletsCounter : MonoBehaviour
{
	Text txtBullet;
	Text txtZobmie;
	public  int bults_Gun;
	public  int bults_Pistal;
	public int B_over_Gun;
	public int B_over_Pistal;
	public int Z_over;
	public int zombi;
	public static int bullet_G;
	public static int bullet_P;
	public static bool gun = false;
	public static bool pistal = false;
	// Use this for initialization
	void Start ()
	{
		bullet_G = bults_Gun;
		bullet_P = bults_Pistal;
		gun = true;
		pistal = false;
	}

	void Awake ()
	{
		txtBullet = GameObject.Find ("B").GetComponent<Text> ();
		txtZobmie = GameObject.Find ("Z").GetComponent<Text> ();
	}
	// Update is called once per frame
	void Update ()
	{
		//bults_Gun = bullet_G;
		//bults_Pistal = bullet_P;
		zombi = Timer.zombieLength;
		//zombieL.text="Zombies: " + zombi + "/" + Z_over;
		txtZobmie.text = zombi + "/" + Z_over;
	}

	void OnGUI ()
	{
		//GUI.DrawTexture (new Rect (Screen.width * .8f, Screen.height * .01f, Screen.width*.2f,Screen.height*.15f), bulletimage_Gun);
		//bulletG.text="Bullets: " + bullet_G + "/" + B_over_Gun;
		if (gun == true) {
			//GUI.DrawTexture (new Rect (Screen.width * .8f, Screen.height * .01f, Screen.width*.2f,Screen.height*.15f), bulletimage_Gun);
			//bulletG.text="Bullets: " + bullet_G + "/" + B_over_Gun;
			txtBullet.text = bullet_G + "/" + B_over_Gun;
		}
		if (pistal == true) {
			//GUI.DrawTexture (new Rect (Screen.width * .8f, Screen.height * .01f, Screen.width*.2f,Screen.height*.15f), bulletimage_Pistal);
			//bulletP.text="Bullets: " + bullet_P + "/" + B_over_Pistal;
			txtBullet.text = bullet_P + "/" + B_over_Pistal;
		}
	}
}
