using System;
using UnityEngine;

public static class GameObjectConvert
{
    //convert
    public static Vector3 convertToNodeSpace(this MonoBehaviour behaviour, float x, float y)
    {
        return behaviour.convertToNodeSpace(new Vector3(x, y));
    }

    public static Vector3 convertToNodeSpace(this GameObject go, float x, float y)
    {
        return go.convertToNodeSpace(new Vector3(x, y));
    }

    public static Vector3 convertToNodeSpace(this MonoBehaviour behaviour, Vector3 vector)
    {
        return behaviour.gameObject.convertToNodeSpace(vector);
    }

    public static Vector3 convertToNodeSpace(this GameObject go, Vector3 vector)
    {
        return go.transform.InverseTransformPoint(vector);
    }

    public static Vector3 convertToWorldSpace(this MonoBehaviour behaviour, float x, float y)
    {
        return behaviour.convertToWorldSpace(new Vector3(x, y));
    }

    public static Vector3 convertToWorldSpace(this GameObject go, float x, float y)
    {
        return go.convertToWorldSpace(new Vector3(x, y));
    }

    public static Vector3 convertToWorldSpace(this MonoBehaviour behaviour, Vector3 vector)
    {
        return behaviour.gameObject.convertToWorldSpace(vector);
    }

    public static Vector3 convertToWorldSpace(this GameObject go, Vector3 vector)
    {
        return go.transform.TransformPoint(vector);
    }
}
