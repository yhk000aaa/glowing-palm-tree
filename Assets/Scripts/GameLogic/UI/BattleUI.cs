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
    /// <summary>
    /// 更新水量UI
    /// </summary>
    /// <param name="waterNum">水的数量</param>
    public void UpdateWater(float waterNum)
    {
        this.walter.value = waterNum;
    }
    /// <summary>
    /// 更新据下一个岛距离UI
    /// </summary>
    /// <param name="distanceNum">距离</param>
    public void UpdateSail(float distanceNum)
    {
        this.sail.value = distanceNum;
    }

}
