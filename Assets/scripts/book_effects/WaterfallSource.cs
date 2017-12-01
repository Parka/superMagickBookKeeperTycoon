using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterfallSource : MonoBehaviour {

	private HashSet<GameObject> initialShelves = new HashSet<GameObject>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log (collider.gameObject);
		if (collider.gameObject.tag == "Shelve" || collider.gameObject.tag == "Floor")
		{
			Debug.Log (collider.gameObject);
			initialShelves.Add(collider.gameObject);
		}
	}
	private void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Shelve" || collider.gameObject.tag == "Floor")
		{
			initialShelves.Remove(collider.gameObject);
		}
	}
}
