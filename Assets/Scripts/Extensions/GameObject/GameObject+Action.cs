using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectActionTag
{
    public const string Rotate = "rotate";
    public const string Fade = "fade";
}

public static class GameObjectAction
{
    public static Sequence createSequence(this GameObject obj, bool setUpdate = true)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.SetTarget(obj); 
        sequence.SetRecyclable();
        sequence.SetUpdate(setUpdate);
        return sequence;
    }
    
    public static Tweener moveTo(this GameObject gobject, Vector3 endValue, float duration, bool setUpdate = true)
        {
            return DOTween.To(() => gobject.transform.position, x => gobject.transform.position = x, endValue, duration)
                .SetUpdate(setUpdate)
                .SetRecyclable()
                .SetTarget(gobject);
        }

    public static Tweener moveLocalPosTo(this GameObject gobject, Vector3 endValue, float duration, bool setUpdate = true)
    {
        return DOTween.To(() => gobject.transform.localPosition, x => gobject.transform.localPosition = x, endValue, duration)
            .SetUpdate(setUpdate)
            .SetRecyclable()
            .SetTarget(gobject);
    }
    
    public static Tweener scaleTo(this GameObject gobject, Vector3 endValue, float duration, bool setUpdate = true)
        {
            return DOTween.To(() => gobject.transform.localScale, x => gobject.transform.localScale = x, endValue, duration)
                .SetUpdate(setUpdate)
                .SetRecyclable()
                .SetTarget(gobject);
        }

    public static Tweener rotateTo(this GameObject gobject, Vector3 endValue, float duration, bool setUpdate = true)
    {
        return DOTween.To(() => gobject.transform.localEulerAngles, x => gobject.transform.localEulerAngles = x, endValue, duration)
            .SetUpdate(setUpdate)
            .SetRecyclable()
            .SetTarget(gobject);
    }
    
    public static Tweener fadeTo(this CanvasGroup gobject, float endValue, float duration, bool setUpdate = true)
    {
        return DOTween.To(() => gobject.alpha, x => gobject.alpha = x, endValue, duration)
            .SetUpdate(setUpdate)
            .SetRecyclable()
            .SetTarget(gobject);
    }
    
    public static Tweener fadeTo(this Text gobject, Color endValue, float duration, bool setUpdate = true)
    {
        return DOTween.To(() => gobject.color, x => gobject.color = x, endValue, duration)
            .SetUpdate(setUpdate)
            .SetRecyclable()
            .SetTarget(gobject);
    }
    
    public static void stopAllActions(this GameObject gobject, bool complete = false)
    {
        DOTween.Kill(gobject, complete);
    }

    public static void stopActionByTag<T>(this GameObject gobject, T tag, bool complete = false)
    {
        var list = DOTween.TweensByTarget(gobject);
        if (list == null) {
            return;
        }
        foreach (var t in list) {
            if (t == null || t.id == null || !t.id.Equals(tag)) {
                continue;
            }
            if (t.IsActive()) {
                t.Kill(complete);
            }
        }
    }
}
