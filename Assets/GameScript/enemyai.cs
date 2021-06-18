
using UnityEngine;
using System.Collections;

public class enemyai : MonoBehaviour {
	public float attackDist = 5;
	public Transform player;
	public float fireRate = 0.5f;
	float nextFire;
	public float damage= 2;
	public AnimationClip attackAnim;
	public AnimationClip idleAnim;
	public Transform enemy;
	//public AudioClip enemyattack;
	public float localSpeed = 5.0f;
	public Texture blood;
	public Renderer pe;
	public bool  isDrawBloodTexture=true ;
	RaycastHit hit;
	public static bool oneshotsound=false;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find ("Player").transform;
		pe.GetComponent<Renderer>().enabled=false;
		isDrawBloodTexture=false ;
	}
	void OnGUI() 
	{
		if (isDrawBloodTexture == true) 
		{	
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), blood);
		} 
		else
		{
			isDrawBloodTexture=false;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		transform.LookAt(player);
		//enemy.rotation = Quaternion.Slerp(enemy.rotation,Quaternion.LookRotation(player.position - enemy.position),Time.deltaTime * 9);
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		if (Vector3.Distance (player.position, enemy.position) <= attackDist) 
		{
			Vector3 targetDir = player.transform.position - enemy.transform.position;
			if (Physics.Raycast (transform.position, fwd, out hit,50)) 
			{
				Debug.Log(hit.collider.name);
				if (hit.collider.name == "Player") 
				{
					Attack ();

				}
				else
				{
					enemy.rotation = Quaternion.Slerp(enemy.rotation,Quaternion.LookRotation(player.position - enemy.position),Time.deltaTime * 9);
					enemy.eulerAngles = new Vector3(0,enemy.eulerAngles.y,0);
					enemy.GetComponent<Animation>().Stop(attackAnim.name);
					enemy.GetComponent<Animation>()[idleAnim.name].wrapMode = WrapMode.Once;	
					enemy.GetComponent<Animation>().Play(idleAnim.name);
					pe.GetComponent<Renderer>().enabled = false;
					isDrawBloodTexture=false ;
				}
			}
		}
		else 
		{
			enemy.rotation = Quaternion.Slerp(enemy.rotation,Quaternion.LookRotation(player.position - enemy.position),Time.deltaTime * 9);
			enemy.eulerAngles = new Vector3(0,enemy.eulerAngles.y,0);
			enemy.GetComponent<Animation>().Stop(attackAnim.name);
			enemy.GetComponent<Animation>()[idleAnim.name].wrapMode = WrapMode.Once;
			enemy.GetComponent<Animation>().Play(idleAnim.name);
			pe.GetComponent<Renderer>().enabled = false;
			isDrawBloodTexture=false ;
		}
	}
	void  Attack ()
	{	
		oneshotsound = true;
		pe.GetComponent<Renderer>().enabled = true;
		enemy.GetComponent<Animation>().Play(attackAnim.name);
		enemy.rotation = Quaternion.Slerp(enemy.rotation,Quaternion.LookRotation(player.position - enemy.position),Time.deltaTime * 9);
		enemy.eulerAngles = new Vector3(0,enemy.eulerAngles.y,0);
		PlayerHealth.health -= damage * Time.deltaTime;
		if (Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			isDrawBloodTexture = !isDrawBloodTexture;	
			//PlayAudioClip(enemyattack,transform.position,0.5f);
		} 
	}
	void PlayAudioClip ( AudioClip clip ,   Vector3 position ,   float volume  ) 
	{
		GameObject go= new GameObject ("One shot audio");
		go.transform.position = position;
		AudioSource source = go.AddComponent <AudioSource>();
		source.clip = clip;
		source.volume = volume;
		source.minDistance = 20;
		//source.Play ();
		if(GetComponent<AudioSource>().isPlaying==false)
		GetComponent<AudioSource>().PlayOneShot (clip , 2);
		Destroy (go, clip.length);	
	}
}