using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatConfig : NSConfigObject
{
    public string name { get; private set; }
    public float leader { get; private set; }
    public float operate { get; private set; }
    public float cook { get; private set; }
    public float surf { get; private set; }
    public float guide { get; private set; }

    public float walter { get; private set; }

    public override void initializeByParameters(Dictionary<string, object> parameters)
    {
        base.initializeByParameters(parameters);
        this.name = parameters.stringValue("name");
        this.leader = parameters.floatValue("leader");
        this.operate = parameters.floatValue("operate");
        this.cook = parameters.floatValue("cook");
        this.surf = parameters.floatValue("surf");
        this.guide = parameters.floatValue("guide");
        this.walter = parameters.floatValue("walter");
    }
}