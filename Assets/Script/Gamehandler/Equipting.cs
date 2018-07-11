using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipting : MonoBehaviour {
	
	public GameObject rightCursor;
	private bool isCurrentlyEquipt;
	public GameObject currentlyEquiptWith;
	public GameObject rightLeapHandRigidBody;
	public GameObject rightLeapHandMesh;

	// Use this for initialization
	void Start () {
		isCurrentlyEquipt = false;

		if (rightCursor == null || rightLeapHandMesh == null || rightLeapHandRigidBody == null) {
			Debug.LogError ("Missing equipment. Cannot equipt");
		}
	}
		
	// Update is called once per frame
	void Update () {
		if (rightLeapHandMesh.active == false) {
			
		}
	}

	public void equip (GameObject equipment) {
		Debug.Log ("equipping");
		if (isCurrentlyEquipt) {

		} else {//hard coded for just the basic knife
			currentlyEquiptWith = Instantiate (equipment, rightCursor.transform.position , Quaternion.identity);

			currentlyEquiptWith.transform.SetParent (rightCursor.transform);

			currentlyEquiptWith.transform.forward = rightCursor.transform.up;
			rightLeapHandMesh.gameObject.SetActive(false);
			rightLeapHandRigidBody.gameObject.SetActive (false);
			currentlyEquiptWith.transform.Rotate(new Vector3 (0,0,90f));

			isCurrentlyEquipt = true;
		}
	}

	public void unequip () {
		isCurrentlyEquipt = false;

		string equipment_name = currentlyEquiptWith.name;

		Destroy (GameObject.Find(equipment_name));

		rightLeapHandMesh.gameObject.SetActive(true);
		rightLeapHandRigidBody.gameObject.SetActive (true);
	}
}
