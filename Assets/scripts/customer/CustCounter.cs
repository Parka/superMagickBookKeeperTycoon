using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustCounter : ComponentState<CustStateManager>
{
    private Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Should add check for "leave"
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        rb.AddForce(Vector2.up * 11); //To be changed for something real
    }
}

