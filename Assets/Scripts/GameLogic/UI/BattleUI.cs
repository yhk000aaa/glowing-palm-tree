using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XHFrameWork;

public class BattleUI : BaseUI
{
    public override EnumUIType GetUIType()
    {
        return EnumUIType.BattleUI;
    }

    public Slider sail { get; private set; }
    public Slider walter { get; private set; }
    public Button endRoundBtn { get; private set; }

    protected override void OnAwake()
    {
        base.OnAwake();
        this.sail = this.gameObject.transform.Find("sail").GetComponent<Slider>();
        this.walter = this.gameObject.transform.Find("walter").GetComponent<Slider>();
        this.endRoundBtn = this.gameObject.transform.Find("EndRound").GetComponent<Button>();
    }
}
