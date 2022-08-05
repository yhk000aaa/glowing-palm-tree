using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact
{
    public Unit ownUnit;
    public Unit otherUnit;
    public Collider otherCollider;
}

public partial class Unit
{
    protected ContactGameObject contactGameObject;
    public virtual bool needContact => false;
    public virtual string unitContactKey => "Unit";
    Dictionary<string, Action<Contact>> _contactDelegates;
    private const string contactBeginWith = "contactBeginWith";
    private const string contactStayWith = "contactStayWith";
    private const string contactEndWith = "contactEndWith";
    
    void popContact()
    {
        this.currentLayer = this.originLayer;
        if (this.needContact) {
           this.contactGameObject = this.gameObject.AddComponent<ContactGameObject>();
           this.contactGameObject.unit = this;
           _contactDelegates = new Dictionary<string, Action<Contact>>();
        }
    }

    void pushContact()
    {
        if (this.needContact) {
            GameObject.Destroy(this.contactGameObject);
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        var contact = this.getContactByOtherCollider(other);
        this.OnContact(contactBeginWith + contact.otherUnit.unitContactKey, contact);
    }

    public void OnTriggerStay(Collider other)
    {
        var contact = this.getContactByOtherCollider(other);
        this.OnContact(contactStayWith + contact.otherUnit.unitContactKey, contact);
    }

    public void OnTriggerExit(Collider other)
    {
        var contact = this.getContactByOtherCollider(other);
        this.OnContact(contactEndWith + contact.otherUnit.unitContactKey, contact);
    }

    public void OnCollisionEnter(Collider other)
    {
        var contact = this.getContactByOtherCollider(other);
        this.OnContact(contactBeginWith + contact.otherUnit.unitContactKey, contact);
    }

    public void OnCollisionStay(Collider other)
    {
        var contact = this.getContactByOtherCollider(other);
        this.OnContact(contactStayWith + contact.otherUnit.unitContactKey, contact);
    }

    public void OnCollisionExit(Collider other)
    {
        var contact = this.getContactByOtherCollider(other);
        this.OnContact(contactEndWith + contact.otherUnit.unitContactKey, contact);
    }

    Contact getContactByOtherCollider(Collider other)
    {
        var contact = DataUtils.Instance.getActivator<Contact>("Contact");
        contact.ownUnit = this;
        contact.otherUnit = other.gameObject.GetComponent<ContactGameObject>().unit;
        contact.otherCollider = other;
        return contact;
    }
    
    void OnContact(string methodString, Contact contact)
    {
        this.invokeContact(methodString, contact);
    }
    
    public void invokeContact(string func, Contact contact)
    {
        Action<Contact> o = null;
        if (!_contactDelegates.TryGetValue(func, out o)) {
            var method = DataUtils.getMethod(this, func, true);
            if (method != null) {
                o = (Action<Contact>)Delegate.CreateDelegate(typeof(Action<Contact>), this, method);
            }
            _contactDelegates[func] = o;
        }
        if (o == null) {
            return;
        }
        o(contact);
    }
}
