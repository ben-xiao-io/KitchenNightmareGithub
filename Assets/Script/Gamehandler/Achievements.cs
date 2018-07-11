using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Achievements : MonoBehaviour {

	public Canvas achievementCanvas;
	public Text achievementNameText;

	// Use this for initialization
	void Start () {
		achievementCanvas.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().name == "Main") {
			if (GameObject.Find ("right side") != null) {
				displayAchievement ("Fruit Ninja");
			}
		}
	}

	public void displayAchievement (string achievementName) {
		achievementCanvas.gameObject.SetActive (true);

		achievementNameText.text = achievementName;
		saveAchievement (achievementName);
	}	

	public void saveAchievement (string achievementName) {
		if (PlayerPrefs.GetString(achievementName) == null || PlayerPrefs.GetString(achievementName) == "true") {
			PlayerPrefs.SetString (achievementName, "true");
		}
	}
}
