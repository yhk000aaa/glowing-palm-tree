using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//淡水岛
public class IslandRoomObject1 : RoomBaseObject
{
    class IslandRoomObject1Status
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
        
        this.statusActions[IslandRoomObject1Status.ActionRound] = this.runActionRound;
        this.updateActions[IslandRoomObject1Status.ActionRound] = this.updateActionRound;

        this.statusActions[IslandRoomObject1Status.Over] = this.runOver;
    }

    public override void enter()
    {
        base.enter();
        Debug.LogWarning("进入淡水岛");

        this.baseState = IslandRoomObject1Status.ActionRound;
    }

    public override void exit()
    {
        Debug.LogWarning("离开淡水岛");
        base.exit();
    }

    void runActionRound()
    {
        Debug.LogWarning("抽卡，补充淡水");
        this.delay = 1;
        this.currentDelay = 0;
    }

    void updateActionRound(float dt)
    {
        this.currentDelay += dt;
        if (this.currentDelay > this.delay) {
            this.currentDelay = 0;
            this.baseState = IslandRoomObject1Status.Over;
        }
    }

    void runOver()
    {
        this.moveToNextRoom();
    }
}
