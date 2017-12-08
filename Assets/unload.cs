using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class unload : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager.UnloadSceneAsync("gui");
        Scene current = SceneManager.GetSceneByName("Jumping Jack");
        SceneManager.SetActiveScene(current);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
