using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObject : BaseObject
{
    public EventConfig eventConfig;
    public bool isOver { get; private set; }

    protected void stateOver()
    {
        this.isOver = true;
    }
}

public class EmptyEventObject : EventObject
{
    public override void start()
    {
        base.start();
        this.stateOver();
    }
}