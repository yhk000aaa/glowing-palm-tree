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
