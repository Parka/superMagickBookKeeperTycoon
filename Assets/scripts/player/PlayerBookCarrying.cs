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
    private HashSet<GameObject> targetbooks = new HashSet<GameObject>();
    private GameObject carriedBook;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        targetBook = getClosestBook();
        targetBookText.text = (targetBook != null)?targetBook.GetComponent<BookInfo>().bookName:null;
        
            
        if (Input.GetButtonDown("Jump") ){
            if (carriedBook == null && targetBook != null)
            {
                carriedBook = targetBook;
                targetBook = null;
                carriedBook.transform.SetParent(gameObject.transform);
                carriedBook.transform.SetPositionAndRotation(bookGrabPosition.position, bookGrabPosition.rotation);
                carriedBook.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                carriedBook.GetComponent<SpriteRenderer>().sortingOrder = 4;
            }
            else if(carriedBook != null)
            {
                Vector2 oldPosition = carriedBook.transform.position;
                carriedBook.transform.SetParent(null);
                carriedBook.transform.position = oldPosition;
                carriedBook.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                carriedBook.GetComponent<SpriteRenderer>().sortingOrder = 1;
                carriedBook = null;
            }
        }
    }
    private GameObject getClosestBook()
    {
        float closestDistance = float.PositiveInfinity;
        float currentDistance;
        GameObject candidate = null;

        foreach (GameObject book in targetbooks)
        {
            if (book == carriedBook) continue;

            currentDistance = (bookGrabPosition.position - book.transform.position).sqrMagnitude;
            if (currentDistance<closestDistance)
            {
                closestDistance = currentDistance;
                candidate = book;
            }

        }
        return candidate;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Book" && collider.IsTouching(bookPlayerCollider))
        {
            targetbooks.Add(collider.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Book" && !collider.IsTouching(bookPlayerCollider))
        {
            targetbooks.Remove(collider.gameObject);
        }
    }
}
