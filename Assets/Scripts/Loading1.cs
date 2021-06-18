using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Example());
		
	}

    IEnumerator Example()
    {
        
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(1);
        
    }
}
