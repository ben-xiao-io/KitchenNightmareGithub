using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour {

//	public GameObject gameHandler;
	private int currentCompletion = 0;
	// Use this for initialization
	void Start () {
		
	}

	public void gameCompletion (int x) {
		currentCompletion = currentCompletion + x;
		Debug.Log(currentCompletion);

		if (currentCompletion == 3) {
			
			GetComponent<Achievements>().displayAchievement("Master Chef Cutter");
			
			GetComponent<Gamehandler>().levelPassed();
			
		}

		if (currentCompletion > 3 || currentCompletion <= 0) {

			GetComponent<Gamehandler>().levelFailed();

		}
	}
}
