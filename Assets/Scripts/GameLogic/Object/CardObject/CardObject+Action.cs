using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CardObject
{
    void startAction()
    {

    }

    void stopAction()
    {

    }

    public virtual void triggerUseAction()
    {
        this.isOver = true;
    }

    public virtual void triggerRoundEnd()
    {
        
    }
}

public class MoveCardObject : CardObject//航向卡  (向前移动)
{
    public override void triggerUseAction()
    {
        base.triggerUseAction();

        boatUnit.activeData.sailObj.setValue(boatUnit.activeData.sailObj.value + this.cardInsData.value);
        boatUnit.battleUI.UpdateSail(boatUnit.activeData.sailObj.value);
    }
}

public class MoveMultipleCardObject : CardObject//???
{
    public override void triggerUseAction()
    {
        base.triggerUseAction();

        boatUnit.activeData.sailObj.setValue(boatUnit.activeData.sailObj.value * this.cardInsData.value);
        boatUnit.battleUI.UpdateSail(boatUnit.activeData.sailObj.value);
    }
}

public class DrawCardFullCardObject : CardObject
{
    public override void triggerUseAction()
    {
        base.triggerUseAction();

        while (true) {
            if (boatUnit.cardObjectList.Count >= boatUnit.maxCardCount) {
                break;
            }
            
            boatUnit.addCardObject();
        }
    }
}

public class DrawCardByCountCardObject : CardObject
{
    public override void triggerUseAction()
    {
        base.triggerUseAction();

        for (int i = 0; i < this.cardInsData.value; i++) {
            boatUnit.addCardObject();
        }
    }
}


public class SearchFoodCardObject : CardObject
{
    public bool convertMaterial;
    
    public override void triggerUseAction()
    {
        base.triggerUseAction();
        for (int i = 0; i < this.cardInsData.value; i++) {
            var cardList = this.mainNode.mainData.cardConfigRoot.configList.FindAll(x => x.cardType == CardType.Food);
            if (cardList.Count == 0) {
                continue;
            }
            
            var cardConfig = cardList.getRandomOne();
            if (convertMaterial) {
                boatUnit.activeData.materialObj.addValue(cardConfig.value);
            }
            else {
                boatUnit.addCardObject(cardConfig);
            }
        }
    }

    public override void triggerRoundEnd()
    {
        base.triggerRoundEnd();
        this.convertMaterial = true;
    }
}
public class LeaderCardObject : CardObject
{
    public override void triggerUseAction()
    {
        base.triggerUseAction();
        
    }
}
public class SearchMaterialCardObject : CardObject
{
    public override void triggerUseAction()
    {
        base.triggerUseAction();
        boatUnit.activeData.materialObj.setValue(boatUnit.activeData.materialObj.value + this.cardInsData.value);
    }
}

public class ConvertFoodCardObject : CardObject//食物卡
{
    public override void triggerUseAction()
    {
        base.triggerUseAction();

        foreach (var o in boatUnit.cardObjectList) {
            if (o is SearchFoodCardObject searchFoodCardObject) {
                searchFoodCardObject.convertMaterial = true;
            }
        }
    }
}

public class FoodCardObject : CardObject//食物卡
{
    
}
