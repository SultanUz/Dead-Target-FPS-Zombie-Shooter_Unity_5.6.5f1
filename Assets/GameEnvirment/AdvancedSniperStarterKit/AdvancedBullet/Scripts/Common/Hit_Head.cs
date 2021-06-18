using UnityEngine;
using System.Collections;

public class Hit_Head : AS_BulletHiter {
	
	public override void OnHit (RaycastHit hit,AS_Bullet bullet)
	{
		if(this.RootObject.GetComponent<Status>()){
			this.RootObject.GetComponent<Status>().ApplyDamage(bullet.Damage * 3,bullet.transform.forward * bullet.HitForce,2);	
		}
		AddAudio(hit.point);
		base.OnHit (hit,bullet);
	}
}
