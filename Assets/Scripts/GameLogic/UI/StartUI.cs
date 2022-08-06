using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XHFrameWork;

public class StartUI : BaseUI
{
    private Button confirmBtn;
    
    public override EnumUIType GetUIType()
    {
        return EnumUIType.StartUI;
    }

    protected override void OnStart()
    {
        base.OnStart();
        this.confirmBtn = this.gameObject.transform.Find("startButton").GetComponent<Button>();
        this.confirmBtn.onClick.AddListener(this.clickConfirmBtnEvent);
    }

    protected override void destroyAction()
    {
        this.confirmBtn.onClick.RemoveListener(this.clickConfirmBtnEvent);
        base.destroyAction();
    }

    void clickConfirmBtnEvent()
    {
        EducationNode.Instance.tryEnterBattle();
    }
}
