using System;
using System.Collections;
using System.Collections.Generic;
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
        
    public event Action beginDragAction;
    public event Action dragAction;
    public event Action endDragAction;

    public void start()
    {
        this.nameLabel = this.gameObject.transform.Find("nameLabel").GetComponent<Text>();
        this.descLabel = this.gameObject.transform.Find("descLabel").GetComponent<Text>();
        this.costLabel = this.gameObject.transform.Find("costLabel").GetComponent<Text>();

        this.nameLabel.text = this.cardInsData.name;
        this.descLabel.text = this.cardInsData.getDesc();
        this.costLabel.text = this.cardInsData.cost.toString();
    }

    public void stop()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.dragAction?.Invoke();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.beginDragAction?.Invoke();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.endDragAction?.Invoke();
    }
}
