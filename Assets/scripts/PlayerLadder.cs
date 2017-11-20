using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLadder : ComponentState {

    private Rigidbody2D rb;
    [SerializeField]
    private int vel = 5;
    private bool isOnFloor = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        
        addCheck<PlayerFloor>(() =>
        {
            return Input.GetAxis("Vertical") < 0 && isOnFloor;
        });
	}
	
    private void OnEnable()
    {
        if(rb != null)
            rb.gravityScale = 0;
    }

	// Update is called once per frame
	protected override void Update ()
    {
        base.Update();
        rb.velocity = vel * Input.GetAxis("Vertical") * Vector2.up;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Floor")
            isOnFloor = true;
    }
    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Floor")
            isOnFloor = false;
    }
}
