using UnityEngine;
using System.Collections;

public class AP_FastHit : AS_ActionPreset
{
	public float ZoomMulti = 1;
	public override void Shoot (GameObject bullet)
	{
		if (!ActionCam) {
			return;	
		}
		ActionCam.InAction = false;
		ActionCam.Follow = false;
		base.Shoot (bullet);
	}
	
	public override void FirstDetected (AS_Bullet bullet, AS_BulletHiter target, Vector3 point)
	{
		if (!ActionCam) {
			return;	
		}
		if (!ActionCam.InAction) {


			ActionCam.Follow = true;
			ActionCam.SetPosition (bullet.transform.position + (bullet.transform.right * ZoomMulti) - (bullet.transform.forward * 2 * ZoomMulti), false);
			ActionCam.Slowmotion (0.5f, 10.0f);
		}
		
		
		base.FirstDetected (bullet, target, point);
	}

	public override void TargetDetected (AS_Bullet bullet, AS_BulletHiter target, Vector3 point)
	{
		
		if (!ActionCam) {
			return;	
		}
		
		if (!ActionCam.HitTarget) {
			ActionCam.ObjectFollowing = null;
			ActionCam.ObjectLookAt = null;
			
			ActionCam.SetLookAtPosition(point);
			ActionCam.SetPosition (point + (bullet.transform.right) - (bullet.transform.forward * 2 * ZoomMulti), false);
			
		}
		base.TargetDetected (bullet, target, point);
	}
	
	public override void TargetHited (AS_Bullet bullet, AS_BulletHiter target, Vector3 point)
	{
		if (!ActionCam) {
			return;	
		}
		if (!ActionCam.HitTarget) {
			ActionCam.Follow = true;
			ActionCam.ObjectFollowing = null;
			ActionCam.ObjectLookAt = null;
			ActionCam.ActionBullet (3.0f);
			ActionCam.SlowmotionNow (0.2f, 1.6f);

		}
		
		base.TargetHited (bullet, target, point);
		
	}
}
