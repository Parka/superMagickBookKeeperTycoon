using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustStateManager : ComponentStateManager<CustStateManager>
{

    public float patience = 30;
    public float patienceLeft;


    // Use this for initialization
    new void Start()
    {
        patienceLeft = patience;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        patienceLeft -= Time.deltaTime;
    }
}
