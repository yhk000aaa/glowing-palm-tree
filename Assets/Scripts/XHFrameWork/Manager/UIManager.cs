//UI管理器，单例类型

using System;
using System.Collections.Generic;
using UnityEngine;

namespace XHFrameWork
{

	public class UIManager : Singleton<UIManager>
    {
        #region 定义UI数据类

        //定义UI数据类
		class UIInfoData
		{
            //类型
			public EnumUIType UIType { get; private set; }
            //脚本
			public Type ScriptType { get; private set; }
			//路径
			public string Path { get; private set; }
			//参数
            public object[] UIParams { get; private set; }
			
            //数据函数
            public UIInfoData(EnumUIType _uiType, string _path, params object[] _uiParams)
			{
				this.UIType = _uiType;
				this.Path = _path;
				this.UIParams = _uiParams;
				this.ScriptType = UIPath.GetUIScript(this.UIType);
			}
		}
		#endregion

        #region 实例化UI集合类
        //已打开UI的Dictionary集合类，键（UI类型）和值（UI对象）的集合
		private Dictionary<EnumUIType, GameObject> dicOpenUIs = null;
        //需打开UI的Stack集合类（后进先出）
		private Stack<UIInfoData> stackOpenUIs = null;
        private Stack<BaseUI> ctrlActiveUIs;
		
		//UI挂点
		public Transform UICanvasTr;

		//初始化
		public override void Init ()
		{
			dicOpenUIs = new Dictionary<EnumUIType, GameObject>();
			stackOpenUIs = new Stack<UIInfoData>();
            ctrlActiveUIs = new Stack<BaseUI>();
		}
        #endregion

        #region 获取UI对象 by UI类型
        //使用UI类型来获取UI对象（约束T继承自BaseUI）
        public T GetUI<T>(EnumUIType _uiType) where T : BaseUI
		{
			GameObject _retObj = GetUIObject(_uiType);
			if (_retObj != null)
			{
				return _retObj.GetComponent<T>();
			}
			return null;
		}

		//获取对象
		//传入UI类型
        //返回UI对象
		public GameObject GetUIObject(EnumUIType _uiType)
		{
			GameObject _retObj = null;
			if (!dicOpenUIs.TryGetValue(_uiType, out _retObj))
				throw new Exception("dicOpenUIs TryGetValue Failure! _uiType :" + _uiType.ToString());
			return _retObj;
		}
		#endregion
        		
		#region 预加载UI Prefab资源 by UI类型
		//预加载UI（重载1：预加载多个UI对象 by UI类型s）
		public void PreloadUI(EnumUIType[] _uiTypes)
		{
			for (int i=0; i<_uiTypes.Length; i++)
			{
				PreloadUI(_uiTypes[i]);
			}
		}

        //预加载UI（根方法：预加载单个UI对象 by UI类型）
		public void PreloadUI(EnumUIType _uiType)
		{
            //加载对应路径的资源
			string path = UIPath.GetUIPath(_uiType);
			Resources.Load(path);
		}
		#endregion

        #region 打开UI By UI类型  （协程打开UI&load资源）
        //打开UI（重载1：By UI类型集合），用于一次性打开多个UI
        public void OpenUI(EnumUIType[] uiTypes)
        {
            OpenUI(false, uiTypes, null);
        }

        //打开UI（重载2：By UI类型&UI参数），用于打开单个UI并传入参数
        public void OpenUI(EnumUIType uiType, params object[] uiObjParams)
		{
			EnumUIType[] uiTypes = new EnumUIType[1];
			uiTypes[0] = uiType;
			OpenUI(false, uiTypes, uiObjParams);
		}

        //打开UI时关闭其他UI（重载1：By UI类型集合），用于一次性打开多个UI并关闭其他UI
		public void OpenUICloseOthers(EnumUIType[] uiTypes)
		{
			OpenUI(true, uiTypes, null);
		}

        //打开UI时关闭其他UI（重载2：By UI类型&UI参数）用于打开单个UI并传入参数并关闭其他UI
        public void OpenUICloseOthers(EnumUIType uiType, params object[] uiObjParams)
		{
			EnumUIType[] uiTypes = new EnumUIType[1];
			uiTypes[0] = uiType;
			OpenUI(true, uiTypes, uiObjParams);
		}

        //打开UI（根方法。By 是否关闭其他UI&UI类型&UI参数）
		private void OpenUI(bool _isCloseOthers, EnumUIType[] _uiTypes, params object[] _uiParams)
		{
			// 关闭其他UI
			if (_isCloseOthers)
			{
				CloseUIAll();
			}
            // 把要打开的UIs 一个个加进 stackOpenUIs（要打开的stack集合）
			for (int i=0; i<_uiTypes.Length; i++)
			{
				EnumUIType _uiType = _uiTypes[i];
				//判断该UI没有在已打开UI字典集中时才处理（新打开的UI自带键盘激活状态）
                if (!dicOpenUIs.ContainsKey(_uiType))
                {
                    //找到UI类型对应的prefab资源路径
                    string _path = UIPath.GetUIPath(_uiType);
                    //将要打开的UI 加进 stackOpenUIs（要打开的stack集合）
                    stackOpenUIs.Push(new UIInfoData(_uiType, _path, _uiParams));
                }
			}
            // 依照stackOpenUIs（要打开的stack集合）来打开 UI.
			if (stackOpenUIs.Count > 0)
			{
                //协程加载UI（使用继承自DDOL单例类的协程控制器）
				CoroutineController.Instance.StartCoroutine(AsyncLoadData());
			}
		}

