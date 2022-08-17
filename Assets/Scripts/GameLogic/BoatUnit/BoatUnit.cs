using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatActiveData
{
    class NumberType
    {
        public const string WalterPoint = "walter";
        public const string MaterialPoint = "material";
        public const string SailPoint = "sail";
    }
    public BoatConfig boatConfig { get; private set; }
    private Dictionary<string, NumberDisplayObject> numberObjects;

    public NumberDisplayObject sailObj => this.numberObjects[NumberType.SailPoint];
    public NumberDisplayObject materialObj => this.numberObjects[NumberType.MaterialPoint];
    public NumberDisplayObject walterObj => this.numberObjects[NumberType.WalterPoint];

    public void init(BoatConfig boatConfig)
    {
        this.boatConfig = boatConfig;

        this.numberObjects = new Dictionary<string, NumberDisplayObject>();
        this.numberObjects[NumberType.WalterPoint] = new NumberDisplayObject(30);
        this.numberObjects[NumberType.MaterialPoint] = new NumberDisplayObject(10);
        this.numberObjects[NumberType.SailPoint] = new NumberDisplayObject(0);
    }
}

public partial class BoatUnit : Unit
{
    public override UnitLayer originLayer => UnitLayer.UI;

    public BoatActiveData activeData { get; private set; }
    public BoatConfig boatConfig { get; private set; }
    private BattleUI battleUI;

    // private GameObject roleObject;
    // private Text leaderText;
    // private Text cookText;
    // private Text guideText;
    // private Text operateText;
    // private Text surfText;

    protected override void popPrepare()
    {
        base.popPrepare();
        this.cardObjectList = new List<CardObject>();

        this.battleUI = this._config["battleUI"] as BattleUI;
        this.boatConfig = this._config["config"] as BoatConfig;

        // this.roleObject = this.battleUI.gameObject.transform.Find("rolePanel").gameObject;
        // this.leaderText = this.roleObject.transform.Find("leaderText").GetComponent<Text>();
        // this.cookText = this.roleObject.transform.Find("cookText").GetComponent<Text>();
        // this.guideText = this.roleObject.transform.Find("guideText").GetComponent<Text>();
        // this.operateText = this.roleObject.transform.Find("operateText").GetComponent<Text>();
        // this.surfText = this.roleObject.transform.Find("surfText").GetComponent<Text>();

        this.activeData = DataUtils.Instance.getActivator<BoatActiveData>("BoatActiveData");
        this.activeData.init(this.boatConfig);
    }

    protected override void popObject()
    {
        base.popObject();
        this.gameObject = this.battleUI.gameObject;
    }

    protected override void popExtra()
    {
        base.popExtra();
        this.startCards();
        this.startAction();
    }

    protected override void pushExtra()
    {
        this.stopAction();
        this.stopCards();
        base.pushExtra();
    }

    public override void update(float dt)
    {
        base.update(dt);
        this.updateCards(dt);
    }
    
    //回合结束，结算
    public void triggerRoundEnd()
    {
        this.activeData.sailObj.setValue(0);

        foreach (var o in this.cardObjectList) {
            o.triggerRoundEnd();
        }
    }
}
