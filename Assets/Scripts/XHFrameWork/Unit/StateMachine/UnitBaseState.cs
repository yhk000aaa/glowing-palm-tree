using System;
using System.Collections.Generic;
using UnityEngine;

public enum UnitStateStatus
{
    None, Prepare, Stay, Over
}

public partial class UnitBaseState : State
{
    public virtual bool needStatusObject => false;

    public virtual string nextStateType => string.Empty;

    UnitStateStatus _stateStatus;
    public UnitStateStatus stateStatus
    {
        get { return _stateStatus; }
        set {
            if (_stateStatus == value) {
                return;
            }
            _stateStatus = value;
            if (_stateStatus == UnitStateStatus.Stay) {
                this.runStateStayAction();
            }
        }
    }

    StatusObject _statusObject;
    public int baseStatus { get { return _statusObject.status; } set { _statusObject.status = value; } }
    public Dictionary<int, Action> statusActions => _statusObject.statusActions;
    public Dictionary<int, Action<float>> updateActions => _statusObject.updateActions;
    public Dictionary<int, Action> leaveActions => _statusObject.leaveActions;

    public override void Init(StateMachine machine)
    {
        base.Init(machine);

        if(this.needStatusObject) {
            _statusObject = new StatusObject();
        }
    }

    public override bool IsValidNextState(State nextState)
    {
        return nextState != null && this.validNextStates.Contains(nextState.stateType);
    }

    public override void DidEnter(State previousState)
    {
        this.LoadConfig();
        Debug.Log("DidEnter:" + this.stateType + ", previousState:" + (previousState == null ? "" : previousState.stateType));
        //准备
        this.statePrepare();
    }

    public override void Update(float dt)
    {
        base.Update(dt);

        if (this.needStatusObject) {
            _statusObject.update(dt);
        }
    }

    public override void WillExit(State nextState, bool disposed)
    {
        if (this.needStatusObject) {
            _statusObject.status = 0;
        }
        this.UnloadConfig();
        Debug.Log("WillExit:" + this.stateType);
    }

    public override void Dispose()
    {
        if (this.needStatusObject) {
            _statusObject.clearAction();
            _statusObject = null;
        }
        
        base.Dispose();
    }

    public virtual void LoadConfig() { }

    public virtual void UnloadConfig() { }

    protected void statePrepare()
    {
        this.stateStatus = UnitStateStatus.Prepare;
    }

    protected void stateOver()
    {
        this.stateStatus = UnitStateStatus.Stay;
    }

    protected bool isStateOver => this.stateStatus == UnitStateStatus.Over;
    
    protected virtual void runStateStayAction()
    {
        var nextType = this.nextStateType;
        UnityEngine.Debug.Log("stateType:" + this.stateType + ", nextStateType:" + nextType);
        if (nextType != string.Empty) {
            this.machine.TryEnter(nextType);
        }
        this.stateStatus = UnitStateStatus.Over;
    }
}
