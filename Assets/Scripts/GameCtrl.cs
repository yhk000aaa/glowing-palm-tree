using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XHFrameWork;

public class GameCtrlStatus
{
    public const int None = 0;
    public const int InitSetting = 1;
    public const int UserLogin = 2;
    public const int InitData = 3;
    public const int InitSdk = 4;
    public const int Stay = 5;
    public const int Over = 6;
}

public class GameCtrl : MonoBehaviour
{
    private EducationNode educationNode;
    private StatusObject _statusObject;

    private int baseState
    {
        get => this._statusObject.status;
        set => this._statusObject.status = value;
    }
    protected Dictionary<int, Action> statusActions => _statusObject.statusActions;
    protected Dictionary<int, Action<float>> updateActions => _statusObject.updateActions;
    protected Dictionary<int, Action> leaveActions => _statusObject.leaveActions;
    private bool isStepComplete;
    
    private void Awake()
    {
        this._statusObject = new StatusObject();
        this._statusObject.ignoreSameState = true;

        this.statusActions[GameCtrlStatus.InitSetting] = this.runInitSetting;
        this.statusActions[GameCtrlStatus.UserLogin] = this.runUserLogin;
        this.statusActions[GameCtrlStatus.InitData] = this.runInitData;
        this.statusActions[GameCtrlStatus.InitSdk] = this.runInitSdk;
        this.statusActions[GameCtrlStatus.Stay] = this.runStay;
        this.updateActions[GameCtrlStatus.Stay] = this.updateStay;
        this.leaveActions[GameCtrlStatus.Stay] = this.leaveStay;
    }

    private void Start()
    {
        this.baseState = 1;
    }

    void Update()
    {
        this._statusObject.update(Time.deltaTime);
        if (this.isStepComplete) {
            this.isStepComplete = false;
            this.baseState += 1;
        }
    }

    void stepComplete()
    {
        this.isStepComplete = true;
    }

    void runInitSetting()
    {
        Debug.LogError("runInitSetting");
        Application.targetFrameRate = 60;
        this.stepComplete();
    }

    void runUserLogin()
    {
        Debug.LogError("runUserLogin");

        this.stepComplete();
    }

    void runInitData()
    {
        Debug.LogError("runInitData");
        {
            //读取设置数据
            MainData.Instance.LoadSaverIntoMainData(SaveID.Config);
            //读取永久存档数据
            MainData.Instance.LoadSaverIntoMainData(SaveID.BookSave);
            //读取战略模式存档数据
            MainData.Instance.LoadSaverIntoMainData(SaveID.AutoSave);
        }

        DataBaseManager.Instance.start();

        this.stepComplete();
    }

    void runInitSdk()
    {
        Debug.LogError("runInitSdk");

        this.stepComplete();
    }

    void runStay()
    {
        Debug.LogError("runStay");

        this.educationNode = new EducationNode();
        this.educationNode.start();
    }

    void updateStay(float dt)
    {
        this.educationNode.update(dt);
        DataBaseManager.Instance.update(dt);
    }

    void leaveStay()
    {
        this.educationNode.stop();
    }
}
