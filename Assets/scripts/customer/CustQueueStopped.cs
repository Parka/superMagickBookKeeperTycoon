using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CustQueueStopped : ComponentState<CustStateManager>
{
    private Rigidbody2D rb;
    private bool queueClear = false;
    [SerializeField]
    private Collider2D frontCollider;

    // Use this for initialization
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        addCheck<CustQueueMoving>(() =>
        {
            return queueClear;
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
        rb.velocity = Vector2.zero;
    }

    private void OnEnable()
    {
        queueClear = false;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
       
        if (collider.gameObject.tag == "Customer" && !collider.IsTouching(frontCollider))
        {
            queueClear = true;
        }
        //queueClear = true;
    }
}
