using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XHFrameWork;

public partial class BattleObject
{
    private List<RoomBaseObject> roomObjectList;
    private RoomBaseObject currentRoomObject;
    private BoatUnit boatUnit;
    
    void initStatus()
    {
        this.roomObjectList = new List<RoomBaseObject>();
    }

    void startStatus()
    {
        //TODO:加载roomObject
        var obj1 = DataUtils.Instance.getActivator<SailRoomObject>("SailRoomObject");
        obj1.battleObject = this;
        obj1.init();
        var obj2 = DataUtils.Instance.getActivator<IslandRoomObject1>("IslandRoomObject1");
        obj2.battleObject = this;
        obj2.init();

        var obj3 = DataUtils.Instance.getActivator<SailRoomObject>("SailRoomObject");
        obj3.battleObject = this;
        obj3.init();

        var obj4 = DataUtils.Instance.getActivator<IslandRoomObject2>("IslandRoomObject2");
        obj4.battleObject = this;
        obj4.init();

        this.roomObjectList.Add(obj1);
        this.roomObjectList.Add(obj2);
        this.roomObjectList.Add(obj3);
        this.roomObjectList.Add(obj4);

        for (int i = 0; i < this.roomObjectList.Count; i++) {
            var o = this.roomObjectList[i];
            o.preRoomObject = this.roomObjectList.objectValue(i - 1);
            o.nextRoomObject = this.roomObjectList.objectValue(i + 1);
        }
        
        if (this.roomObjectList.Count == 0) {
            this.endBattle();
            return;
        }
        
        this.setCurrentRoomObject(this.roomObjectList[0]);

        var battleUI = UIManager.Instance.GetUI<BattleUI>(EnumUIType.BattleUI);
        this.boatUnit = this.mainNode.unitManager.createBoatUnit(battleUI, BoatDataHandler.Instance.configRoot.configList.getRandomOne());
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

    public void refreshBattleTitle(string desc)
    {
        var battleUI = UIManager.Instance.GetUI<BattleUI>(EnumUIType.BattleUI);
        var text = battleUI.transform.Find("topPanel").Find("titleLabel").GetComponent<Text>();
        text.text = desc;
    }
}
