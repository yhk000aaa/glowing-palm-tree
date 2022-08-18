using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroSailEventObject : EventObject
{
    public override void start()
    {
        base.start();
        
        //水-1
        this.boatUnit.activeData.walterObj.addValue(-this.eventConfig.value);
        //导航能力归零
        
        Debug.LogError(string.Format("水-{0}, 导航能力归0", this.eventConfig.value));
        this.stateOver();
    }
}
