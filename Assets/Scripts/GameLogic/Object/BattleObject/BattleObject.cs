using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject
{
    public EducationNode mainNode { get; private set; }
    private StatusObject _statusObject;

    protected int baseState
    {
        get => this._statusObject.status;
        set => this._statusObject.status = value;
    }
    protected Dictionary<int, Action> statusActions => _statusObject.statusActions;
    protected Dictionary<int, Action<float>> updateActions => _statusObject.updateActions;
    protected Dictionary<int, Action> leaveActions => _statusObject.leaveActions;
    protected virtual bool needStateObject => false;
    
    public virtual void init()
    {
        this.mainNode = EducationNode.Instance;
        if (needStateObject) {
            this._statusObject = new StatusObject();
        }
    }

    public virtual void start()
    {
    }

    public virtual void update(float dt)
    {
        if (this.needStateObject) {
            this._statusObject.update(dt);
        }
    }

    public virtual void stop()
    {
        if (this.needStateObject) {
            this._statusObject.clearStatus();
            this._statusObject.clearAction();
            this._statusObject = null;
        }
    }
}

public partial class BattleObject :BaseObject
{
    public override void init()
    {
        base.init();
        this.initStatus();
    }

    public override void start()
    {
        base.start();
        this.startStatus();
    }

    public override void update(float dt)
    {
        base.update(dt);
        this.updateStatus(dt);
    }

    public override void stop()
    {
        this.stopStatus();
        base.stop();
    }
}
