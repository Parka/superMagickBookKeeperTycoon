using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLadder : ComponentState {

    private Rigidbody2D rb;
    private Rigidbody2D lrb;
    [SerializeField]
    private float vel = 5;
    private bool isOnFloor = false;
    private float ladderVel;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        lrb = ((PlayerStateManager)stateManager).currentLadder.GetComponent<Rigidbody2D>();
        ladderVel = ((PlayerStateManager)stateManager).currentLadder.GetComponent<LadderManager>().vel;
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
        rb.gravityScale = 0;
        rb.velocity = vel * Input.GetAxis("Vertical") * Vector2.up;
        if (!isOnFloor)
        {
            lrb.velocity = ladderVel * Input.GetAxis("Horizontal") * Vector2.right;
            rb.velocity = rb.velocity + ladderVel * Input.GetAxis("Horizontal") * Vector2.right;
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Floor")
        {
            isOnFloor = true;
            if (lrb != null)
                lrb.velocity = Vector2.zero;
        }
    }
    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Floor")
            isOnFloor = false;
    }
}
