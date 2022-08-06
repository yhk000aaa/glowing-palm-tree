using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDataHandler : SimpleConfigHandler<EventConfigRoot, EventDataHandler>
{
    public override string module => DataModule.Event;
}
