using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EducationNode
{
    public EducationData mainData { get; private set; }

    void startData()
    {
        this.mainData = new EducationData();
        this.mainData.educationNode = this;
        this.mainData.start();
    }

    void updateData(float dt)
    {
        this.mainData.update(dt);
    }

    void stopData()
    {
        this.mainData.stop();
    }
}
