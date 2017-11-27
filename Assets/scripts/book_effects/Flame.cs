using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour {
	[SerializeField]
	private Collider2D colliderPropagateNear;
	[SerializeField]
	private Collider2D colliderPropagateFar;

	[SerializeField]
	private int propagateFarChances = 10; //Note: The larger the number the lower the odds (i.e.: 1 in chances)
	[SerializeField]
	private int propagateNearChances = 5;

	private double timeLeft = 0.5;

	private HashSet<GameObject> targetBooksNear = new HashSet<GameObject>();
	private HashSet<GameObject> targetBooksFar = new HashSet<GameObject>();
	private GameObject affectedBook;

	public double decaySpeed = 5;
	public double decay = 100;
	public double burnIntensity = 1;

	// Use this for initialization
	void Start () {
		affectedBook = transform.parent.gameObject;
	}

	// Update is called once per frame
	void Update () {

		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0) {
			//"Randomly" propagate to nearby books
			propagate (targetBooksNear, propagateNearChances);
			propagate (targetBooksFar, propagateFarChances);
			timeLeft = 0.5;
		}

		//Flame decay
		decay -= Time.deltaTime * decaySpeed;
		if (decay <= 0) {
			Destroy (gameObject);
		}

		//Ruin book
		affectedBook.GetComponent<BookInfo>().decay -= Time.deltaTime*burnIntensity;
	}

	private void propagate(HashSet<GameObject> targetBooks, int chances){
		GameObject cloneFlame;
		foreach (GameObject book in targetBooks) {
			if (book == affectedBook)
				continue;
			if (book.GetComponentsInChildren<Flame> ().GetLength(0)==0) {
				int dice = Random.Range ((int)0, chances);
				if (dice == 0) {
					cloneFlame = Instantiate (gameObject);
					cloneFlame.transform.SetParent (book.transform);
					cloneFlame.transform.position = book.transform.position;
					if (cloneFlame.GetComponent<Flame> ().decay < 90)
						cloneFlame.GetComponent<Flame> ().decay += 10;

				}
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Book" && collider.IsTouching(colliderPropagateNear))
		{
			targetBooksNear.Add(collider.gameObject);
		}
		if (collider.gameObject.tag == "Book" && collider.IsTouching(colliderPropagateFar))
		{
			targetBooksFar.Add(collider.gameObject);
		}
	}
	private void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Book" && !collider.IsTouching(colliderPropagateNear))
		{
			targetBooksNear.Remove(collider.gameObject);
		}
		if (collider.gameObject.tag == "Book" && !collider.IsTouching(colliderPropagateFar))
		{
			targetBooksFar.Remove(collider.gameObject);
		}
	}

	private void LateUpdate(){
		transform.rotation = Quaternion.Euler (0, 0, 0);
	}

}
