using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBaseObject : BaseObject
{
    public RoomBaseObject preRoomObject;
    public RoomBaseObject nextRoomObject;
    public RoomConfig roomConfig;

    public BattleObject battleObject;
    
    public virtual void enter()
    {
    }

    public virtual void exit()
    {
    }

    public void moveToNextRoom()
    {
        this.battleObject.setCurrentRoomObject(this.nextRoomObject);
    }
}
