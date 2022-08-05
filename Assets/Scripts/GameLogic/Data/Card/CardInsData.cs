using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInsData : UnitSimpleData<CardConfig>
{
    public string name => this.config.name;
    public string desc => this.config.desc;
    public float cost => this.config.cost;
    public float value => this.config.value;
    public string cardType => this.config.cardType;

    public string getDesc()
    {
        return string.Format(this.desc, this.value);
    }
}
