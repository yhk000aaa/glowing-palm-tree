using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Unit
{
    public Vector3 position
    {
        get => this.gameObject.transform.localPosition;
        set => this.gameObject.transform.localPosition = value;
    }

    public Quaternion rotation
    {
        get => this.gameObject.transform.rotation;
        set => this.gameObject.transform.rotation = value;
    }

    public Vector3 forward
    {
        get => this.gameObject.transform.forward;
        set => this.gameObject.transform.forward = value;
    }

    public Vector3 up
    {
        get => this.gameObject.transform.up;
        set => this.gameObject.transform.up = value;
    }

    public Vector3 localScale
    {
        get => this.gameObject.transform.localScale;
        set => this.gameObject.transform.localScale = value;
    }
}
