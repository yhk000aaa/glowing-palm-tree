using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XHFrameWork;

public partial class EducationNode
{
    class EducationNodeStatus
    {
        public const int None = 0;
        public const int EducationScene = 1;
        public const int BattleScene = 2;
    }
    private StatusObject _statusObject;

    private int baseState
    {
        get => this._statusObject.status;
        set => this._statusObject.status = value;
    }
    protected Dictionary<int, Action> statusActions => _statusObject.statusActions;
    protected Dictionary<int, Action<float>> updateActions => _statusObject.updateActions;
    protected Dictionary<int, Action> leaveActions => _statusObject.leaveActions;

    private BattleObject battleObject;
    
    void startStatus()
    {
        this._statusObject = new StatusObject();
        this._statusObject.ignoreSameState = true;

        this.statusActions[EducationNodeStatus.EducationScene] = this.runEducationScene;

        this.statusActions[EducationNodeStatus.BattleScene] = this.runBattleScene;
        this.updateActions[EducationNodeStatus.BattleScene] = this.updateBattleScene;
        this.leaveActions[EducationNodeStatus.BattleScene] = this.leaveBattleScene;

        this.baseState = EducationNodeStatus.EducationScene;
    }

    void updateStatus(float dt)
    {
        this._statusObject.update(dt);
    }

    void stopStatus()
    {
        this._statusObject.clearStatus();
        this._statusObject.clearAction();
        this._statusObject = null;
    }

    void runEducationScene()
    {
        UIManager.Instance.OpenUICloseOthers(EnumUIType.StartUI);
    }

    void runBattleScene()
    {
        UIManager.Instance.OpenUICloseOthers(EnumUIType.BattleUI);
        this.battleObject = new BattleObject();
        this.battleObject.init();
        this.battleObject.start();
    }

    void updateBattleScene(float dt)
    {
        this.battleObject.update(dt);
    }

    void leaveBattleScene()
    {
        this.battleObject.stop();
        this.battleObject = null;
    }

    public void tryEnterBattle()
    {
        if (this.baseState == EducationNodeStatus.EducationScene) {
            this.baseState = EducationNodeStatus.BattleScene;
        }
    }
    
    public void tryEnterEducation()
    {
        if (this.baseState == EducationNodeStatus.BattleScene) {
            this.baseState = EducationNodeStatus.EducationScene;
        }
    }
}