        //协程内容
		private IEnumerator<int> AsyncLoadData()
		{
            //UI信息（类型、脚本、路径、参数）
			UIInfoData _uiInfoData = null;
            //UI prefab资源
            UnityEngine.Object _prefabObj = null;
            //UI对象
			GameObject _uiObject = null;

			if (stackOpenUIs != null && stackOpenUIs.Count > 0)
			{
				do 
				{
					//从待打开UIstack集取出一个UI信息（越取越少）
                    _uiInfoData = stackOpenUIs.Pop();
                    //按照信息里的路径加载对应的prefab资源
					_prefabObj = Resources.Load(_uiInfoData.Path);
					if (_prefabObj != null)
					{
                        //转UI prefab资源为游戏UI对象
						_uiObject = MonoBehaviour.Instantiate(_prefabObj, UICanvasTr) as GameObject;
						//取该UI对象的脚本
                        BaseUI _baseUI = _uiObject.GetComponent<BaseUI>();
						
                        //如果没脚本，依照信息里的脚本类型加一个脚本
                        if (null == _baseUI)
						{
							_baseUI = _uiObject.AddComponent(_uiInfoData.ScriptType) as BaseUI;
						}
                        //如果有脚本，执行脚本里的打开UI方法
						if (null != _baseUI)
						{
							_baseUI.SetUIWhenOpening(_uiInfoData.UIParams);
						}
                        //已打开UI字典集增加该UI
						dicOpenUIs.Add(_uiInfoData.UIType, _uiObject);
                        
                        //键盘激活顺序的UI栈新增该UI
                        if (ctrlActiveUIs.Count != 0)
                        {
                            ctrlActiveUIs.Peek().CtrlerIsActive = false;
                        }
                        _baseUI.CtrlerIsActive = true;
                        ctrlActiveUIs.Push(_baseUI);
					}

				} while(stackOpenUIs.Count > 0);
			}
			yield return 0;
		}

		#endregion
        
		#region 关闭 UI By UI类型

		// 关闭界面(重载1：关闭单个UI by UI类型)
		public void CloseUI(EnumUIType _uiType)
		{
			GameObject _uiObj = null;
            
            //TryGetValue：Dictionary方法，获取与指定的键相关联的值（UI对象），用于判断该对象是否已打开
			if (!dicOpenUIs.TryGetValue(_uiType, out _uiObj))
			{
				Debug.Log("dicOpenUIs TryGetValue Failure! _uiType :" + _uiType.ToString());
				return;
			}
            CloseUI(_uiType, _uiObj);
		}


        // 关闭界面（重载2：关闭多个UI by UI类型s）
		public void CloseUI(EnumUIType[] _uiTypes)
		{
			for (int i=0; i<_uiTypes.Length; i++)
			{
				CloseUI(_uiTypes[i]);
			}
		}
		
		// 关闭所有UI界面
		public void CloseUIAll()
		{
			List<EnumUIType> _keyList = new List<EnumUIType>(dicOpenUIs.Keys);
			foreach (EnumUIType _uiType in _keyList)
			{
				GameObject _uiObj = dicOpenUIs[_uiType];
				CloseUI(_uiType, _uiObj);
			}
			dicOpenUIs.Clear();
			ctrlActiveUIs.Clear();
		}

        // 关闭界面（根方法，关闭单个UI by UI类型&UI对象）
		private void CloseUI(EnumUIType _uiType, GameObject _uiObj)
		{
			if (_uiObj == null)
			{
				dicOpenUIs.Remove(_uiType);
			}
			else
			{
				BaseUI _baseUI = _uiObj.GetComponent<BaseUI>();

				//对象有挂脚本时调用脚本的Release，没挂就直接摧毁
                if (_baseUI != null)
				{
                    //键盘激活顺序的UI栈重新激活前一UI
                    if (ctrlActiveUIs.Peek().gameObject == _uiObj)
                    {
                        ctrlActiveUIs.Pop();
                        if (ctrlActiveUIs.Count != 0)
                        {
							BaseUI lastUI = ctrlActiveUIs.Peek();
							lastUI.CtrlerIsActive = true;
							lastUI.ReActiveEvent();//前方弹窗被关闭，导致本UI自己被重新激活，处理相关事件
						}
                    }

                    //在baseUI的状态改变事件StateChanged中 压入 CloseUIHandler（当UI状态为关闭中时，将UI类型从已打开UI字典集 中剔除的行为）
                    _baseUI.StateChanged += CloseUIHandler;
					//释放该UI
                    _baseUI.Release();
                    //释放UI时改变了_baseUI的state，在state的set方法里会运行StateChanged，上文中压入了
                    //一个CloseUIHandler，因此会触发CloseUIHandler的方法内容
				}
				else
				{
                    //摧毁该ui并从已打开UI字典集中剔除
					GameObject.Destroy(_uiObj);
					dicOpenUIs.Remove(_uiType);
				}
			}
		}

        //关闭UI的行为
		private void CloseUIHandler(object _sender, EnumObjectState _newState, EnumObjectState _oldState)
		{
			if (_newState == EnumObjectState.Closing)
			{
                //备忘：as会校验该object是不是BaseUI，不是则返给null
				BaseUI _baseUI = _sender as BaseUI;

                //从已打开UI字典集中去除该UI类型
				dicOpenUIs.Remove(_baseUI.GetUIType());

                //在baseUI的状态改变事件StateChanged中 消除 CloseUIHandler（关闭UI的行为）
				_baseUI.StateChanged -= CloseUIHandler;
			}
		}
		#endregion
    }
}

