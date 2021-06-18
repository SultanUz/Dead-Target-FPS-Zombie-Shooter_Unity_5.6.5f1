using UnityEngine;
using System.Collections;

public class AP_BulletFollowPreset : AS_ActionPreset
{
	public float ZoomMulti = 1;
	public override void Shoot (GameObject bullet)
	{
		if (!ActionCam) {
			return;	
		}

		ActionCam.InAction = false;
		ActionCam.ObjectLookAt = bullet;
		ActionCam.ObjectFollowing = bullet;
		ActionCam.SetPosition (bullet.transform.position - bullet.transform.forward * ZoomMulti, false);
		base.Shoot (bullet);
	}
	
	public override void FirstDetected (AS_Bullet bullet, AS_BulletHiter target,Vector3 point)
	{
		if (!ActionCam) {
			return;	
		}
		
		if (!ActionCam.InAction) {
			//Debug.Log ("First Detect target : " + target.gameObject.name);
			ActionCam.ObjectLookAt = bullet.gameObject;
			ActionCam.ObjectFollowing = bullet.gameObject;
			ActionCam.Follow = true;
			ActionCam.SetPosition (bullet.transform.position + (bullet.transform.right * ZoomMulti) - (bullet.transform.forward * 2 * ZoomMulti), false);
			ActionCam.ActionBullet (10.0f);
			ActionCam.SlowmotionNow (0.1f, 10.0f);
		}
		
		
		base.FirstDetected (bullet, target, point);
	}
	
	public override void TargetDetected (AS_Bullet bullet, AS_BulletHiter target,Vector3 point)
	{
		
		if (!ActionCam) {
			return;	
		}
		if (!ActionCam.HitTarget) {
			ActionCam.ObjectLookAt = bullet.gameObject;
			ActionCam.ObjectFollowing = bullet.gameObject;
			ActionCam.ActionBullet (10.0f);
			ActionCam.Slowmotion (0.01f, 2.0f);
			ActionCam.Follow = true;
			ActionCam.LengthOffset = -(ActionCam.Length-1);
			ActionCam.SetPosition (bullet.transform.position + (bullet.transform.right * ZoomMulti) - (bullet.transform.forward * ZoomMulti), ActionCam.Detected);
		}
		base.TargetDetected (bullet, target, point);
	}
	
	public override void TargetHited (AS_Bullet bullet, AS_BulletHiter target,Vector3 point)
	{
		if (!ActionCam) {
			return;	
		}
		
		ActionCam.Follow = false;
		ActionCam.ObjectFollowing = null;
		ActionCam.ObjectLookAt = target.gameObject;
		ActionCam.ActionBullet (3.0f);
		ActionCam.Slowmotion (0.05f, 1.5f);
		ActionCam.SetPosition(ActionCam.transform.position,true);
		
		
		base.TargetHited (bullet, target, point);
		
	}
}
