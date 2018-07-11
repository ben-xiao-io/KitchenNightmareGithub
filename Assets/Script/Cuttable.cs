using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cuttable : MonoBehaviour {

	public GameObject gameHandler;
	private int timesCut = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void cut () {
		timesCut++;

		if (SceneManager.GetActiveScene().name == "Level 1") {
			if (timesCut == 1) {
				Debug.Log("Cut in half " + timesCut);

				gameHandler.GetComponent<Level1>().gameCompletion(1);
			} else {

				Debug.Log("Cut in more than half " + timesCut);
				gameHandler.GetComponent<Level1>().gameCompletion(-1);
			}
		}
	}
}
