using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CardObject : BaseObject
{
    public CardInsData cardInsData;
    public BoatUnit boatUnit;
    public bool isOver { get; private set; }

    public override void init()
    {
        base.init();
        this.isOver = false;
    }

    public override void start()
    {
        base.start();
        this.startGameObject();
        this.startAction();
    }

    public override void stop()
    {
        this.stopAction();
        this.stopGameObject();
        base.stop();
    }
}
