using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCamera : MonoBehaviour {
	private bool gryoEnabled;
	private Gyroscope gyro;

	private Quaternion rotation;

	// Use this for initialization
	void Start () {
		gryoEnabled = EnableGyro ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gryoEnabled) {
			//the x and y axis are inverted yeah
			this.transform.Rotate (-Input.gyro.rotationRateUnbiased.x, -Input.gyro.rotationRateUnbiased.y, Input.gyro.rotationRateUnbiased.z);
		}
	}

	private bool EnableGyro() {
		if (!SystemInfo.supportsGyroscope) {
			return false;
			Debug.LogError ("Gyroscope is not supported");
		}

		gyro = Input.gyro;
		gyro.enabled = true;

		return true;
	}
}
