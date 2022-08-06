using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BoatUnit
{
    void startAction()
    {
        this.activeData.leaderObj.onValueChangeAction += LeaderObjOnValueChangeAction;
        this.activeData.cookObj.onValueChangeAction += CookObjOnValueChangeAction;
        this.activeData.guideObj.onValueChangeAction += GuideObjOnValueChangeAction;
        this.activeData.operateObj.onValueChangeAction += OperateObjOnValueChangeAction;
        this.activeData.surfObj.onValueChangeAction += SurfObjOnValueChangeAction;
        this.LeaderObjOnValueChangeAction();
        this.CookObjOnValueChangeAction();
        this.GuideObjOnValueChangeAction();
        this.OperateObjOnValueChangeAction();
        this.SurfObjOnValueChangeAction();
    }

    void stopAction()
    {
        this.activeData.leaderObj.onValueChangeAction -= LeaderObjOnValueChangeAction;
        this.activeData.cookObj.onValueChangeAction -= CookObjOnValueChangeAction;
        this.activeData.guideObj.onValueChangeAction -= GuideObjOnValueChangeAction;
        this.activeData.operateObj.onValueChangeAction -= OperateObjOnValueChangeAction;
        this.activeData.surfObj.onValueChangeAction -= SurfObjOnValueChangeAction;
    }
    
    private void SurfObjOnValueChangeAction()
    {
        // this.surfText.text = string.Format("航向点:{0}", this.activeData.surfObj.value);
    }

    private void OperateObjOnValueChangeAction()
    {
        // this.operateText.text = string.Format("动手能力:{0}", this.activeData.operateObj.value);
    }

    private void GuideObjOnValueChangeAction()
    {
        // this.guideText.text = string.Format("导航能力:{0}", this.activeData.guideObj.value);
    }

    private void CookObjOnValueChangeAction()
    {
        // this.cookText.text = string.Format("厨艺:{0}", this.activeData.cookObj.value);
    }

    private void LeaderObjOnValueChangeAction()
    {
        // this.leaderText.text = string.Format("领导力:{0}", this.activeData.leaderObj.value);
    }
}
