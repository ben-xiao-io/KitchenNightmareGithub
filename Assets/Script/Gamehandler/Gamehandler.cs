using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Gamehandler : MonoBehaviour {

	public GameObject levelDisplay;
	public Text levelDisplayText;
	// Use this for initialization
	void Start () {
		levelDisplay.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void switchScene (string levelname) {
		SceneManager.LoadScene (levelname, LoadSceneMode.Single);
	}

	public void levelPassed () {
		Debug.Log("Level passed!");
		levelDisplayText.GetComponent<TyperWriteEffect>().full_text = "Yay! Level Passed! \n^-^ Let's move on! Wave around to close this dialogue.\nUse menu to move on.";
		StartCoroutine(delayTime(5));
	}

	public void levelFailed () {
		Debug.Log("Level Failed");

		levelDisplayText.GetComponent<TyperWriteEffect>().full_text = "Darn! Almost Had It! \n^_- Better Luck Next Time! Wave around to close this dialogue.\nUse to move on.";
		StartCoroutine(delayTime(5));
	}

	IEnumerator delayTime(int s) {
		yield return new WaitForSeconds(s);

		levelDisplay.SetActive(true);
	}
}
