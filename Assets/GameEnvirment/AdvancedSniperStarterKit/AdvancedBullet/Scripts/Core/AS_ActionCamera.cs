using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Camera))]
public class AS_ActionCamera : MonoBehaviour
{
	
	public AS_ActionPreset[] ActionPresets;
	[HideInInspector]
	public GameObject ObjectLookAt, ObjectFollowing, ObjectLookAtRoot;
	[HideInInspector]
	public Vector3 Position, PositionOffset, PositionFollowOffset, PositionHit;
	[HideInInspector]
	public Vector3 PositionLookAt;
	[HideInInspector]
	public float Raduis = 5;
	[HideInInspector]
	public float TimeDuration = 2;
	[HideInInspector]
	public float SlowTimeDuration = 2;
	public int PresetIndex = 0;
	[HideInInspector]
	public bool InAction;
	[HideInInspector]
	public bool Detected;
	[HideInInspector]
	public bool HitTarget;
	public float TimeChangeSpeed = 10;
	private static float initialFixedTimeStep = 1;
	private static float initialDeltaTimeStep = 1;
	private static float initialMaximumDeltaTime = 1;
	private float timeTemp, slowtimeTemp;
	private bool[] cameraEnabledTemp;
	private bool[] audiolistenerEnabledTemp;
	private float timeScaleTarget = 1;
	[HideInInspector]
	public bool cameraTemp;
	public bool Follow = false;
	public float Length = 15;
	public float LengthOffset = 0;
	public float Damping = 10;
	public int IgnoreCameraLayer = 11;
	public float ColliderOffset = 0.5f;
	public Light SpotLight;
	public Camera MainCamera;
	
	public AS_ActionPreset GetPresets ()
	{
		
		if (ActionPresets.Length <= 0) {
			return null;
			
		}
		AS_ActionPreset res = ActionPresets [Random.Range (0, ActionPresets.Length)];
		if (PresetIndex != -1 && PresetIndex < ActionPresets.Length) {
			res = ActionPresets [PresetIndex];
		}
		
		return res;
	}
	
	void Start ()
	{
		for (int i=0; i<ActionPresets.Length; i++) {
			ActionPresets [i].Initialize ();	
		}
		MainCamera = this.gameObject.GetComponent<Camera> ();
		initialFixedTimeStep = Time.fixedDeltaTime;
		initialDeltaTimeStep = Time.deltaTime;
		initialMaximumDeltaTime = Time.maximumDeltaTime;
	}
	
	public void ActionBullet (float actionduration)
	{
		TimeDuration = actionduration;
		timeTemp = Time.realtimeSinceStartup;
		setTarget ();
	}

	public void SetLookAtPosition (Vector3 pos)
	{
		lookAtPosition = pos;
		ObjectLookAt = null;
	}
	
	public void Slowmotion (float timescale, float slowduration)
	{
		TimeSet (timescale);
		SlowTimeDuration = slowduration;
		slowtimeTemp = Time.realtimeSinceStartup;
	}
	
	public void SlowmotionNow (float timescale, float slowduration)
	{
		TimeSet (timescale);
		Time.timeScale = timescale;
		SlowTimeDuration = slowduration;
		slowtimeTemp = Time.realtimeSinceStartup;
	}
	
	public void TimeSet (float scale)
	{
		timeScaleTarget = scale;
	}

	public void TimeSetNow (float scale)
	{
		timeScaleTarget = scale;
		Time.timeScale = scale;
	}

	private void setTarget ()
	{
		
		InAction = true;
		CameraActive ();
		this.GetComponent<Camera>().enabled = true;
		if (this.GetComponent<Camera>().gameObject.GetComponent<AudioListener> ())
			this.GetComponent<Camera>().gameObject.GetComponent<AudioListener> ().enabled = true;
	}

	private Camera[] cams;

	public void CameraActive ()
	{
		if (!cameraTemp) {
			cams = (Camera[])GameObject.FindObjectsOfType (typeof(Camera));
			audiolistenerEnabledTemp = new bool[cams.Length];
			cameraEnabledTemp = new bool[cams.Length];
			for (int i=0; i<cams.Length; i++) {
				cameraEnabledTemp [i] = cams [i].enabled;
				
				if (cams [i].gameObject.GetComponent<AudioListener> ()) {
					audiolistenerEnabledTemp [i] = cams [i].gameObject.GetComponent<AudioListener> ().enabled;
				}
				
				cams [i].enabled = false;
				if (cams [i].gameObject.GetComponent<AudioListener> ()) {
					cams [i].gameObject.GetComponent<AudioListener> ().enabled = false;
				}
			}
			//Debug.Log ("Action Cameras");
			cameraTemp = true;
		}
	}
	
