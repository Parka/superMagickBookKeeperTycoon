using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager: ComponentStateManager<PlayerStateManager>
{

    public GameObject currentLadder;

    // Use this for initialization
    new void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localScale = Vector2.up + Vector2.right;
        if (Input.GetAxis("Horizontal") < 0)
            transform.localScale = Vector2.up + Vector2.left;
    }
}
