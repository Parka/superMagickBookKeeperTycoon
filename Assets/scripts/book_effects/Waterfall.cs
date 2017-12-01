using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfall : MonoBehaviour {

	//private HashSet<GameObject> initialShelves = new HashSet<GameObject>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		RaycastHit2D[] hits = Physics2D.RaycastAll(transform.parent.position, -Vector2.up);
		foreach(RaycastHit2D hit in hits){
			if (hit.collider != null & !hit.collider.isTrigger & (hit.collider.gameObject.tag =="Shelve" | hit.collider.gameObject.tag =="Floor")) {
				//if(!initialShelves.Contains(hit.collider.gameObject)){
					float distance = Mathf.Abs(hit.point.y - transform.parent.position.y);
					//Debug.DrawRay(hit.point, hit.normal, Color.green, 2, false);
					//Debug.Log (initialShelves);
					if(distance>0){
						gameObject.transform.localScale = new Vector3 (1, distance / (GetComponent<Renderer>().bounds.size.y/gameObject.transform.localScale.y), 1);
						gameObject.transform.position = transform.parent.position - Vector3.up * distance/2;
					}
					break;
				//}
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
