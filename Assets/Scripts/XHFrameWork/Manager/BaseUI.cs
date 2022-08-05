//BaseUI基本UI面板类，所有UI继承自这里（数据逻辑都继承自BaseModule，UI逻辑都继承自BaseUI）

using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace XHFrameWork
{
    public abstract class BaseUI : EventTriggerListener
    {
        //该界面是否激活键盘操作
        private bool ctrlerIsActive;
        public bool CtrlerIsActive
        {
            get
            {
                return ctrlerIsActive;
            }
            set
            {
                if (value == false)
                {
                    ctrlerIsActive = value;
                }
                else
                {
                    startWaitTimePoint = Time.realtimeSinceStartup;
                    waitToCtrlerIsActive = true;
                }
            }
        }
        private bool waitToCtrlerIsActive = false;//当waitToCtrlerIsActive为true时，计时解锁ctrlerIsActive激活键盘操作
        private float startWaitTimePoint = 0;//计时激活键盘操作时，用于缓存计时起始时间
        private float waitTime = 0.3f;//计时激活键盘操作的等待时间

        protected virtual bool needStatusObject => false;
        private StatusObject _statusObject;
        protected int baseState
        {
            get => _statusObject.status;
            set => _statusObject.status = value;
        }
        protected Dictionary<int, Action> statusActions => _statusObject.statusActions;
        protected Dictionary<int, Action<float>> updateActions => _statusObject.updateActions;
        protected Dictionary<int, Action> leaveActions => _statusObject.leaveActions;

        public event Action onDestroyAction;
        
        //用于控制UI是否加载完成允许操作
        protected bool UIReady = false;

        //弹窗界面所用的主节点，用于确定显示位置和播放弹出动画（从prefab挂入）
        public Transform UIbox;
        protected UI_pt_ShowType showPosType = UI_pt_ShowType.None;//显示位置的类型（None表示不改变显示位置）


        #region 键盘操作的参数声明
        protected bool AxisTg1 = true;
        protected bool AxisTg2 = true;
        protected bool AxisTg3 = true;
        protected bool AxisTg4 = true;
        protected int BtnTg1 = 0;
        protected int BtnTg2 = 0;
        protected float time = 0.3f;//按键延时时间
        protected float axisTime = 0.2f;//方向键延时时间
        private float tg1StartTimePoint = 0;//延时起始时间
        private float tg2StartTimePoint = 0;//延时起始时间
        private float tg3StartTimePoint = 0;//延时起始时间
        private float tg4StartTimePoint = 0;//延时起始时间

        protected EnumCtrlerType nowGetBtn = EnumCtrlerType.None;
        protected Dictionary<int, Button> btnDic;//按钮集
        protected Dictionary<int, Button> disBtnDic;//暂时禁用按钮集
        protected int firstBtnID = 0;//初始按钮，0为无初始按钮
        protected int oldBtnID = -1;
        private int NowBtnID = 0;//当前选中的按钮id
        public int nowBtnID
        {
            get
            {
                return NowBtnID;
            }
            private set
            {
                NowBtnID = value;
                NowBtnIDChanged();
            }
        }

        protected int changeType = 1;//改变类型（0为顺序，1为方向就近捕捉）
        protected Dictionary<int, Vector2> rectPtDic;//对应可选按钮的坐标集，方向就近捕捉时使用

        //鼠标移入事件的事件集    
        EventTriggerListener btnEvent;
        private event OnTouchEventHandle btnEventHandle = null;

        #endregion

        #region 键盘操作的捕捉
        //监查获得键盘操作/手柄操作
        protected virtual void CtrlerWatch()
        {
            //检查和发送操作方式变化的消息，使界面对操作显示进行刷新
            bool isChanged = CheckInputType();

            //操作界面因操作方式变化（手柄/键鼠更换）而发生切换时，本次操作不生效（以免玩家误操作）
            if (isChanged)
            { }
            //否则进行生效效果
            else
            {
                if (UIReady)
                {
                    if (Input.GetButtonDown("Yes"))
                    {
                        nowGetBtn = EnumCtrlerType.Yes;
                    }
                    if (Input.GetButton("Yes"))
                    {
                        BtnTg1++;
                        if (BtnTg1 >= 60)
                        {
                            nowGetBtn = EnumCtrlerType.Yes;
                            BtnTg1 = 0;
                        }
                    }
                    if (Input.GetButtonUp("Yes"))
                    {
                        BtnTg1 = 0;
                    }
                    if (Input.GetButtonDown("No"))
                    {
                        nowGetBtn = EnumCtrlerType.No;
                    }
                    if (Input.GetButton("No"))
                    {
                        BtnTg2++;
                        if (BtnTg2 >= 60)
                        {
                            nowGetBtn = EnumCtrlerType.No;
                            BtnTg2 = 0;
                        }
                    }
                    if (Input.GetButtonUp("No"))
                    {
                        BtnTg2 = 0;
                    }
                    if (Input.GetButtonDown("Fire3"))
                    {
                        nowGetBtn = EnumCtrlerType.Fire3;
                    }
                    if (Input.GetButtonDown("MouseL"))
                    {
                        nowGetBtn = EnumCtrlerType.MouseL;
                    }

                    float btnY = Input.GetAxisRaw("Vertical");
                    float btnX = Input.GetAxisRaw("Horizontal");

                    if (Mathf.Abs(btnY) >= Mathf.Abs(btnX))
                    {
                        if (btnY > 0.1)
                        {
                            if (AxisTg1 == true)
                            {
                                nowGetBtn = EnumCtrlerType.Up;
                                AxisTg1 = false;
                                tg1StartTimePoint = Time.realtimeSinceStartup;
                            }
                        }
                        else if (btnY < -0.1)
                        {
                            if (AxisTg2 == true)
                            {
                                nowGetBtn = EnumCtrlerType.Down;
                                AxisTg2 = false;
                                tg2StartTimePoint = Time.realtimeSinceStartup;
                            }
                        }
                        else
                        {
                            AxisTg1 = true;
                            AxisTg2 = true;
                        }
                    }
                    else
                    {
                        if (btnX > 0.1)
                        {
                            if (AxisTg3 == true)
                            {
                                nowGetBtn = EnumCtrlerType.Right;
                                AxisTg3 = false;
                                tg3StartTimePoint = Time.realtimeSinceStartup;
                            }
                        }
                        else if (btnX < -0.1)
                        {
                            if (AxisTg4 == true)
                            {
                                nowGetBtn = EnumCtrlerType.Left;
                                AxisTg4 = false;
                                tg4StartTimePoint = Time.realtimeSinceStartup;
                            }
                        }
                        else
                        {
                            AxisTg3 = true;
                            AxisTg4 = true;
                        }
                    }

                    //检查方向延时是否应结束
                    TgUpdate();

                    if (nowGetBtn != EnumCtrlerType.None)
                    {
                        //将键盘按键类型传给处理按键的方法
                        CheckBtn(nowGetBtn);
                    }
                    nowGetBtn = EnumCtrlerType.None;
                }
            }
        }

        //小方法：检查方向延时是否应结束
        private void TgUpdate()
        {
            //方向连按延时器1
            if (!AxisTg1)
            {
                if (Time.realtimeSinceStartup > tg1StartTimePoint + axisTime)
                {
                    AxisTg1 = true;
                }
            }
            //方向连按延时器2
            if (!AxisTg2)
            {
                if (Time.realtimeSinceStartup > tg2StartTimePoint + axisTime)
                {
                    AxisTg2 = true;
                }
            }
            //方向连按延时器3
            if (!AxisTg3)
            {
                if (Time.realtimeSinceStartup > tg3StartTimePoint + axisTime)
                {
                    AxisTg3 = true;
                }
            }
            //方向连按延时器4
            if (!AxisTg4)
            {
                if (Time.realtimeSinceStartup > tg4StartTimePoint + axisTime)
                {
                    AxisTg4 = true;
                }
            }
        }
        #endregion

        #region 键盘操作的处理
        //处理传入的按键(主方法)
        protected virtual void CheckBtn(EnumCtrlerType nowGetBtn)
        {
            //如果为0（顺序位），则自动取左右;    1则捕捉对应方向的按钮；   2则在对应UI脚本内按照特定规则响应
            if (changeType == 0)
            {
                CatchBtnById();
            }
            else if (changeType == 1)
            {
                CatchBtnByArrow();
            }
            else if (changeType == 2)
            {
                CatchBtnBySpcPlan();
            }
        }

        //处理按键方案0：按照id顺序获取对应的按钮
        private void CatchBtnById()
        {
            switch (nowGetBtn)
            {
                case EnumCtrlerType.Left:
                    SetNowBtn(-1);
                    break;
                case EnumCtrlerType.Right:
                    SetNowBtn(1);
                    break;
                case EnumCtrlerType.Up:
                    SetNowBtn(-1);
                    break;
                case EnumCtrlerType.Down:
                    SetNowBtn(1);
                    break;
                case EnumCtrlerType.Yes:
                    if (btnDic.ContainsKey(nowBtnID))
                    {
                        EnterNowBtn();
                    }
                    break;
                case EnumCtrlerType.No:
                    NoBtnEvent();
                    break;
                case EnumCtrlerType.Fire3:
                    Fire3BtnEvent();
                    break;
                case EnumCtrlerType.MouseL:
                    //一般不专门响应鼠标左键的点击行为
                    break;
                default:
                    Debug.Log("Not Find input btn type: " + nowGetBtn.ToString());
                    break;
            }
        }

        //处理按键方案1：按键按照方向捕捉对应方向的按钮
        private void CatchBtnByArrow()
        {
            switch (nowGetBtn)
            {
                case EnumCtrlerType.Left:
                    SetBtnByCatch();
                    break;
                case EnumCtrlerType.Right:
                    SetBtnByCatch();
                    break;
                case EnumCtrlerType.Up:
                    SetBtnByCatch();
                    break;
                case EnumCtrlerType.Down:
                    SetBtnByCatch();
                    break;
                case EnumCtrlerType.Yes:
                    if (btnDic.ContainsKey(nowBtnID))
                    {
                        EnterNowBtn();
                    }
                    break;
                case EnumCtrlerType.No:
                    NoBtnEvent();
                    break;
                case EnumCtrlerType.Fire3:
                    Fire3BtnEvent();
                    break;
                case EnumCtrlerType.MouseL:
                    //一般不专门响应鼠标左键的点击行为
                    break;
                default:
                    Debug.Log("Not Find input btn type: " + nowGetBtn.ToString());
                    break;
            }
        }

        //处理按键方案2：在对应UI脚本内按照特定规则响应
        protected virtual void CatchBtnBySpcPlan()
        {
            switch (nowGetBtn)
            {
                case EnumCtrlerType.Left:
                    SetNowBtn(-1);
                    break;
                case EnumCtrlerType.Right:
                    SetNowBtn(1);
                    break;
                case EnumCtrlerType.Up:
                    SetNowBtn(-1);
                    break;
                case EnumCtrlerType.Down:
                    SetNowBtn(1);
                    break;
                case EnumCtrlerType.Yes:
                    if (btnDic.ContainsKey(nowBtnID))
                    {
                        EnterNowBtn();
                    }
                    break;
                case EnumCtrlerType.No:
                    NoBtnEvent();
                    break;
                case EnumCtrlerType.Fire3:
                    Fire3BtnEvent();
                    break;
                case EnumCtrlerType.MouseL:
                    //一般不专门响应鼠标左键的点击行为
                    break;
                default:
                    Debug.Log("Not Find input btn type: " + nowGetBtn.ToString());
                    break;
            }
        }

        //具体的捕捉方向(此时按键必然是方向键)
        protected void SetBtnByCatch()
        {
            if (nowBtnID != 0)
            {
                float closestDistance = -1;
                float nowDistance;
                int closestBtnId = 0;

                GetBtnPosition();//刷新1次全按钮坐标

                foreach (KeyValuePair<int, Vector2> kvp in rectPtDic)
                {
                    //当前按钮id有现成坐标取坐标
                    if (rectPtDic.ContainsKey(nowBtnID))
                    {
                        //计算方向和距离，返回距离的平方值(方向不对时返回0)
                        nowDistance = CheckBtnCatch(rectPtDic[nowBtnID], kvp.Value);
                    }
                    //当前按钮id没现成坐标，有按钮取按钮坐标
                    else
                    if (btnDic.ContainsKey(nowBtnID))
                    {
                        nowDistance = CheckBtnCatch(btnDic[nowBtnID].transform.GetComponent<RectTransform>().position, kvp.Value);
                    }
                    //当前按钮id没按钮坐标，有禁用按钮坐标取禁用按钮坐标
                    else if (disBtnDic.ContainsKey(nowBtnID))
                    {
                        //计算方向和距离，返回距离的平方值(方向不对时返回0)
                        nowDistance = CheckBtnCatch(disBtnDic[nowBtnID].transform.GetComponent<RectTransform>().position, kvp.Value);
                    }
                    //当前按钮id啥都没就直接变更为取第一个按钮
                    else
                    {
                        nowDistance = 0;
                        closestBtnId = rectPtDic.Keys.First();
                        break;
                    }

                    if (nowDistance != 0)
                    {
                        if (closestDistance == -1)
                        {
                            closestDistance = nowDistance;
                            closestBtnId = kvp.Key;
                        }
                        if (closestDistance > nowDistance)
                        {
                            closestDistance = nowDistance;
                            closestBtnId = kvp.Key;
                        }
                    }
                }

                //如果该方向有按钮则高亮最近的那个
                if (closestBtnId != 0)
                {
                    GetBtns(closestBtnId);
                }
            }
            else
            {
                if (rectPtDic.Count > 0)
                {
                    GetBtns(rectPtDic.Keys.First());
                }
                else
                {
                    UIManager.Instance.CloseUI(GetUIType());
                }
            }
        }

        //计算方向和距离，返回距离的平方值(方向不对时返回0)--算距离时，对应方向的距离计算减成（除以3，表示方向越正越应被获取）
        private float CheckBtnCatch(Vector3 thisPt, Vector3 targetPt)
        {
            float dX = Mathf.Abs(targetPt.x - thisPt.x);
            float dY = Mathf.Abs(targetPt.y - thisPt.y);
            switch (nowGetBtn)
            {
                case EnumCtrlerType.Left:
                    if ((thisPt.x > targetPt.x) && (dX > dY))
                    {
                        dX = dX / 3;
                        return dX * dX + dY * dY;
                    }
                    break;
                case EnumCtrlerType.Right:
                    if ((thisPt.x < targetPt.x) && (dX > dY))
                    {
                        dX = dX / 3;
                        return dX * dX + dY * dY;
                    }
                    break;
                case EnumCtrlerType.Up:
                    if ((thisPt.y < targetPt.y) && (dX < dY))
                    {
                        dY = dY / 3;
                        return dX * dX + dY * dY;
                    }
                    break;
                case EnumCtrlerType.Down:
                    if ((thisPt.y > targetPt.y) && (dX < dY))
                    {
                        dY = dY / 3;
                        return dX * dX + dY * dY;
                    }
                    break;
                default:
                    Debug.Log("Not Find input btn type: " + nowGetBtn.ToString());
                    break;
            }
            return 0;
        }
        #endregion

        #region 按键处理可选用的方法
        //待重写的当前选择按钮改变时的附带事件内容(默认空)
        protected virtual void NowBtnIDChanged() { }
        //待重写的No按键方法(默认关闭对应UI)
        public virtual void NoBtnEvent()
        {
            UIManager.Instance.CloseUI(this.GetUIType());
        }
        //待重写的Fire3按键方法(默认无)
        public virtual void Fire3BtnEvent() { Debug.Log("按键：Fire3"); }
        //待重写的对应按键选中方法
        public virtual void SelectNowBtn() { }
        //待重写的按键进入方法（用于键盘进入）
        public virtual void EnterNowBtn() { }
        //更改按钮记录并点亮对应id的按钮
        private void GetBtns(int _id)
        {
            if (nowBtnID != 0)
            {
                oldBtnID = nowBtnID;
            }
            nowBtnID = _id;

            SetNowBtn();//只高亮选中的按钮
            SelectNowBtn();//选中按钮时执行的事件
        }
        //根方法：只高亮选中的按钮
        private void SetNowBtn()
        {
            if (nowBtnID != 0)
            {
                btnDic[nowBtnID].Select();
                if (oldBtnID != -1)
                {
                    if (btnDic.ContainsKey(oldBtnID))
                    {
                        if (btnDic[oldBtnID].transform.Find("choice"))
                            btnDic[oldBtnID].transform.Find("choice").gameObject.SetActive(false);
                    }
                    else if (disBtnDic.ContainsKey(oldBtnID))
                    {
                        if (disBtnDic[oldBtnID].transform.Find("choice"))
                            disBtnDic[oldBtnID].transform.Find("choice").gameObject.SetActive(false);
                    }
                }
                if (btnDic[nowBtnID].transform.Find("choice"))
                    btnDic[nowBtnID].transform.Find("choice").gameObject.SetActive(true);
            }
            else
            {
                foreach (int i in btnDic.Keys)
                {
                    if (btnDic[i].transform.Find("choice"))
                        btnDic[i].transform.Find("choice").gameObject.SetActive(false);
                }
            }
        }
        //重载1:输入i=-1时往回选一个，i=1时下选一个
        private void SetNowBtn(int i)
        {
            if (nowBtnID != 0)
            {
                if ((i == -1) && (nowBtnID != 1))
                {
                    oldBtnID = nowBtnID;
                    nowBtnID += i;
                }
                else if ((i == 1) && (nowBtnID != btnDic.Count))
                {
                    oldBtnID = nowBtnID;
                    nowBtnID += i;
                }

                SetNowBtn();
            }
            else
            {
                nowBtnID = 1;
                SetNowBtn();
            }
        }
        //鼠标移入对应按钮框体时高亮的方法
        protected virtual void BtnMoveIn(GameObject _listener, object _args, params object[] _params)
        {
            Button a = _listener.GetComponent<Button>();
            foreach (KeyValuePair<int, Button> kvp in btnDic)
            {
                if (kvp.Value.Equals(a))
                {
                    GetBtns(kvp.Key);
                    break;
                }
            }
        }
        //获取按钮的坐标集，start中和按钮状态改变时使用，用于捕捉就近按钮(使用的是世界坐标而不是ugui的anchoredPosition坐标，因为anchoredPosition坐标是本地坐标，没转化成屏幕坐标)
        private void GetBtnPosition()
        {
            foreach (KeyValuePair<int, Button> kvp in btnDic)
            {
                if (rectPtDic.ContainsKey(kvp.Key))
                    rectPtDic[kvp.Key] = kvp.Value.transform.GetComponent<RectTransform>().position;
                else
                    rectPtDic.Add(kvp.Key, kvp.Value.transform.GetComponent<RectTransform>().position);
            }
        }

        //按钮集对应按钮禁用（原理：将对应id的按钮从btnDic移到disBtnDic）
        protected void DisActiveBtn(int _btnId)
        {
            if (btnDic.ContainsKey(_btnId))
            {
                btnDic[_btnId].interactable = false;
                disBtnDic.Add(_btnId, btnDic[_btnId]);
                btnDic.Remove(_btnId);
                //更新按钮捕捉坐标集
                if (rectPtDic.ContainsKey(_btnId))
                {
                    rectPtDic.Remove(_btnId);
                }
            }
            else if (!disBtnDic.ContainsKey(_btnId))
            {
                //如果两个按钮集都没找到这个id，则报错
                Debug.Log("_btnId cant find:" + _btnId.ToString());
            }
        }
        //按钮集对应按钮解禁（原理：将对应id的按钮从disBtnDic移到btnDic）
        protected void ActiveBtn(int _btnId)
        {
            if (disBtnDic.ContainsKey(_btnId))
            {
                btnDic.Add(_btnId, disBtnDic[_btnId]);
                disBtnDic.Remove(_btnId);
                btnDic[_btnId].interactable = true;

                //更新按钮捕捉坐标集
                if (!rectPtDic.ContainsKey(_btnId))
                {
                    rectPtDic.Add(_btnId, btnDic[_btnId].transform.GetComponent<RectTransform>().position);
                }
            }
            else if (!btnDic.ContainsKey(_btnId))
            {
                //如果两个按钮集都没找到这个id，则报错
                Debug.Log("_btnId cant find:" + _btnId.ToString());
            }
        }

        #endregion

        //定义物体缓存 与 坐标缓存
        #region Cache GameObject & Transform
        //定义坐标缓存
        private Transform _CachedTransform;
        public Transform cachedTransform
        {
            get
            {
                if (!_CachedTransform)
                {
                    _CachedTransform = this.transform;
                }
                return _CachedTransform;
            }
        }

        //定义物体缓存
        private GameObject _CachedGameObject;
        public GameObject cachedGameObject
        {
            get
            {
                if (!_CachedGameObject)
                {
                    _CachedGameObject = this.gameObject;
                }
                return _CachedGameObject;
            }
        }
        #endregion

        //定义UI类型和状态
        #region UIType & EnumObjectState

        //UI初始状态为None未知
        protected EnumObjectState state = EnumObjectState.None;

        //定义事件-UI状态改变
        public event StateChangedEvent StateChanged;

        //定义枚举状态（StateChanged事件取变更前后的状态）
        public EnumObjectState State
        {
            protected set
            {
                if (value != state)
                {
                    EnumObjectState oldState = state;
                    state = value;
                    if (null != StateChanged)
                    {
                        StateChanged(this, state, oldState);
                    }
                }
            }
            get { return this.state; }
        }

        //获得UI类型的抽象类（类型枚举）
        //抽象abstract类只能作为基类被继承，不能直接使用，功
        //能靠各个继承类的重写override实现
        public abstract EnumUIType GetUIType();

        #endregion

        //UI主体代码
        #region Start-Awake-Update-Release-ReActive

        //UI层级置顶
        protected virtual void SetDepthToTop()
        {
        }

        void Start()
        {
            btnDic = new Dictionary<int, Button>();
            disBtnDic = new Dictionary<int, Button>();

            rectPtDic = new Dictionary<int, Vector2>();
            CtrlerIsActive = false;

            OnStart();
        }

        void Awake()
        {
            //UI状态为初始化
            this.State = EnumObjectState.Initial;
            OnAwake();
        }

        void Update()
        {
            var dt = Time.deltaTime;
            if (this.needStatusObject) {
                this._statusObject.update(Time.deltaTime);
            }
            //状态为准备好时，进行OnUpdate(Time.deltaTime);
            if (EnumObjectState.Ready == this.state)
            {
                OnUpdate(Time.fixedDeltaTime);
            }
        }

        private void OnDestroy()
        {
            this.destroyAction();
        }

        //关闭UI并释放
        public void Release()
        {
            if (this.needStatusObject) {
                this._statusObject.clearStatus();
                this._statusObject.clearAction();
            }
            this.State = EnumObjectState.Closing;
            GameObject.Destroy(cachedGameObject);
            OnRelease();
        }

        //真Start
        protected virtual void OnStart()
        {
            if (this.needStatusObject) {
                this._statusObject = new StatusObject();
            }

            if (UIbox != null)ResetUIPosition();

            //获取按钮的坐标集，start中使用，用于捕捉就近按钮
            GetBtnPosition();
            //给按钮新增鼠标移入时高亮的方法
            btnEventHandle += BtnMoveIn;
            foreach (KeyValuePair<int, Button> kvp in btnDic)
            {
                btnEvent = Get(kvp.Value.gameObject);
                btnEvent.SetEventHandle(EnumTouchEventType.OnEnter, btnEventHandle);
            }
            foreach (KeyValuePair<int, Button> kvp in disBtnDic)
            {
                btnEvent = Get(kvp.Value.gameObject);
                btnEvent.SetEventHandle(EnumTouchEventType.OnEnter, btnEventHandle);
            }

            //初始化按钮集和默认选中按钮的id
            GetBtns(firstBtnID);

            //切换显示键鼠提示/手柄提示 by MainData
            ShowKeyboardOrGamePad(MainData.Instance.isKeyboardOrGamePad);
        }

        //真Awake-Awake时伴随的行为加在这里
        protected virtual void OnAwake()
        {
            this.State = EnumObjectState.Loading;
        }

        //真Update-Update时伴随的行为加在这里
        protected virtual void OnUpdate(float deltaTime)
        {
            //计时激活按键操作的等待逻辑
            if (waitToCtrlerIsActive)
            {
                if (Time.realtimeSinceStartup > startWaitTimePoint + waitTime)
                {
                    waitToCtrlerIsActive = false;
                    ctrlerIsActive = true;
                }
            }

            //是否被激活了按键操作
            if (CtrlerIsActive)
            {
                CtrlerWatch();
            }

            if (Input.GetKeyDown(KeyCode.Mouse0)) AudioManager.Instance.PlaySound(EnumSoundType.UI_touch);
        }

        //释放时伴随的行为加在这里
        protected virtual void OnRelease()
        {
            this.OnPlayCloseUIAudio();
        }

        protected virtual void destroyAction()
        {
            if (this.needStatusObject) {
                this._statusObject = null;
            }
            
            this.onDestroyAction?.Invoke();
            this.onDestroyAction = null;
        }

        //播放打开界面音乐
        protected virtual void OnPlayOpenUIAudio()
        {
            AudioManager.Instance.PlaySound(this.gameObject, EnumSoundType.UI_Open);
        }

        // 播放关闭界面音乐
        protected virtual void OnPlayCloseUIAudio()
        {
            //AudioManager.Instance.PlaySound(EnumSoundType.BadMsg);
        }

        //UI正在打开时的设置（传入UI参数暂无意义,可重写）
        protected virtual void SetUI(params object[] uiParams)
        {
            this.State = EnumObjectState.Loading;

            //播放音乐
            this.OnPlayOpenUIAudio();
        }

        //UI正在打开时的参数设置（传入UI参数暂无意义，可重写）        //传输不定数量的参数用params
        public virtual void SetUIparam(params object[] uiParams)
        {

        }

        //加载资源时的数据和界面操作
        protected virtual void OnLoadData()
        {
        }

        //当正在打开UI时，1SetUI（传入参数），2协同loading资源以打开UI
        public void SetUIWhenOpening(params object[] uiParams)
        {
            SetUI(uiParams);
            CoroutineController.Instance.StartCoroutine(AsyncOnLoadData());
        }

        //协同loading资源的内容
        private IEnumerator AsyncOnLoadData()
        {
            yield return new WaitForSeconds(0);
            if (this.State == EnumObjectState.Loading)
            {
                this.OnLoadData();
                this.State = EnumObjectState.Ready;
            }
        }

        //前方弹窗被关闭，导致本UI自己被重新激活时
        public virtual void ReActiveEvent()
        {
            Debug.Log("已回到" + name + "界面");
        }

        //重定UI所在位置
        public virtual void ResetUIPosition()
        {
            if (showPosType == UI_pt_ShowType.None) return;

            switch (showPosType)
            {
                case UI_pt_ShowType.Normal:
                    {
                        RectTransformExtensions.SetPivot(UIbox.GetComponent<RectTransform>(), PivotPresets.MiddleCenter);
                        RectTransformExtensions.SetAnchor(UIbox.GetComponent<RectTransform>(), AnchorPresets.MiddleCenter);
                    }
                    break;
                case UI_pt_ShowType.Left:
                    {
                        RectTransformExtensions.SetPivot(UIbox.GetComponent<RectTransform>(), PivotPresets.MiddleLeft);
                        RectTransformExtensions.SetAnchor(UIbox.GetComponent<RectTransform>(), AnchorPresets.MiddleLeft, 150, 0);
                    }
                    break;
                case UI_pt_ShowType.Right:
                    {
                        RectTransformExtensions.SetPivot(UIbox.GetComponent<RectTransform>(), PivotPresets.MiddleRight);
                        RectTransformExtensions.SetAnchor(UIbox.GetComponent<RectTransform>(), AnchorPresets.MiddleRight, -150, 0);
                    }
                    break;
            }
        }
        #endregion

        //键鼠/手柄的提示显示切换
        #region 键鼠/手柄显示切换    
        //检查输入类型 返回bool值是否发生了切换
        bool CheckInputType()
        {
            //任何按键
            if (Input.anyKeyDown)
            {
                //如果是手柄，则检查可能需要切换的键鼠显示
                if (!MainData.Instance.isKeyboardOrGamePad)
                {
                    if (Input.GetKeyDown(KeyCode.Z) ||
                        Input.GetKeyDown(KeyCode.X) ||
                        Input.GetKeyDown(KeyCode.C) ||
                        Input.GetKeyDown(KeyCode.Space) ||
                        Input.GetKeyDown(KeyCode.Escape) ||
                        Input.GetKeyDown(KeyCode.Mouse0) ||
                        Input.GetKeyDown(KeyCode.Mouse1) ||
                        Input.GetKeyDown(KeyCode.UpArrow) ||
                        Input.GetKeyDown(KeyCode.DownArrow) ||
                        Input.GetKeyDown(KeyCode.LeftArrow) ||
                        Input.GetKeyDown(KeyCode.RightArrow) ||
                        Input.GetKeyDown(KeyCode.Return))
                    {
                        //键盘输入
                        Debug.Log("切换为键盘鼠标输入");
                        MainData.Instance.isKeyboardOrGamePad = true;
                        ShowKeyboardOrGamePad(MainData.Instance.isKeyboardOrGamePad);//刷新切换 键鼠/手柄的提示显示
                        return true;
                    }
                }
                //如果是键鼠，则检查可能需要切换的手柄显示
                else
                {
                    if (Input.GetKeyDown(KeyCode.JoystickButton0) ||
                 Input.GetKeyDown(KeyCode.JoystickButton1) ||
                 Input.GetKeyDown(KeyCode.JoystickButton2) ||
                 Input.GetKeyDown(KeyCode.JoystickButton3) ||
                 Input.GetKeyDown(KeyCode.JoystickButton4) ||
                 Input.GetKeyDown(KeyCode.JoystickButton5) ||
                 Input.GetKeyDown(KeyCode.JoystickButton6) ||
                 Input.GetKeyDown(KeyCode.JoystickButton7) ||
                 Input.GetKeyDown(KeyCode.JoystickButton8) ||
                 Input.GetKeyDown(KeyCode.JoystickButton9) ||
                 Input.GetKeyDown(KeyCode.JoystickButton10) ||
                 Input.GetKeyDown(KeyCode.JoystickButton11) ||
                 Input.GetKeyDown(KeyCode.JoystickButton12) ||
                 Input.GetKeyDown(KeyCode.JoystickButton13) ||
                 Input.GetKeyDown(KeyCode.JoystickButton14) ||
                 Input.GetKeyDown(KeyCode.JoystickButton15) ||
                 Input.GetKeyDown(KeyCode.JoystickButton16) ||
                 Input.GetKeyDown(KeyCode.JoystickButton17) ||
                 Input.GetKeyDown(KeyCode.JoystickButton18) ||
                 Input.GetKeyDown(KeyCode.JoystickButton19))
                    {
                        //键盘输入
                        Debug.Log("切换为手柄输入");
                        MainData.Instance.isKeyboardOrGamePad = false;
                        ShowKeyboardOrGamePad(MainData.Instance.isKeyboardOrGamePad);//刷新切换 键鼠/手柄的提示显示
                        return true;
                    }
                }

                return false;
            }
            return false;
        }
        
        //刷新切换 键鼠/手柄的提示显示(待加写)
        protected virtual void ShowKeyboardOrGamePad(bool _isKeyboardOrGamePad)
        {
            //显示/隐藏鼠标
            if (_isKeyboardOrGamePad)
            {
                //Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;//解锁并显示鼠标
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;//锁定并隐藏鼠标
                //Cursor.visible = false;//这个只隐藏鼠标，不锁定，所以不用
            }
        }

        #endregion

    }

}

