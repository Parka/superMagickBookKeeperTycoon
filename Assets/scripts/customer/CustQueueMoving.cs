using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustQueueMoving : ComponentState<CustStateManager>
{
    private Rigidbody2D rb;
    private bool hitCounter = false;
    private bool hitCust = false;
    [SerializeField]
    private Collider2D backCollider;
    [SerializeField]
    private Collider2D frontCollider;
    [SerializeField]
    private float moveForce = 5;

    // Use this for initialization
    void Start()
    {
        hitCounter = false;
        hitCust = false;
        rb = GetComponent<Rigidbody2D>();
        addCheck<CustCounter>(() =>
        {
            return hitCounter;
        });
        addCheck<CustQueueStopped>(() =>
        {
            return hitCust;
        });
		addCheck<CustLeave>(() =>
		{
			return stateManager.patienceLeft<0;
		});
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        rb.AddForce(Vector2.right * moveForce);
    }
    
    private void OnEnable()
    {
        hitCounter = false;
        hitCust = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Customer" && collider.IsTouching(frontCollider))
        {
            hitCust = true;
        }
        else if (collider.gameObject.tag == "Counter" && collider.IsTouching(frontCollider))
        {
            hitCounter = true;
        }
    }
}
