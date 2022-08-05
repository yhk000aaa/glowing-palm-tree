//UI部件跟随世界目标的脚本

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbarFollowGO : MonoBehaviour
{
    Vector2 screenPos;//屏幕坐标
    public Transform tg;//目标

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (tg)
        {
            Vector2 screenPos = Camera.main.WorldToScreenPoint(tg.position);
            transform.position = screenPos;
        }
    }
}
