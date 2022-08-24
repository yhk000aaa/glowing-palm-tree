using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XHFrameWork;

public class StartUI : BaseUI
{
    private Button confirmBtn;
    private Button leaveBtn;
    public override EnumUIType GetUIType()
    {
        return EnumUIType.StartUI;
    }

    protected override void OnStart()
    {
        base.OnStart();
        this.confirmBtn = this.gameObject.transform.Find("startButton").GetComponent<Button>();
        this.confirmBtn.onClick.AddListener(this.clickConfirmBtnEvent);
        this.leaveBtn = this.gameObject.transform.Find("leaveButton").GetComponent<Button>();
        this.leaveBtn.onClick.AddListener(this.clickLeaveBtnEvent);
    }

    protected override void destroyAction()
    {
        this.confirmBtn.onClick.RemoveListener(this.clickConfirmBtnEvent);
        this.leaveBtn.onClick.RemoveListener(this.clickLeaveBtnEvent);
        base.destroyAction();
    }

    void clickConfirmBtnEvent()
    {
        EducationNode.Instance.tryEnterBattle();
    }

    void clickLeaveBtnEvent()
    {
        if (UnityEditor.EditorApplication.isPlaying){
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else{
            Application.Quit();
        }
    }
}
