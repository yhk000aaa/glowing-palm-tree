using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//非淡水岛
public class IslandRoomObject2 : RoomBaseObject
{
    class IslandRoomObject2Status
    {
        public const int None = 0;
        //行动阶段
        public const int ActionRound = 1;

        public const int Over = 2;
    }

    private float delay;
    private float currentDelay;
    
    protected override bool needStateObject => true;
    
    public override void init()
    {
        base.init();
        
        this.statusActions[IslandRoomObject2Status.ActionRound] = this.runActionRound;
        this.updateActions[IslandRoomObject2Status.ActionRound] = this.updateActionRound;
        this.leaveActions[IslandRoomObject2Status.ActionRound] = this.leaveActionRound;

        this.statusActions[IslandRoomObject2Status.Over] = this.runOver;
    }

    public override void enter()
    {
        base.enter();

        Debug.LogWarning("进入非淡水岛");

        this.baseState = IslandRoomObject2Status.ActionRound;
    }

    public override void exit()
    {
        Debug.LogWarning("离开非淡水岛");
        base.exit();
    }

    void runActionRound()
    {
        Debug.LogWarning("抽卡，获得材料");

        this.delay = 1;
        this.currentDelay = 0;
    }

    void updateActionRound(float dt)
    {
        this.currentDelay += dt;
        if (this.currentDelay > this.delay) {
            this.currentDelay = 0;
            this.baseState = IslandRoomObject2Status.Over;
        }
    }

    void leaveActionRound()
    {
    }

    void runOver()
    {
        this.moveToNextRoom();
    }
}
