using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Unit
{
    protected Dictionary<string, object> _config;
    public GameObject gameObject;
    public UnitManager unitMgr { get; private set; }
    public EducationData mainData { get; private set; }
    public EducationNode mainNode { get; private set; }
    public virtual Transform parent => null;
    /// <summary>
    /// 已经执行了stop
    /// </summary>
    public bool isOver { get; private set; }

    //等待执行stop
    public bool deleteLater;
    
    protected virtual bool needStatusObject => false;
    protected StatusObject _statusObject;
    protected int baseState
    {
        get => _statusObject.status;
        set
        {
            if (this._statusObject == null) {
                Debug.LogError("status赋值时已被释放" + this.GetType().toString());
                return;
            }
            _statusObject.status = value;
        }
    }
    protected Dictionary<int, Action> statusActions => _statusObject.statusActions;
    protected Dictionary<int, Action<float>> updateActions => _statusObject.updateActions;
    protected Dictionary<int, Action> leaveActions => _statusObject.leaveActions;
    
    public SkillManager skillManager { get; private set; }
    public StateMachine stateMachine { get; private set; }
    public virtual bool needStateMachine => false;
    
    public void start(Dictionary<string, object> para)
    {
        this._config = para;
        this.isOver = false;
        this.deleteLater = false;
        this.mainNode = EducationNode.Instance;
        this.mainData = this.mainNode.mainData;
        this.unitMgr = this.mainNode.unitManager;

        if (this.needStatusObject) {
            this._statusObject = new StatusObject();
        }

        this.popPrepare();
        this.popObject();
        this.popExtra();
    }

    public virtual void update(float dt)
    {
        if (this.needStatusObject) {
            this._statusObject.update(dt);
        }
        
        if(this.needStateMachine) {
            this.stateMachine.Update(dt);
        }
        
        this.skillManager.update(dt);
    }

    public void stop()
    {
        this.pushExtra();
        this.pushObject();
        this.pushOver();
        if (this.needStatusObject) {
            this._statusObject?.clearStatus();
            this._statusObject?.clearAction();
            this._statusObject = null;
        }
        this.isOver = true;
    }

    protected virtual void popPrepare()
    {
    }

    protected virtual void pushOver()
    {
    }

    protected virtual void popObject()
    {
    }

    protected virtual void pushObject()
    {
    }

    protected virtual void popExtra()
    {
        this.popMove();
        this.popContact();
        this.skillManager = new SkillManager();
        this.skillManager.unit = this;
        this.skillManager.start();

        if(this.needStateMachine) {
            this.stateMachine = new StateMachine();
            this.stateMachine.unit = this;
        }
    }
    
    protected virtual void pushExtra()
    {
        if (this.needStateMachine) {
            this.stateMachine.End();
        }
        
        this.skillManager.stop();
        this.pushContact();
        this.pushMove();
    }

    public void deleteDirty()
    {
        this.deleteLater = true;
    }
}
