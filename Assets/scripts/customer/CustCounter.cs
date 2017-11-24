using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustCounter : ComponentState<CustStateManager>
{
    // Use this for initialization
    void Start()
    {

        addCheck<CustLeave>(() =>
        {
            return stateManager.patienceLeft<0;
        });
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
    }
}

