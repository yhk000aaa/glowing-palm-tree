using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EducationNode
{
    public UnitManager unitManager { get; private set; }

    void startUnit()
    {
        this.unitManager = new UnitManager();
        this.unitManager.start();
    }

    void updateUnit(float dt)
    {
        this.unitManager.update(dt);
    }

    void stopUnit()
    {
        this.unitManager.stop();
    }
}
