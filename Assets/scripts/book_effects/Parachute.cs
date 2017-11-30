using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute : MonoBehaviour {
	[SerializeField]
	private GameObject parachutePrefab;
	private GameObject parachute;
	private Rigidbody2D rb;
	private bool deployed;
	// Use this for initialization
	void Start () {
		deployed = false;
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rb != null){
			if (!deployed & rb.velocity.y < -4) {
				parachute = Instantiate (parachutePrefab);
				parachute.transform.SetParent (gameObject.transform);
				parachute.transform.position = gameObject.transform.position + Vector3.up * 0.5f;
				rb.gravityScale = 0.05f;
				rb.velocity = rb.velocity * 0.1f;
				deployed = true;
			}
			if (deployed & rb.velocity.y == 0) {
				Destroy (parachute);
				rb.gravityScale = 1f;
				deployed = false;
			}
		}
	}
}
