using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour {

	public Transform spawnPoint;
	public float spawnTime = 5f;
	public GameObject customer;

	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Spawn() {
		Randomize (Instantiate (customer, spawnPoint.position, spawnPoint.rotation));
	}

	public void Randomize(GameObject customer) {
		Debug.Log ("Hey!");
		SpriteRenderer sr = customer.GetComponent<SpriteRenderer> ();
		sr.color = new Color (Random.value, Random.value, Random.value, 1.0f);
		CustStateManager sm = customer.GetComponent<CustStateManager> ();	
		sm.patience = 5 + 5 * Random.value;
	}
}
