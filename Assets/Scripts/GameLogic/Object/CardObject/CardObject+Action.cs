using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CardObject
{
    void startAction()
    {
        this.cardProto.beginDragAction += CardProtoOnBeginDragAction;
        this.cardProto.dragAction += CardProtoOnDragAction;
        this.cardProto.endDragAction += CardProtoOnEndDragAction;
    }

    void stopAction()
    {
        this.cardProto.beginDragAction -= CardProtoOnBeginDragAction;
        this.cardProto.dragAction -= CardProtoOnDragAction;
        this.cardProto.endDragAction -= CardProtoOnEndDragAction;
    }

    private void CardProtoOnBeginDragAction()
    {
        //开始拖动
    }
    
    private void CardProtoOnDragAction()
    {
        //拖动中
    }
    
    private void CardProtoOnEndDragAction()
    {
        //拖动结束后使用
        this.triggerEffect();
    }


    protected virtual void triggerEffect()
    {
    }
}
