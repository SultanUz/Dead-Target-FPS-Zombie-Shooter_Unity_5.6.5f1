using UnityEngine;
using System.Collections;

public class Loop : MonoBehaviour {
	public AnimationClip moveAnim1;
	public AnimationClip moveAnim2;
	public AnimationClip moveAnim3;
	public AnimationClip moveAnim4;
	public AnimationClip moveAnim5;
	public AnimationClip moveAnim6;
	public AnimationClip moveAnim7;
	public AnimationClip moveAnim8;
	public Transform model1;
	public Transform model2;
	public Transform model3;
	public Transform model4;
	public Transform model5;
	public Transform model6;
	public Transform model7;
	public Transform model8;
	// Use this for initialization
	void Start () {
		model1.GetComponent<Animation>()[moveAnim1.name].wrapMode = WrapMode.Loop;
		model2.GetComponent<Animation>()[moveAnim2.name].wrapMode = WrapMode.Loop;
		model3.GetComponent<Animation>()[moveAnim3.name].wrapMode = WrapMode.Loop;
		model4.GetComponent<Animation>()[moveAnim4.name].wrapMode = WrapMode.Loop;
		model5.GetComponent<Animation>()[moveAnim5.name].wrapMode = WrapMode.Loop;
		model6.GetComponent<Animation>()[moveAnim6.name].wrapMode = WrapMode.Loop;
		model8.GetComponent<Animation>()[moveAnim8.name].wrapMode = WrapMode.Loop;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
