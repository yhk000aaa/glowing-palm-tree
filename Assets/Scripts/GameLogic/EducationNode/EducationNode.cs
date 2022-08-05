using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XHFrameWork;

public partial class EducationNode
{
    public static EducationNode Instance;
    public Camera mainCamera { get; private set; }

    public void start()
    {
        EducationNode.Instance = this;
        this.mainCamera = Camera.main;
        UIManager.Instance.UICanvasTr = GameObject.Find("UICanvas").transform;

        this.startStatus();
        this.startData();
        this.startUnit();
    }

    public void update(float dt)
    {
        this.updateStatus(dt);
        this.updateData(dt);
        this.updateUnit(dt);
    }

    public void stop()
    {
        this.stopUnit();
        this.stopData();
        this.stopStatus();
        EducationNode.Instance = null;
    }
}
