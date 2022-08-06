using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardProto : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public CardObject cardObject;
    private CardInsData cardInsData => this.cardObject.cardInsData;
    private Text nameLabel;
    private Text descLabel;
    private Text costLabel;
    private CanvasGroup canvasGroup;
    public event Action beginDragAction;
    public event Action dragAction;
    public event Action endDragAction;

    private Vector2 startPos;
    
    public void start()
    {
        this.canvasGroup = this.gameObject.GetComponent<CanvasGroup>();
        // this.nameLabel = this.gameObject.transform.Find("nameLabel").GetComponent<Text>();
        // this.descLabel = this.gameObject.transform.Find("descLabel").GetComponent<Text>();
        // this.costLabel = this.gameObject.transform.Find("costLabel").GetComponent<Text>();
        //
        // this.nameLabel.text = this.cardInsData.name;
        // this.descLabel.text = this.cardInsData.getDesc();
        // this.costLabel.text = this.cardInsData.cost.toString();
    }

    public void stop()
    {
        this.gameObject.stopAllActions();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.LogError("OnBeginDrag");
        this.beginDragAction?.Invoke();

        this.startPos = this.gameObject.transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.dragAction?.Invoke();

        this.gameObject.transform.position += (Vector3)eventData.delta;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.LogError("OnEndDrag");
        this.endDragAction?.Invoke();

        if (this.gameObject.transform.localPosition.y - this.startPos.y > 100) {
            this.cardObject.triggerUseAction();   
        }
        else {
            this.canvasGroup.interactable = false;
            this.gameObject.moveLocalPosTo(this.startPos, 6 / 30f).OnComplete(() =>
            {
                this.canvasGroup.interactable = true;
            });
        }
    }
}
