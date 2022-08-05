using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public Unit unit;

    public event Action<State> changeStateEvent;

    List<State> _states;
    State _currentState;
    State _nextState;
    string _initType;
    
    public StateMachine()
    {
        _states = new List<State>();
    }
    
    public virtual void Reload(string[] stateTypes, string initType)
    {
        _states.Clear();

        foreach (var item in stateTypes)
        {
            State state = DataUtils.Instance.getObject<State>(item);
            state.Init(this);
            _states.Add(state);
        }

        this._initType = initType;
    }
    
    public T GetInitState<T>() where T : State
    {
        return GetState<T>(_initType);
    }

    public T GetState<T>(string type) where T : State
    {
        State state = _states.Find(x => x.stateType == type);
        return state == null ? null : state as T;
    }
    
    public void Begin(State state = null)
    {
        if (state == null)
        {
            state = GetInitState<State>();
        }
        Enter(state.stateType);
    }

    public bool TryEnter(string stateType)
    {

        if (this.CanEnterState(stateType))
        {
            this.Enter(stateType);
            return true;
        }
        return false;
    }
    
    public bool CanEnterState(string stateType)
    {
        if (this._nextState != null)
        {
            var ret = this._nextState.IsValidNextStateWhenNext(GetState<State>(stateType));
            return ret;
        }
        if (this._currentState != null)
        {
            var ret = this._currentState.IsValidNextState(GetState<State>(stateType));
            return ret;
        }
        return true;
    }

    
    public void Enter(string stateType)
    {
        this._nextState = this.GetState<State>(stateType);

        if (this._currentState == null)
        {
            this.EnterImmediately();
        }
    }
    
    void EnterImmediately()
    {
        if (this._currentState != null)
        {
            this._currentState.WillExit(this._nextState, false);
        }
        State previousState = this._currentState;
        this._currentState = this._nextState;
        this._nextState = null;
        if (this._currentState != null)
        {
            this._currentState.DidEnter(previousState);
        }
        this.changeStateEvent?.Invoke(this._currentState);
    }
    
    public void Update(float dt)
    {
        this.UpdateCurrentState(dt);
    }
    
    void UpdateCurrentState(float dt)
    {
        if (this._currentState == null)
        {
            return;
        }
        this._currentState.Update(dt);
    }

    public void End(bool disposed = true)
    {
        if (this._currentState != null)
        {
            this._currentState.WillExit(null, disposed);
            this._currentState = null;
        }
        this._nextState = null;
        foreach (var item in this._states)
        {
            item.Dispose();
        }
        this.unit = null;
        this.changeStateEvent = null;
    }
}
