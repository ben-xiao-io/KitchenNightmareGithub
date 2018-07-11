using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCutting : MonoBehaviour {

	public Material capMaterial;
	public int maxAmountOfCut = 5;
	public float minimumCutSize = 1f;

	private int currentAmountOfCut;
	// Use this for initialization
	void Start () {
	}
		
	void OnCollisionEnter(Collision collision) {
		
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit)) {
			if (currentAmountOfCut <= maxAmountOfCut && collision.gameObject.GetComponent<Cuttable> ()) {
				
				GameObject victim = collision.collider.gameObject;
				Destroy (victim.GetComponent<MeshCollider> ());
				GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut (victim, transform.position, transform.right, capMaterial);
				victim.AddComponent<MeshCollider> ().convex = true;
				currentAmountOfCut++;

				for (int i = 1; i < pieces.Length; i++) {
					if (pieces [i] != null) {
						Mesh piece_mesh = pieces[i].GetComponent<MeshFilter> ().mesh;
						if (piece_mesh.vertexCount < 3 || volumeOfMesh (piece_mesh) < 0.00001f) {
							//Debug.Log ("removed" + volumeOfMesh (piece_mesh));
							currentAmountOfCut--;
							Destroy (pieces[i]);

						}else if (piece_mesh.bounds.size.x < 0.0001 || piece_mesh.bounds.size.y < 0.0001 || piece_mesh.bounds.size.z < 0.0001) {
							//Debug.Log ("removed2 " + piece_mesh.bounds.size.x + " " + piece_mesh.bounds.size.y + " " + piece_mesh.bounds.size.z);
							currentAmountOfCut--;
							Destroy (pieces[i]);
						} else {
							//passed
							Debug.Log ("passed");


							victim.GetComponent<Cuttable> ().cut ();

							pieces [i].name = victim.name + i.ToString();

							if (!pieces[i].GetComponent<MeshCollider> ())
								pieces[i].AddComponent<MeshCollider> ().convex = true;

							if (!pieces[i].GetComponent<Rigidbody> ())
								pieces[i].AddComponent<Rigidbody> ();
						}
					}
				}


				//Debug.Log (currentAmountOfCut);
			}
		}
	}

	void OnDrawGizmosSelected() {

		Gizmos.color = Color.green;

		Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5.0f);
		Gizmos.DrawLine(transform.position + transform.up * 0.5f, transform.position + transform.up * 0.5f + transform.forward * 5.0f);
		Gizmos.DrawLine(transform.position + -transform.up * 0.5f, transform.position + -transform.up * 0.5f + transform.forward * 5.0f);

		Gizmos.DrawLine(transform.position, transform.position + transform.up * 0.5f);
		Gizmos.DrawLine(transform.position,  transform.position + -transform.up * 0.5f);

	}

	public float volumeOfMesh (Mesh mesh) {
		float volume = 0f;
		Vector3[] verticies = mesh.vertices;
		int[] triangles = mesh.triangles;

		for (int i = 0; i < mesh.triangles.Length; i += 3) {
			Vector3 p1 = verticies [triangles [i + 0]];
			Vector3 p2 = verticies [triangles [i + 1]];
			Vector3 p3 = verticies [triangles [i + 2]];
			volume += SignedOfVolumeOfTriangle (p1, p2, p3);
		}
		return Mathf.Abs(volume);
	}

	public float SignedOfVolumeOfTriangle (Vector3 p1, Vector3 p2, Vector3 p3) {
		float v321 = p3.x * p2.y * p1.z;
		float v231 = p2.x * p3.y * p1.z;
		float v312 = p3.x * p1.y * p2.z;
		float v132 = p1.x * p3.y * p2.z;
		float v213 = p2.x * p1.y * p3.z;
		float v123 = p1.x * p2.y * p3.z;
		return (1.0f / 6.0f) * (-v321 + v231 + v312 - v132 - v213 + v123);
	}
}
