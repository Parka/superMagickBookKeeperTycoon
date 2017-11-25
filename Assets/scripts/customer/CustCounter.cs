using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustCounter : ComponentState<CustStateManager>
{
	[SerializeField]
	private float extraPatience = 3;
    // Use this for initialization
    void Start()
    {

        addCheck<CustLeave>(() =>
        {
            return stateManager.patienceLeft<0;
        });
    }
	private void OnEnable(){
		stateManager.patienceLeft += extraPatience; //When getting to the counter, you get some extra patience... 
	}
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
    }
}

