using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CardObject
{
    private CardProto cardProto;
    void startGameObject()//创建卡牌预制体
    {
        var obj = (GameObject) Resources.Load("Prefabs/UI/CardProto");
        var parent = this.boatUnit.gameObject.transform.Find("Hand");
        var go = GameObject.Instantiate(obj, parent, true);
        go.transform.localScale = Vector3.one;
        this.cardProto = go.AddComponent<CardProto>();
        this.cardProto.cardObject = this;
        this.cardProto.start();
    }

    void stopGameObject()
    {
        this.cardProto.stop();
        GameObject.Destroy(this.cardProto.gameObject);
    }
}
