using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBookCarrying : MonoBehaviour {

    [SerializeField]
    private Collider2D bookPlayerCollider;
    [SerializeField]
    private Text targetBookText; //This is to be changed for something more general
    [SerializeField]
    private Transform bookGrabPosition;

    private GameObject targetBook;
    private GameObject carryedBook;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump") ){
            if (carryedBook == null && targetBook != null)
            {
                carryedBook = targetBook;
                targetBook = null;
                carryedBook.transform.SetParent(gameObject.transform);
                carryedBook.transform.SetPositionAndRotation(bookGrabPosition.position, bookGrabPosition.rotation);
                carryedBook.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                carryedBook.GetComponent<SpriteRenderer>().sortingOrder = 4;
            }
            else if(carryedBook != null)
            {
                Vector2 oldPosition = carryedBook.transform.position;
                carryedBook.transform.SetParent(null);
                carryedBook.transform.position = oldPosition;
                carryedBook.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                carryedBook.GetComponent<SpriteRenderer>().sortingOrder = 1;
                carryedBook = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Book" && collider.IsTouching(bookPlayerCollider) && carryedBook == null)
        {
            targetBook = collider.gameObject;
            targetBookText.text = targetBook.GetComponent<BookInfo>().bookName;
            
            Debug.Log("BOOK");
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Book" && !collider.IsTouching(bookPlayerCollider) && targetBook == collider.gameObject && carryedBook == null)
        {
            targetBook = null;
            targetBookText.text = "NO BOOK";
            Debug.Log("NO MORE BOOK");
        }
    }
}
