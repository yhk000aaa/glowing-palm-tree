//摄像机跟随，挂在主摄像机上即可

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XHFrameWork;
using System;
using UnityEngine.UI;
using UnityEngine.Networking;

public class FollowCamera : MonoBehaviour
{
    public Transform follow;
    public Camera me;
    public float orthographicSize;//正交摄像机时的视野宽度
    public float orthographicSize_temp;//正交摄像机时的视野宽度-临时
    //摄像机跟随参数
    public float distanceAway = 10;			// distance from the back of the craft透视摄像机时的视野高度
    private float distanceUp = 0;			// distance above the craft
    public float smooth = 40;				// how smooth the camera movement is
    private GameObject hovercraft;		// to store the hovercraft
    private Vector3 targetPosition;		// the position the camera is trying to be in

    public bool isStartFollowWhenInit=true;//是否在初始化时开始镜头跟随

void Start()
    {
        me = gameObject.GetComponent<Camera>();
        me.orthographicSize = orthographicSize;

        if(isStartFollowWhenInit)MoveCamara(follow);

        MessageCenter.Instance.AddListener(MessageType.MoveCamara, MoveCamara);
        MessageCenter.Instance.AddListener(MessageType.CamaraShake, CamaraShake);
        MessageCenter.Instance.AddListener(MessageType.CamaraSizeChange, CamaraSizeChange);
    }

    void Release()
    {
        MessageCenter.Instance.RemoveListener(MessageType.MoveCamara, MoveCamara);
        MessageCenter.Instance.RemoveListener(MessageType.CamaraShake, CamaraShake);
        MessageCenter.Instance.RemoveListener(MessageType.CamaraSizeChange, CamaraSizeChange);
    }

    #region 镜头移动的相关方法
    //更新镜头目标并开启跟随 by 消息
    private void MoveCamara(Message msg)
    {
        MoveCamara((Transform)msg["trs"]);
    }

    //更新镜头目标并开启跟随 by 目标
    public void MoveCamara(Transform _newFollow)
    {
        follow = _newFollow;
        StopCoroutine("MoveCamaraToTRS");
        StartCoroutine("MoveCamaraToTRS", follow);
    }

    //跟随对应目标
    IEnumerator MoveCamaraToTRS(Transform _follow)
    {
        while (true)
        {
            // setting the target position to be the correct offset from the hovercraft
            targetPosition = _follow.position + Vector3.up * distanceUp - _follow.forward * distanceAway;

            // making a smooth transition between it's current position and the position it wants to be in
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
            //transform.rotation = _follow.FindChild("Animator").rotation;
            // make sure the camera is looking the right way!
            //transform.LookAt(_follow);

            yield return new WaitForFixedUpdate();
        }
    }

    //IEnumerator MoveCamaraToMap(int _mapId) 
    //{
    //    Vector3 startCamaraPt = this.transform.position;
    //    Vector3 targetCamaraPt = GameObject.Find("Map/CameraPt/" + _mapId.ToString()).transform.position;
    //    Quaternion startCamaraRt = this.transform.rotation;
    //    Quaternion targetCamaraRt = GameObject.Find("Map/CameraPt/" + _mapId.ToString()).transform.rotation;

    //    float step = 0;
    //    while ((startCamaraPt != targetCamaraPt) || (startCamaraRt != targetCamaraRt))
    //    {
    //        step += 0.1f;
    //        this.transform.position = new Vector3(Mathf.Lerp(startCamaraPt.x, targetCamaraPt.x, step), Mathf.Lerp(startCamaraPt.y, targetCamaraPt.y, step), Mathf.Lerp(startCamaraPt.z, targetCamaraPt.z, step));
    //        this.transform.rotation = new Quaternion(Mathf.Lerp(startCamaraRt.x, targetCamaraRt.x, step), Mathf.Lerp(startCamaraRt.y, targetCamaraRt.y, step), Mathf.Lerp(startCamaraRt.z, targetCamaraRt.z, step), Mathf.Lerp(startCamaraRt.w, targetCamaraRt.w, step));
    //        yield return new WaitForFixedUpdate();
    //    }
    //    yield break;
    //}

    #endregion
        
    #region 镜头震动的相关方法-正交摄像机
    //摄像机震动-正交摄像机才有用
    void CamaraShake(Message _msg)
    {
        float rate = (float)_msg["rate"];
        StopCoroutine("CamaraShakebyRate");
        StartCoroutine("CamaraShakebyRate", rate);
    }

    //摄像机震动by振幅-正交摄像机才有用
    IEnumerator CamaraShakebyRate(float _rate)
    {
        orthographicSize_temp = me.orthographicSize * _rate;//取当前镜头me参数计算，使连续震屏有连续缩进的感觉
        if (orthographicSize_temp < orthographicSize * 0.6f)//控制结果不能缩得过近
            orthographicSize_temp = orthographicSize * 0.6f;

        //计划震入2帧
        int count = 0;
        while (count < 2)
        {
            count++;
            me.orthographicSize = orthographicSize + (orthographicSize_temp - orthographicSize) * count / 2;//正交摄像机震动
            yield return new WaitForFixedUpdate();
        }
        //快速震出1/2距离，2帧
        while (count > 0)
        {
            count--;
            me.orthographicSize = orthographicSize +
                (orthographicSize_temp - orthographicSize) /2 +
                (orthographicSize_temp - orthographicSize) /2 * count / 2;//正交摄像机震动
            yield return new WaitForFixedUpdate();
        }
        //慢退1/2距离，30帧，结束
        count = 30;
        while (count > 0)
        {
            count--;
            me.orthographicSize = orthographicSize + (orthographicSize_temp - orthographicSize) /2 * count / 30;//正交摄像机震动
            yield return new WaitForFixedUpdate();
        }
        me.orthographicSize = orthographicSize;
        yield break;

    }
    #endregion

    //改变摄像机视野尺寸
    void CamaraSizeChange(Message _msg)
    {
        orthographicSize = (float)_msg["camaraSize"];
        me.orthographicSize = orthographicSize;
    }

}
