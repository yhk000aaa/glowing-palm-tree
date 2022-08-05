using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class State : NSObject
{
    public StateMachine machine { get; private set; }
    public Unit unit => this.machine.unit;
    public UnitManager unitMgr => this.unit.unitMgr;
    public EducationData mainData => this.unit.mainData;
    public EducationNode mainNode => this.unit.mainNode;
    public virtual string stateType => string.Empty;
    public virtual string sourceStateType => string.Empty;
    public HashSet<string> validNextStates { get; private set; }
    public HashSet<string> unvalidNextStates { get; private set; }

    public virtual void Init(StateMachine machine)
    {
        this.machine = machine;
        this.validNextStates = new HashSet<string>();
        this.unvalidNextStates = new HashSet<string>();
    }

    public virtual bool IsValidNextState(State nextState)
    {
        return this.validNextStates.Contains(nextState.stateType);
    }

    public virtual bool IsValidNextStateWhenNext(State nextState)
    {
        return this.IsValidNextState(nextState);
    }

    public virtual void DidEnter(State previousState)
    {
    }

    public virtual void Update(float dt) { }

    public virtual void WillExit(State nextState, bool disposed)
    {
    }

    public virtual void Dispose() { }
}