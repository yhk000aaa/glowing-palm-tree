using System;
using UnityEngine;

public static class GameObjectGetter
{
    //getPosition
    public static Vector3 getPosition(this MonoBehaviour behaviour)
    {
        return behaviour.gameObject.getPosition();
    }

    public static Vector3 getPosition(this GameObject go)
    {
        return go.transform.localPosition;
    }

    //getScale
    public static Vector3 getScale(this MonoBehaviour behaviour)
    {
        return behaviour.gameObject.getScale();
    }

    public static Vector3 getScale(this GameObject go)
    {
        return go.transform.localScale;
    }

    public static float getScaleX(this MonoBehaviour behaviour)
    {
        return behaviour.gameObject.getScaleX();
    }

    public static float getScaleX(this GameObject go)
    {
        return go.transform.localScale.x;
    }

    public static float getScaleY(this MonoBehaviour behaviour)
    {
        return behaviour.gameObject.getScaleY();
    }

    public static float getScaleY(this GameObject go)
    {
        return go.transform.localScale.y;
    }

    //getRotation
    public static float getRotation(this MonoBehaviour behaviour)
    {
        return behaviour.gameObject.getRotation();
    }

    public static float getRotation(this GameObject go)
    {
        return go.transform.localRotation.FromQ2().z;
    }

    //getRadian
    public static float getRadian(this MonoBehaviour behaviour)
    {
        return behaviour.gameObject.getRadian();
    }

    public static float getRadian(this GameObject go)
    {
        return go.getRotation().toRadian();
    }
}
