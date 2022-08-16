using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CardObject
{
    void startAction()
    {

    }

    void stopAction()
    {

    }

    public virtual void triggerUseAction()
    {
        this.isOver = true;
    }
}

public class MoveCardObject : CardObject
{
    public override void triggerUseAction()
    {
        base.triggerUseAction();

        this.boatUnit.activeData.sailObj.setValue(boatUnit.activeData.sailObj.value + 1);

    }
}
public class SearchCardObject : CardObject
{
    public override void triggerUseAction()
    {
        base.triggerUseAction();
        
    }
}
public class LeaderCardObject : CardObject
{
    public override void triggerUseAction()
    {
        base.triggerUseAction();
        
    }
}
public class MaterialCardObject : CardObject
{
    public override void triggerUseAction()
    {
        base.triggerUseAction();
        
    }
}
