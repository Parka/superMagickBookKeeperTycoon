using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloor : ComponentState {

    private Rigidbody2D rb;
    [SerializeField]
    private int vel = 5;
    private GameObject currentLadder;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        addCheck<PlayerLadder>(() =>
        {
            return Input.GetAxis("Vertical") > 0 && currentLadder != null;
        });

    }
    private void OnEnable()
    {
        if(rb != null)
            rb.gravityScale = 1;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        rb.velocity = Vector2.Scale(rb.velocity,Vector2.up) + vel * Input.GetAxis("Horizontal") * Vector2.right;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ladder")
            currentLadder = collider.gameObject;
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ladder")
            currentLadder = null;
    }
}
