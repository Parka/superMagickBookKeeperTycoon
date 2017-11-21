using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloor : ComponentState<PlayerStateManager> {

    private Rigidbody2D rb;
    [SerializeField]
    private float vel = 5;
    [SerializeField]
    private Collider2D ladderPlayerCollider;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        addCheck<PlayerLadder>(() =>
        {
            return Input.GetAxis("Vertical") > 0 && stateManager.currentLadder != null;
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
        rb.gravityScale = 1;
        rb.velocity = Vector2.Scale(rb.velocity,Vector2.up) + vel * Input.GetAxis("Horizontal") * Vector2.right;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ladder" && collider.IsTouching(ladderPlayerCollider))
            stateManager.currentLadder = collider.gameObject;
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ladder")
            stateManager.currentLadder = null;
    }
}
