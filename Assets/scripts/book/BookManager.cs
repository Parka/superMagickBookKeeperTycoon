using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour {
	public enum BookType {
		Magic,
		Story,
		SelfHelp
		// ...
	}

	public enum BookTopic {
		Elements,
		BlackMagic,
		Vampires,
		Dating
		// ...
	}

	public Transform spawnPoint;
	public float spawnTime = 5f;
	public GameObject book;

	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	void Spawn() {
		Randomize (Instantiate (book, spawnPoint.position, spawnPoint.rotation));
	}

	public void Randomize(GameObject book) {
		SpriteRenderer sr = book.GetComponent<SpriteRenderer> ();
		BookInfo bi = book.GetComponent<BookInfo> ();

		sr.sprite =   Resources.Load<Sprite>(string.Format("img/book{0}", Random.Range((int)1,4)));
		sr.color = new Color (Random.value, Random.value, Random.value, 1.0f);

		bi.type = (BookManager.BookType)Random.Range(0, System.Enum.GetValues(typeof(BookManager.BookType)).Length);
		bi.topic = (BookManager.BookTopic)Random.Range(0, System.Enum.GetValues(typeof(BookManager.BookTopic)).Length);
		bi.bookName = bi.type.ToString () + "_" + bi.topic.ToString ();
	}
}
