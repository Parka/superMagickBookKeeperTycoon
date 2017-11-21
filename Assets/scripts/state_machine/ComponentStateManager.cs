using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentStateManager<TManager> : MonoBehaviour
    where TManager : ComponentStateManager<TManager>
{

    protected Dictionary<Type, ComponentState<TManager>> states = new Dictionary<Type, ComponentState<TManager>>();

    [SerializeField]
    private ComponentState<TManager> currentState;
	
    // Use this for initialization
	protected void Start () {
        // 
        foreach (ComponentState<TManager> state in GetComponents<ComponentState<TManager>>())
        {
            if (currentState == null)
                currentState = state;

            if (state != currentState)
                state.enabled = false;
            else
                state.enabled = true;

            states.Add(state.GetType(), state);
        };
	}

    public void ChangeStateTo(Type type)
    {
        Debug.Log(type);
        if(states[type] != null)
        {
            currentState.enabled = false;
            currentState = states[type];
            currentState.enabled = true;
        }
    }
    public void ChangeStateTo(ComponentState<TManager> state)
    {
        ChangeStateTo(state.GetType());
    }
    public void ChangeStateTo<T>() where T : ComponentState<TManager>
    {
        ChangeStateTo(typeof(T));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
