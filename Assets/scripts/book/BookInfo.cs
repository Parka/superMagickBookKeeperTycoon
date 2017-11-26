using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BookInfo : MonoBehaviour {
	public BookManager.BookType type;
	public BookManager.BookTopic topic;
    public string bookName;
	private Collider2D collider;
	private bool onShelve = false;

	public double decaySpeed = 5;
	public double decay = 100;

	// Use this for initialization
	void Start () {
		collider = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!onShelve) {
			decay -= Time.deltaTime * decaySpeed;
		}
		if (decay <= 0) {
			Destroy (gameObject);
		}
	}

	private void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "InnerShelve")
		{
			onShelve = false;
		}
	}
	private void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "InnerShelve")
		{
			onShelve = true;
		}
	}
}
