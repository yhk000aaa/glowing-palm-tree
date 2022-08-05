using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Unit
{
    public virtual bool needRigidBody => false;
    public Rigidbody rigidbody { get; private set; }
    public Vector3 velocity => this.rigidbody.velocity;
    
    void popMove()
    {
        if (this.needRigidBody) {
            this.rigidbody = this.gameObject.AddComponent<Rigidbody>();
            this.rigidbody.velocity = Vector3.zero;
        }
    }

    void pushMove()
    {
        if (this.needRigidBody) {
            GameObject.Destroy(this.rigidbody);
            this.rigidbody = null;
        }
    }

    public void updateSpeed(Vector3 val)
    {
        if (this.needRigidBody) {
            this.rigidbody.velocity = val;
        }
    }
}
