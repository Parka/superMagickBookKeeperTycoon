using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour {
	private float leftSpace = 99999999f;
	private float rightSpace = 99999999f;
	[SerializeField]
	private float size = 0.01f;
	private float inFlow = 1f;
	private float outFlow = 0f;
	private float evaporation = 0.2f;

	// Use this for initialization
	void Start () {
		calcDist ();
	}
	void calcDist(){
		RaycastHit2D[] hits = Physics2D.RaycastAll (transform.parent.position + (Vector3)Vector2.up * 0.01f, Vector2.right);
		foreach (RaycastHit2D hit in hits) {
			if (hit.collider != null & !hit.collider.isTrigger & (hit.collider.gameObject.tag == "Shelve")) {
				rightSpace = Mathf.Abs (hit.point.x - transform.parent.position.x);
				Debug.DrawRay (hit.point, hit.normal, Color.green, 2, false);
				break;
			}
		}
		hits = Physics2D.RaycastAll (transform.parent.position + (Vector3)Vector2.up * 0.01f, -Vector2.right);
		foreach (RaycastHit2D hit in hits) {
			if (hit.collider != null & !hit.collider.isTrigger & (hit.collider.gameObject.tag == "Shelve")) {
				leftSpace = Mathf.Abs (hit.point.x - transform.parent.position.x);
				Debug.DrawRay (hit.point, hit.normal, Color.green, 2, false);
				break;
			}
		}
	}
	// Update is called once per frame
	void LateUpdate () {
		//#TO DO: There's a scale problem! :(
		float scale = GetComponent<Renderer>().bounds.size.x / transform.localScale.x;
		float sizeDelta = (inFlow - outFlow - evaporation) * Time.deltaTime;
		size += sizeDelta;
		Debug.Log (sizeDelta.ToString() + " || " + size.ToString() + " || " + scale.ToString());
		if (size >= (rightSpace + leftSpace) * scale) {
			size = (rightSpace + leftSpace) * scale;
			//TO DO: Create a new waterfall at this point, or start increasing size vertically
		}
		if (size / 2 > rightSpace * scale) {
			transform.parent.position = transform.parent.position - Vector3.right * (sizeDelta / scale / 2);
			calcDist ();
		}
		if (size / 2 > leftSpace * scale) {
			transform.parent.position = transform.parent.position + Vector3.right * (sizeDelta / scale / 2);
			calcDist ();
		}
		transform.localScale = new Vector3 (size / scale,1, 1);
		inFlow = 0;
		if (size <= 0) {
			//Destroy (gameObject);
			Destroy (transform.parent.gameObject);
		}
	}

	void FixedUpdate() {
		

	}

	public void addInFlow(float flow){
		inFlow += flow;
	}
}
