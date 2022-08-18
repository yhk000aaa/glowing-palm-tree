using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSailToMaterialEventObject : EventObject
{
    public override void start()
    {
        base.start();
        
        //航向点-
        (this.roomObject as SailRoomObject)?.addCurrentStep(-this.eventConfig.value);
        //材料+
        this.boatUnit.activeData.materialObj.addValue(this.eventConfig.value);
        Debug.LogError(string.Format("航向点-{0}, 材料+{1}", this.eventConfig.value, this.eventConfig.value));
        this.stateOver();
    }
}
