using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberDisplayObject
{
    public float value { get; private set; }
    public event Action onValueChangeAction;
    
    public NumberDisplayObject(float val)
    {
        this.setValue(val);
    }

    public void setValue(float val)
    {
        this.value = val;
        this.onValueChangeAction?.Invoke();
    }
    
    public void addValue(float val)
    {
        this.setValue(this.value + val);
    }
}
