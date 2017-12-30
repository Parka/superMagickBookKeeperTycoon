using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfall : MonoBehaviour {

	//private HashSet<GameObject> initialShelves = new HashSet<GameObject>();
	// Use this for initialization
	[SerializeField]
	GameObject puddlePrefab;

	//[SerializeField]
	float flow = 1f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		GameObject newPuddle;
		RaycastHit2D[] hits = Physics2D.RaycastAll(transform.parent.position, -Vector2.up);
		foreach(RaycastHit2D hit in hits){
			if(hit.collider != null){
				float distance = Mathf.Abs(hit.point.y - transform.parent.position.y);
				if(distance>0.1 ){
					gameObject.transform.localScale = new Vector3 (1, distance / (GetComponent<Renderer>().bounds.size.y/gameObject.transform.localScale.y), 1);
					gameObject.transform.position = transform.parent.position - Vector3.up * distance/2;
					if (hit.collider.gameObject.tag == "Puddle") {
						//Debug.DrawRay(hit.point, hit.normal, Color.green, 2, false);
						hit.collider.gameObject.GetComponent<Puddle>().addInFlow(flow);
						break;
					}
					else if (!hit.collider.isTrigger & (hit.collider.gameObject.tag =="Shelve" | hit.collider.gameObject.tag =="Floor")) {
						newPuddle = Instantiate (puddlePrefab);
						newPuddle.transform.position = (Vector3) hit.point;
						break;
					}
				}
			}
		}
	}
	/*
	private void OnCollisionEnter2D(Collision2D collider)
	{
		//Debug.Log ("!");
		if (collider.gameObject.tag == "Shelve" || collider.gameObject.tag == "Floor")
		{
			Debug.Log (collider.gameObject);
			initialShelves.Add(collider.gameObject);
		}
	}
	private void OnCollisionExit2D(Collision2D collider)
	{
		if (collider.gameObject.tag == "Shelve" || collider.gameObject.tag == "Floor")
		{
			initialShelves.Remove(collider.gameObject);
		}
	}
	*/
}
