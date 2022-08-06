using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailRoomObject : RoomBaseObject
{
    class SailRoomObjectStatus
    {
        public const int None = 0;
        //行动阶段
        public const int ActionRound = 1;
        //结算结算
        public const int Calculate = 2;
        //事件触发
        public const int Event = 3;
        
        public const int Over = 4;
    }

    private int maxStep => 3;
    private int currentStep;

    private float delay;
    private float currentDelay;
    
    protected override bool needStateObject => true;

    public override void init()
    {
        base.init();
        
        this.statusActions[SailRoomObjectStatus.ActionRound] = this.runActionRound;
        this.leaveActions[SailRoomObjectStatus.ActionRound] = this.leaveActionRound;

        this.statusActions[SailRoomObjectStatus.Calculate] = this.runCalculate;
        this.updateActions[SailRoomObjectStatus.Calculate] = this.updateCalculate;

        this.statusActions[SailRoomObjectStatus.Event] = this.runEvent;
        this.leaveActions[SailRoomObjectStatus.Event] = this.leaveEvent;

        this.statusActions[SailRoomObjectStatus.Over] = this.runOver;
    }

    public override void enter()
    {
        base.enter();

        Debug.LogWarning("进入海洋");
        this.battleObject.battleUI.transform.Find("Hand").gameObject.SetActive(true);
        this.baseState = SailRoomObjectStatus.ActionRound;
    }

    public override void exit()
    {
        this.battleObject.battleUI.transform.Find("Hand").gameObject.SetActive(false);
        Debug.LogWarning("离开海洋");
        base.exit();
    }

    void runActionRound()
    {
        //TODO:回合开始，抽卡
        Debug.LogWarning("行动回合开始，抽卡");
        this.delay = 1;
        this.currentDelay = 0;
        this.battleObject.battleUI.endRoundBtn.onClick.AddListener(this.clickEndBtnEvent);
    }
    
    void leaveActionRound()
    {
        this.battleObject.battleUI.endRoundBtn.onClick.RemoveListener(this.clickEndBtnEvent);
    }

    void runCalculate()
    {
        //TODO:结算，前进
        Debug.LogWarning("结算，前进");
        this.currentStep++;
        
        this.delay = 1;
        this.currentDelay = 0;
    }

    void updateCalculate(float dt)
    {
        this.currentDelay += dt;
        if (this.currentDelay > this.delay) {
            this.currentDelay = 0;
            this.baseState = SailRoomObjectStatus.Event;
        }
    }

    void runEvent()
    {
        //TODO:事件触发
        Debug.LogWarning("事件触发");
        this.battleObject.battleUI.endRoundBtn.onClick.AddListener(this.clickEndBtnEvent);
    }

    void leaveEvent()
    {
        this.battleObject.battleUI.endRoundBtn.onClick.RemoveListener(this.clickEndBtnEvent);
    }
    
    void runOver()
    {
        this.moveToNextRoom();
    }

    void tryMoveNextRound()
    {
        if (this.baseState != SailRoomObjectStatus.Event) {
            return;
        }
        //如果步数大于最大步数，则进入下一个Room
        if (this.currentStep >= this.maxStep) {
            this.baseState = SailRoomObjectStatus.Over;
            return;
        }
        
        this.baseState = SailRoomObjectStatus.ActionRound;
    }

    void clickEndBtnEvent()
    {
        if (this.baseState == SailRoomObjectStatus.ActionRound) {
            this.baseState = SailRoomObjectStatus.Calculate;
        }
        else if (this.baseState == SailRoomObjectStatus.Event) {
            this.tryMoveNextRound();
        }
    }
}
