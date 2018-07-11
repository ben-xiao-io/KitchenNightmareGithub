using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanMeatProx : MonoBehaviour {

	private bool startCooking = false;
	private bool overCooking = false;

	public GameObject gameHandler;

	public Material meatCooked;
	
	public GameObject panProx;
	public ParticleSystem panSmoke;
	public ParticleSystem flame;

	public GameObject meatProx;
	public GameObject meat;

	public GameObject panMeatProx;

	// Use this for initialization
	void Start () {
		panSmoke.Stop();
	}
	
	// Update is called once per frame
	void Update () {

		if (startCooking != true) {
			//not cooking
			if (Vector3.Distance(panProx.transform.position, meatProx.transform.position) < 0.07f
			&& Vector3.Distance(panProx.transform.position, panMeatProx.transform.position) < 0.07f) {
				startCooking = true;
				beginCooking();
			}
		}


	}

	public Coroutine startCookingCO;

	public void beginCooking () {
		Debug.Log("started Cooking");
		panSmoke.Play();
		startCookingCO = StartCoroutine (timer());
	}

	public void changeToCookedMesh () {
		meat.GetComponent<MeshRenderer>().material = meatCooked;

		StartCoroutine(timeroverCook());
	}

	IEnumerator timer () {

		for (int i = 0; i <= 10; i++) {
			Debug.Log(i);
			if(i == 10) {
				Debug.Log("Cooked");
				changeToCookedMesh();
				overCooking = true;
			}
			if(Vector3.Distance(panProx.transform.position, meatProx.transform.position) > 0.07f) {
				i = 11;
				panSmoke.Stop();
				gameHandler.GetComponent<Gamehandler>().levelFailed();
			}
			yield return new WaitForSeconds(1);
		}
//panSmoke.Stop();
	}

	IEnumerator timeroverCook() {
		for (int i = 0; i <= 4; i++) {
			Debug.Log(i);
			if (i == 4) {
				flame.startLifetime = 1.3f;
				gameHandler.GetComponent<Gamehandler>().levelFailed();
			}
			if (Vector3.Distance(panProx.transform.position, meatProx.transform.position) > 0.07f) {
				gameHandler.GetComponent<Gamehandler>().levelPassed();
				panSmoke.Stop();
				i = 5;
			}
			yield return new WaitForSeconds(1);
		}
	}
}
