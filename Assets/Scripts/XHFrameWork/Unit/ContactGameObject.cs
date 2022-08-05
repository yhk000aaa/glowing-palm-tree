using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactGameObject : MonoBehaviour
{
    public event Action<Collider> onContactBegin;
    public event Action<Collider> onContactStay;
    public event Action<Collider> onContactEnd;
    public Unit unit;
    
    private void OnTriggerEnter(Collider other)
    {
        this.unit.OnTriggerEnter(other);
    }

    private void OnTriggerStay(Collider other)
    {
        this.unit.OnTriggerStay(other);
    }

    private void OnTriggerExit(Collider other)
    {
        this.unit.OnTriggerExit(other);
    }

    private void OnCollisionEnter(Collision coll)
    {
        this.unit.OnCollisionEnter(coll.collider);
    }

    private void OnCollisionStay(Collision coll)
    {
        this.unit.OnCollisionStay(coll.collider);
    }

    private void OnCollisionExit(Collision coll)
    {
        this.unit.OnCollisionExit(coll.collider);
    }
}
