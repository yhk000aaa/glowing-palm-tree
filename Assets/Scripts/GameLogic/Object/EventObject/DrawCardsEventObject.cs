using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardsEventObject : EventObject
{
    public override void start()
    {
        base.start();

        for (int i = 0; i < this.eventConfig.value; i++) {
            this.boatUnit.addCardObject();
        }
        
        Debug.LogError(string.Format("抽{0}张卡", this.eventConfig.value));
        
        this.stateOver();
    }
}
