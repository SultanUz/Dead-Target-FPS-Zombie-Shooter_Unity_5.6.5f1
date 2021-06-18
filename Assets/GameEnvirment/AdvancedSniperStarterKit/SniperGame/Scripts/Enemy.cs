using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public Transform Myself;
	public float Speed = 3;
	public AudioClip[] footstepSound;
	public Vector3 targetPosition;
	public int timethink = 0;
	
	void Start () {
		//Myself.animation.CrossFade("walk2", 0.3f);
	}


	void Update (){

		//Myself.animation.CrossFade("Run", 0.3f);
	
		if(timethink<=0)
		{
   			targetPosition = new Vector3(Random.Range(-200,200),0,Random.Range(-200,200));
   			timethink = Random.Range(100,500);
   		}
		else
		{
   			timethink-=1;
   		}
   		targetPosition.y = transform.position.y;
		Quaternion rotationTarget = Quaternion.LookRotation((targetPosition - this.transform.position).normalized);
   		transform.rotation = Quaternion.Lerp(this.transform.rotation,rotationTarget,Time.deltaTime * 5);
   		transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * Speed);
	}
}
