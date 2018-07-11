using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Rotate : MonoBehaviour {

     public GameObject character;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        character.transform.Rotate(0, -30 * Time.deltaTime, 0);
	}
}