	public void CameraRestore ()
	{
		if (cameraTemp) {
			cameraTemp = false;
			cams = (Camera[])GameObject.FindObjectsOfType (typeof(Camera));
			if (cameraEnabledTemp != null && cams != null) {
				if (cams.Length > 0 && cameraEnabledTemp.Length > 0 && cameraEnabledTemp.Length == cams.Length) {
					for (int i=0; i<cams.Length; i++) {
						cams [i].enabled = cameraEnabledTemp [i];	
						if (cams [i].gameObject.GetComponent<AudioListener> ()) {
							cams [i].gameObject.GetComponent<AudioListener> ().enabled = audiolistenerEnabledTemp [i];
						}
					}
				}
			}
			//Debug.Log ("Restore Cameras");
		}
	}
	
	public void ClearTarget ()
	{
		
		Follow = false;
		InAction = false;
		HitTarget = false;
		Detected = false;
		ObjectFollowing = null;
		ObjectLookAt = null;
		ObjectLookAtRoot = null;
		LengthOffset = 0;
		LookAtOffset = Vector3.zero;
		CameraRestore ();
	}
	
	Vector3 Direction (Vector3 point1, Vector3 point2)
	{
		return (point1 - point2).normalized;
	}
	[HideInInspector]
	public Vector3 CameraOffset, cameraPosition, LookAtOffset, lookAtPosition;
	
	void cameraCollision ()
	{

		if (ObjectLookAt != null) {
			lookAtPosition = ObjectLookAt.transform.position;
		}
		
		if (Follow) {
			if(ObjectLookAt!=null){
				ObjectFollowing = ObjectLookAt;
			}
		}
		
		cameraPosition = lookAtPosition + (CameraOffset.normalized * (Length + LengthOffset));	
		
		if (ObjectFollowing != null) {
			cameraPosition = ObjectFollowing.transform.position + (CameraOffset.normalized * (Length + LengthOffset));	
		}
		
		float distance = Vector3.Distance (lookAtPosition + LookAtOffset, cameraPosition);
			
		if (distance <= 0)
			distance = 1;
		RaycastHit hit;
		if (Physics.Raycast (lookAtPosition + LookAtOffset, -this.transform.forward, out hit, distance+1)) {
			if (hit.collider.gameObject != this.gameObject && hit.collider.gameObject.layer != IgnoreCameraLayer) {
				cameraPosition = hit.point;
				CameraOffset = (cameraPosition - lookAtPosition).normalized;
			}
		}
		

		if (Physics.Raycast (this.transform.position, -Vector3.up, out hit, 1)) {
			if (hit.collider.gameObject != this.gameObject && hit.collider.gameObject.layer != IgnoreCameraLayer) {
				cameraPosition.y = hit.point.y + 1;
				CameraOffset = (cameraPosition - lookAtPosition).normalized;
			}
		}
	}
	
	public void SetPosition (Vector3 position, bool blend)
	{
		cameraPosition = position;
		
		if (!blend) {
			this.transform.position = position;
		}
		
		if (ObjectLookAt != null)
			CameraOffset = (position - ObjectLookAt.transform.position).normalized;
		
		cameraCollision ();
	}
	
	void FixedUpdate ()
	{
	
		this.transform.position = Vector3.Lerp (this.transform.position, cameraPosition, Damping);
		gameObject.transform.LookAt (lookAtPosition + LookAtOffset);
		
		cameraCollision ();
		
	}

	void Update ()
	{
		/*float timescaleUp = (timeScaleTarget - Time.timeScale) * (Time.deltaTime * TimeChangeSpeed);
		if (Time.timeScale + timescaleUp >= 0 && Time.timeScale + timescaleUp <= 100) {
			Time.timeScale += timescaleUp; 
		}*/
		Time.timeScale = Mathf.Lerp (Time.timeScale, timeScaleTarget, 0.5f);
		Time.fixedDeltaTime = (initialFixedTimeStep * Time.timeScale);	
		
		
		if (Time.realtimeSinceStartup >= timeTemp + TimeDuration) {
			ClearTarget ();
		}
		
		if (Time.realtimeSinceStartup >= slowtimeTemp + SlowTimeDuration) {
			TimeSet (1);	
		}
		if (cameraTemp) {
			for (int i=0; i<cams.Length; i++) {
				if (cams [i] != this.GetComponent<Camera>()) {
					cams [i].enabled = false;	
				}
			}
		}
		if (MainCamera && SpotLight) {
			SpotLight.enabled = MainCamera.enabled;
		}
	}
	

	
}
