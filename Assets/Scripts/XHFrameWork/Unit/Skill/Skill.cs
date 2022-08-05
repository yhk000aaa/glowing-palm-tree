using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Skill : NSObject
{
    public Dictionary<string, object> currentConfig { get; protected set; }
    public string name;
    public int nameHashCode;

    public Unit unit;
    public bool isOver;
    public virtual string tag => Skill.None;
    public UnitManager unitMgr { get { return this.unit.unitMgr; } }
    public EducationData mainData { get { return this.unit.mainData; } }
    public EducationNode mainNode { get { return this.unit.mainNode; } }
    
    public override void initialize(Dictionary<string, object> parameters)
    {
        this.currentConfig = parameters;
        this.unit = null;
        this.name = this.GetType().Name;
        this.nameHashCode = this.name.GetHashCode();
    }
    
    public virtual void startWithUnit(Unit unit)
    {
        this.unit = unit;
        this.isOver = false;
    }

    public virtual void update(float dt)
    {
    }

    public virtual void stop()
    {
        this.unit = null;
    }
}
