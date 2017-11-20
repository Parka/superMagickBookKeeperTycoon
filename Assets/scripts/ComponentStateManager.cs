﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentStateManager : MonoBehaviour {

    protected Dictionary<Type, ComponentState> states = new Dictionary<Type, ComponentState>();

    [SerializeField]
    private ComponentState currentState;
	
    // Use this for initialization
	protected void Start () {
        // 
        foreach (ComponentState state in GetComponents<ComponentState>())
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
    public void ChangeStateTo(ComponentState state)
    {
        ChangeStateTo(state.GetType());
    }
    public void ChangeStateTo<T>() where T : ComponentState
    {
        ChangeStateTo(typeof(T));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
