using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EducationData
{
    public EducationNode educationNode;

    public BoatConfigRoot boatConfigRoot => BoatDataHandler.Instance.configRoot;
    public CardConfigRoot cardConfigRoot => CardDataHandler.Instance.configRoot;
    public RoomConfigRoot roomConfigRoot => RoomDataHandler.Instance.configRoot;

    public void start()
    {
    }

    public void update(float dt)
    {
    }

    public void stop()
    {
    }
}
