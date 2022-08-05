using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatActiveData
{
    class NumberType
    {
        public const string LeaderPoint = "leader";
        public const string OperatePoint = "operate";
        public const string CookPoint = "cook";
        public const string SurfPoint = "surf";
        public const string GuidePoint = "guide";

    }
    public BoatConfig boatConfig { get; private set; }
    private Dictionary<string, NumberDisplayObject> numberObjects;

    public NumberDisplayObject leaderObj => this.numberObjects[NumberType.LeaderPoint];
    public NumberDisplayObject operateObj => this.numberObjects[NumberType.OperatePoint];
    public NumberDisplayObject cookObj => this.numberObjects[NumberType.CookPoint];
    public NumberDisplayObject surfObj => this.numberObjects[NumberType.SurfPoint];
    public NumberDisplayObject guideObj => this.numberObjects[NumberType.GuidePoint];

    public void init(BoatConfig boatConfig)
    {
        this.boatConfig = boatConfig;

        this.numberObjects = new Dictionary<string, NumberDisplayObject>();
        this.numberObjects[NumberType.LeaderPoint] = new NumberDisplayObject(this.boatConfig.leader);
        this.numberObjects[NumberType.OperatePoint] = new NumberDisplayObject(this.boatConfig.operate);
        this.numberObjects[NumberType.CookPoint] = new NumberDisplayObject(this.boatConfig.cook);
        this.numberObjects[NumberType.SurfPoint] = new NumberDisplayObject(this.boatConfig.surf);
        this.numberObjects[NumberType.GuidePoint] = new NumberDisplayObject(this.boatConfig.guide);
    }
}

public partial class BoatUnit : Unit
{
    public override UnitLayer originLayer => UnitLayer.UI;

    public BoatActiveData activeData { get; private set; }
    public BoatConfig boatConfig { get; private set; }
    private BattleUI battleUI;
    
    private GameObject roleObject;
    private Text leaderText;
    private Text cookText;
    private Text guideText;
    private Text operateText;
    private Text surfText;

    protected override void popPrepare()
    {
        base.popPrepare();
        this.cardObjectList = new List<CardObject>();

        this.battleUI = this._config["battleUI"] as BattleUI;
        this.boatConfig = this._config["config"] as BoatConfig;

        this.roleObject = this.battleUI.gameObject.transform.Find("rolePanel").gameObject;
        this.leaderText = this.roleObject.transform.Find("leaderText").GetComponent<Text>();
        this.cookText = this.roleObject.transform.Find("cookText").GetComponent<Text>();
        this.guideText = this.roleObject.transform.Find("guideText").GetComponent<Text>();
        this.operateText = this.roleObject.transform.Find("operateText").GetComponent<Text>();
        this.surfText = this.roleObject.transform.Find("surfText").GetComponent<Text>();

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
}
