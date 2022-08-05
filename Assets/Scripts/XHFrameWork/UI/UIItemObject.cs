using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemObject
{
    public Transform parent;
    public GameObject gameObject;

    public virtual void start()
    {
    }

    public virtual void stop()
    {
    }
}

public class ButtonItemObject : UIItemObject
{
    public Button btn;
    public event Action onClickAction;
    public override void start()
    {
        base.start();

        this.btn = this.gameObject.GetComponent<Button>();
        if (this.btn != null) {
            this.btn.onClick.AddListener(this.clickAction);
        }
    }

    public override void stop()
    {
        if (this.btn != null) {
            this.btn.onClick.RemoveListener(this.clickAction);
        }
        base.stop();
    }

    void clickAction()
    {
        this.onClickAction?.Invoke();
    }
}

public class DropDownItemObject : UIItemObject
{
    public Dropdown dropdown;
    private List<DropdownOptionCellObject> optionCellObjectList;
    public virtual string cellDataClassName => "DropdownOptionCellData";
    
    public override void start()
    {
        base.start();
        this.dropdown = this.gameObject.GetComponent<Dropdown>();
        this.optionCellObjectList = new List<DropdownOptionCellObject>();
        
        this.dropdown.onValueChanged.AddListener(this.valueChange);
    }

    public override void stop()
    {
        this.dropdown.onValueChanged.AddListener(this.valueChange);
        base.stop();
    }

    void valueChange(int value)
    {
        this.optionCellObjectList.objectValue(value)?.selectAction();
    }

    public void addOption(object obj)
    {
        var optionObj = DataUtils.Instance.getActivator<DropdownOptionCellObject>(cellDataClassName);
        optionObj.dropdown = this.dropdown;
        optionObj.obj = obj;
        optionObj.start();
        this.optionCellObjectList.Add(optionObj);
    }
    
    public void removeOption(DropdownOptionCellObject obj)
    {
        obj.stop();
        this.optionCellObjectList.Remove(obj);
    }
}

public class DropdownOptionCellObject
{
    private Dropdown.OptionData optionData;
    public Dropdown dropdown;
    public object obj;

    public virtual void start()
    {
        this.optionData = new Dropdown.OptionData();
        this.dropdown.options.Add(this.optionData);
    }

    public virtual void stop()
    {
        this.dropdown.options.Remove(this.optionData);
    }

    public virtual void selectAction()
    {
    }
}