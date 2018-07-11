using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainOriginCenter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 TS = GetComponent<Terrain>().terrainData.size;
 		transform.position = new Vector3(-TS.x/2, -1, -TS.z/2);	
	}
}
