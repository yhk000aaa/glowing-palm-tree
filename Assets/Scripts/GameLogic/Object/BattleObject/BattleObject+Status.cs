using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XHFrameWork;

public partial class BattleObject
{
    private List<RoomBaseObject> roomObjectList;
    private RoomBaseObject currentRoomObject;
    public BoatUnit boatUnit { get; private set; }

    void initStatus()
    {
        this.roomObjectList = new List<RoomBaseObject>();
    }

    void startStatus()
    {
        //TODO:加载roomObject

        foreach (var roomConfig in this.mainNode.mainData.roomConfigRoot.configList) {
            var obj = DataUtils.Instance.getActivator<RoomBaseObject>(roomConfig.objectClassName);
            obj.battleObject = this;
            obj.roomConfig = roomConfig;
            this.roomObjectList.Add(obj);
        }

        for (int i = 0; i < this.roomObjectList.Count; i++) {
            var o = this.roomObjectList[i];
            o.preRoomObject = this.roomObjectList.objectValue(i - 1);
            o.nextRoomObject = this.roomObjectList.objectValue(i + 1);
        }
        
        if (this.roomObjectList.Count == 0) {
            this.endBattle();
            return;
        }
        
        this.boatUnit = this.mainNode.unitManager.createBoatUnit(battleUI, BoatDataHandler.Instance.configRoot.configList.getRandomOne());

        this.setCurrentRoomObject(this.roomObjectList[0]);
    }

    void updateStatus(float dt)
    {
        this.currentRoomObject?.update(dt);
    }

    void stopStatus()
    {
        this.roomObjectList.Clear();
    }

    public void setCurrentRoomObject(RoomBaseObject roomBaseObject)
    {
        this.currentRoomObject?.exit();
        this.currentRoomObject = roomBaseObject;
        this.currentRoomObject?.enter();
        if (this.currentRoomObject == null) {
            this.endBattle();
        }
    }

    private void endBattle()
    {
        this.mainNode.tryEnterEducation();
    }
}
