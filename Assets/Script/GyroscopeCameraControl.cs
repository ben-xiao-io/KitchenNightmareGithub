using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeCameraControl : MonoBehaviour {
	private bool gryoEnabled;
	private Gyroscope gyro;

	private GameObject camera_container;
	private Quaternion rotation;

	// Use this for initialization
	void Start () {
		camera_container = new GameObject ("Camera Container");
		camera_container.transform.position = transform.position;
		transform.SetParent (camera_container.transform);
		gryoEnabled = EnableGyro ();
	}

	// Update is called once per frame
	void Update () {
		if (gryoEnabled) {
			transform.localRotation = gyro.attitude * rotation;
			//the x and y axis are inverted yeah
			//this.transform.Rotate (-Input.gyro.rotationRateUnbiased.x, -Input.gyro.rotationRateUnbiased.y, Input.gyro.rotationRateUnbiased.z);
		}
	}

	private bool EnableGyro() {
		if (!SystemInfo.supportsGyroscope) {
			return false;
			Debug.LogError ("Gyroscope is not supported");
		}

		gyro = Input.gyro;
		gyro.enabled = true;

		camera_container.transform.rotation = Quaternion.Euler (90f, 90f, 0f);
		rotation = new Quaternion (0, 0, 1, 0);

		return true;
	}
}
