using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;
using Leap.Unity;

public class TyperWriteEffect : MonoBehaviour {

	private LeapServiceProvider leapProvider;

	public GameObject textParent;

	public float delay = 0.1f;

	[TextArea(3,10)]
	public string full_text;

	private string current_text = "";

	int fadehash = Animator.StringToHash("ScriptAnimation");

	// Use this for initialization
	void Start () {

		textParent = this.transform.parent.gameObject;
		StartCoroutine (showText());

		leapProvider = FindObjectOfType<LeapServiceProvider> ();
	}

	void Update () {
		Frame currentFrame = leapProvider.CurrentFrame;
		foreach (Hand hand in currentFrame.Hands) {
			if (hand.PalmVelocity.Magnitude > 3f) {
				textParent.gameObject.SetActive (false);
			}
		}
	}

	// Update is called once per frame
	IEnumerator showText () {
		for (int i = 0; i <= full_text.Length; i++) {
			current_text = full_text.Substring (0, i);
			this.GetComponent<Text> ().text = current_text;

			yield return new WaitForSeconds(delay);
		}

	}
}
