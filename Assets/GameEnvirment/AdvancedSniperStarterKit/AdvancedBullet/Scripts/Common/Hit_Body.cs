using UnityEngine;
using System.Collections;

public class Hit_Body : AS_BulletHiter {
	

	public override void OnHit (RaycastHit hit,AS_Bullet bullet)
	{
		if(this.RootObject.GetComponent<Status>()){
			this.RootObject.GetComponent<Status>().ApplyDamage(bullet.Damage,bullet.transform.forward * bullet.HitForce,Random.Range(0,2));
		}
		AddAudio(hit.point);
		base.OnHit (hit,bullet);
	}
}
