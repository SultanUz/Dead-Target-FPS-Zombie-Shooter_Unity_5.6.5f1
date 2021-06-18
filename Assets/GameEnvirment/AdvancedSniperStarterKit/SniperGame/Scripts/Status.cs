using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Status : MonoBehaviour
{

	public GameObject[] deadbody;
	public AudioClip[] hitsound;
	public int hp = 100;
	private Vector3 velositydamage;
	
	public void ApplyDamage (int damage, Vector3 velosity)
	{
		if (hp <= 0) {
			GetComponent<Animation>().Play ("die");
		}
		hp -= damage;
		velositydamage = velosity;
		if (hp <= 0) {
			Dead (Random.Range (0, deadbody.Length));
		}
	}
	
	public void ApplyDamage (int damage, Vector3 velosity, int deadIndex)
	{
		if (hp <= 0) {
			return;
		}
		hp -= damage;
		velositydamage = velosity;
		if (hp <= 0) {
			Dead (deadIndex);
		}
	}

	private AS_ActionCamera actioncam;
	private AS_RagdollReplace ragdollReplace;
	
	public void Dead (int index)
	{
		GetComponent<Animation>().Play ("die");
		GetComponent<Enemy>().enabled = false;
		Destroy(gameObject, 3);
		GetComponent<PatrollingEnemyAI>().enabled = false;
		if (deadbody.Length > 0 && index >= 0 && index < deadbody.Length) 
		{
			GameObject deadReplace = (GameObject)Instantiate (deadbody [index], this.transform.position, this.transform.rotation);
			ragdollReplace = deadReplace.GetComponent<AS_RagdollReplace> ();
			actioncam = (AS_ActionCamera)FindObjectOfType (typeof(AS_ActionCamera));
			if (actioncam)
			{
				actioncam.ObjectLookAt = deadReplace.gameObject;
			}
			CopyTransformsRecurse (this.transform, deadReplace);
			Destroy (deadReplace, 5);
			Destroy (this.gameObject);
		}
	}
	
	// Copy all transforms to Ragdoll object
	public void CopyTransformsRecurse (Transform src, GameObject dst)
	{
		dst.transform.position = src.position;
		dst.transform.rotation = src.rotation;
		if (actioncam) 
		{
			if (actioncam.ObjectLookAtRoot == this.gameObject) 
			{
				if (ragdollReplace != null) 
				{
					actioncam.ObjectLookAt = ragdollReplace.LootAtObject.gameObject;
					if (ragdollReplace.GetComponent<Rigidbody>())
					{
						ragdollReplace.GetComponent<Rigidbody>().AddForce(velositydamage,ForceMode.Impulse);
					}
				}
			}	
		}
		foreach (Transform child in dst.transform) 
		{
			var curSrc = src.Find (child.name);
			if (curSrc) 
			{
				CopyTransformsRecurse (curSrc, child.gameObject);
			}
		}
	}
}