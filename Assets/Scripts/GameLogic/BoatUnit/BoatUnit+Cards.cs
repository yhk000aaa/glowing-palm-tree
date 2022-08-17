using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BoatUnit
{
    public List<CardObject> cardObjectList { get; private set; }

    public int maxCardCount => 5;
    
    void startCards()
    {
 
    }

    void updateCards(float dt)
    {
        foreach (var o in this.cardObjectList)
        {
            if (o.isOver)
            {
                o.stop();
            }
            else
            {
                o.update(dt);
            }
        }

        this.cardObjectList.RemoveAll(x => x.isOver);
    }

    void stopCards()
    {
        foreach (var o in this.cardObjectList)
        {
            o.stop();
        }
        this.cardObjectList.Clear();
    }

    public void addCardObject(CardConfig cardConfig)
    {
        var insData = DataUtils.Instance.getActivator<CardInsData>("CardInsData");
        insData.reloadData(null, cardConfig);
        var obj = DataUtils.Instance.getActivator<CardObject>(insData.config.cardObjectClassName);
        obj.cardInsData = insData;
        obj.boatUnit = this;
        obj.start();
        this.cardObjectList.Add(obj);
    }

    public void addCardObject()
    {
        var cardConfig = CardDataHandler.Instance.configRoot.configList.FindAll(x=>x.cardType != CardType.Food).getRandomOne();
        this.addCardObject(cardConfig);
    }
    
    public void fillCardUntilFull()
    {
        while (true) {
            if (this.cardObjectList.Count >= this.maxCardCount) {
                break;
            }
            
            this.addCardObject();
        }
    }
}
