using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentState : MonoBehaviour {

    public ComponentStateManager stateManager;
    protected Dictionary<Func<bool>,Type> checks = new Dictionary<Func<bool>, Type>();

    private void Awake()
    {
        if(stateManager == null)
            stateManager = GetComponent<ComponentStateManager>();    
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        foreach (Func<bool> func in checks.Keys)
        {
            if (func())
                ChangeStateTo(checks[func]);
        }
	}

    protected void addCheck(Func<bool> func, Type type)
    {
        checks.Add(func, type);
    }
    protected void addCheck<T>(Func<bool> func) where T : ComponentState
    {
        checks.Add(func, typeof(T));
    }
    protected void ChangeStateTo(ComponentState state)
    {
        if (stateManager != null)
            stateManager.ChangeStateTo(state);
    }
    protected void ChangeStateTo(Type type)
    {
        if (stateManager != null)
            stateManager.ChangeStateTo(type);
    }
    protected void ChangeStateTo<T>() where T : ComponentState
    {
        if (stateManager != null)
            stateManager.ChangeStateTo<T>();
    }
}
