using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Unit
{
    public virtual UnitLayer originLayer => UnitLayer.ControlBody;

    UnitLayer _currentLayer;
    public UnitLayer currentLayer
    {
        get => _currentLayer;
        set
        {
            if (this._currentLayer == value) {
                return;
            }
            this._currentLayer = value;
            this.gameObject.layer = (int)this._currentLayer;
        }
    }
}
