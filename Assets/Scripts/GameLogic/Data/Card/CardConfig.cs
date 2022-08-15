using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardType
{
    public const string None = "none";
    public const string Search = "search";
    public const string Move = "move";
    public const string Leader = "lead";

    public const string Material = "material";
}

public class CardConfig : NSConfigObject
{
    public string name { get; private set; }
    public string desc { get; private set; }
    public string extraDesc { get; private set; }
    public float cost { get; private set; }
    public float value { get; private set; }
    public string cardType { get; private set; }
    public string cardObjectClassName => CardObjectClassNames.objectValue(this.cardType, "CardObject");

    private static Dictionary<string, string> CardObjectClassNames = new Dictionary<string, string>()
    {
        {CardType.Move, "MoveCardObject"},

        {CardType.Search, "SearchCardObject"},

        {CardType.Leader, "LeaderCardObject"},

        {CardType.Material, "MaterialCardObject"},

    };

    public override void initializeByParameters(Dictionary<string, object> parameters)
    {
        base.initializeByParameters(parameters);
        this.name = parameters.stringValue("name");
        this.desc = parameters.stringValue("desc");
        this.extraDesc = parameters.stringValue("extraDesc");
        this.cost = parameters.floatValue("cost");
        this.value = parameters.floatValue("value");
        this.cardType = parameters.stringValue("cardType", CardType.None);
    }
}