using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class State
{
    public virtual void hurt(UnitHurtParameters parameters, Unit sourceUnit = null)
    {
    }

    public virtual void cure(float count)
    {
    }
}