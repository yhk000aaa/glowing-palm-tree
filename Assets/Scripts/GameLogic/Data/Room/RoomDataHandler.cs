using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDataHandler : SimpleConfigHandler<RoomConfigRoot, RoomDataHandler>
{
    public override string module => DataModule.Room;
}
