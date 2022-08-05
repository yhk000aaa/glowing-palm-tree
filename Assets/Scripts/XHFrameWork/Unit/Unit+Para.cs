using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHurtParameters
{
    public Unit source;
    public Unit target;
    public float count;
}


public partial class Unit
{
    public virtual void hurt(UnitHurtParameters parameters, Unit sourceUnit = null)
    {
        this.skillManager.hurt(parameters, sourceUnit);

        // if(this.needStateMachine) {
        //     this.stateMachine.currentState.hurt(parameters, sourceUnit);
        // }
    }

    public virtual void cure(float count)
    {
        this.skillManager.cure(count);

        // if (this.needStateMachine) {
        //     this.stateMachine.currentState.cure(count);
        // }
    }
}
