using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatDataHandler : SimpleConfigHandler<BoatConfigRoot, BoatDataHandler>
{
    public override string module => DataModule.Boat;
}
