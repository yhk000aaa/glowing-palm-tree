using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BoatUnit
{
    private List<CardObject> cardObjectList;

    void startCards()
    {
        for (int i = 0; i < 3; i++) {
            var cardConfig = CardDataHandler.Instance.configRoot.configList.getRandomOne();
            var insData = DataUtils.Instance.getActivator<CardInsData>("CardInsData");
            insData.reloadData(null, cardConfig);
            this.addCardObject(insData);
        }
    }

    void updateCards(float dt)
    {
        foreach (var o in this.cardObjectList) {
            if (o.isOver) {
                o.stop();
            }
            else {
                o.update(dt);
            }
        }

        this.cardObjectList.RemoveAll(x => x.isOver);
    }

    void stopCards()
    {
    }

    public void addCardObject(CardInsData cardInsData)
    {
        var obj = DataUtils.Instance.getActivator<CardObject>("CardObject");
        obj.cardInsData = cardInsData;
        obj.boatUnit = this;
        obj.start();
        this.cardObjectList.Add(obj);
    }
}
