//EventTriggerListener事件绑定侦听器，主要进行UGUI事件的绑定

//TouchHandle类为点击控制类，主管单类点击行为的对应事件集的被写入和运行，所有单个点击行为都对应一个该类
//EventTriggerListener类是事件绑定侦听类，负责 游戏物体 与 对应点击事件的绑定，也负责调用对应点击行为的TouchHandle类将事件写入和运行。
//--这个类继承自MonoBehaviour和所有原有点击事件类，并对14种点击行为以TouchHandle类的方式重写。它实现了：
//----1.给对应游戏物体加挂事件侦听脚本：EventTriggerListener.Get加挂和读取本脚本；
//----2.各类点击事件的运行：各类点击方法的实现，如果对应实例化的TouchHandle点击控制类（如onDrag等）不为空，则运行其中的事件集
//----3.点击事件的写入：SetEventHandle方法，将需要的 点击事件集 写到对应的 TouchHandle点击控制类 中

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace XHFrameWork
{
    //点击控制类
    public class TouchHandle
	{
        //点击事件集，可容纳多条点击事件，暂为空
		private event OnTouchEventHandle eventHandle = null;

        //点击事件的参数体集合
		private object[] handleParams;

        //点击处理（重载1 by 需进行的点击事件集 & 可变数量的参数集合）
		public TouchHandle(OnTouchEventHandle _handle, params object[] _params)
		{
            //将这两个参数设置到本类的 点击事件集 和 点击事件的参数体集合 中
			SetHandle(_handle, _params);
		}

        //点击处理（重载2 by 空） 继承对象可用于重写
		public TouchHandle()
		{
			
		}

        //将这两个参数设置到本类的 点击事件集 和 点击事件的参数体集合 中
		public void SetHandle(OnTouchEventHandle _handle, params object[] _params)
		{
            //如果事件操作体有事件，则清空之
			DestoryHandle();
            //压入事件本次点击事件
			eventHandle += _handle;
            //拷入点击事件的参数体集合
            handleParams = _params;
		}

        //对传入对象进行点击事件集中的事件 by 侦听对象 & 参数
		public void CallEventHandle(GameObject _lsitener, object _args)
		{
            //点击事件集不为空时就对 传入数据 运行事件集中的事件
			if (null != eventHandle)
			{
				eventHandle(_lsitener, _args, handleParams);
			}
		}

		//如果事件操作体有事件，则清空之
		public void DestoryHandle()
		{
			if (null != eventHandle)
			{
				eventHandle -= eventHandle;
				eventHandle = null;
			}
		}
    }


    //事件的各项详细操作体，包括所有类型的点击控制类
	public class EventTriggerListener : MonoBehaviour,
	IPointerClickHandler,
	IPointerDownHandler,  
	IPointerUpHandler, 
	IPointerEnterHandler,  
	IPointerExitHandler,  
	 
	ISelectHandler,  
	IUpdateSelectedHandler,  
	IDeselectHandler, 

	IDragHandler,  
	IEndDragHandler,  
	IDropHandler,  
	IScrollHandler,  
	IMoveHandler  
	{
        //对应点击事件创建对应的点击控制类
		public TouchHandle onClick;  
		public TouchHandle onDoubleClick; 
		public TouchHandle onDown;  
		public TouchHandle onEnter;  
		public TouchHandle onExit;  
		public TouchHandle onUp;  
		public TouchHandle onSelect;  
		public TouchHandle onUpdateSelect;  
		public TouchHandle onDeSelect;  
		public TouchHandle onDrag;  
		public TouchHandle onDragEnd;  
		public TouchHandle onDrop;  
		public TouchHandle onScroll;  
		public TouchHandle onMove;  

		//获取目标上的事件开关侦听器脚本，如果没有就新加一个 by 游戏对象
		static public EventTriggerListener Get(GameObject go)  
		{  
			return go.GetOrAddComponent<EventTriggerListener>();
		} 

        //摧毁操作伴随的行为
		void OnDestory()
		{
			this.RemoveAllHandle ();
		}
        //移除本类中的所有点击控制类
		private void RemoveAllHandle()
		{
			this.RemoveHandle (onClick);
			this.RemoveHandle (onDoubleClick);
			this.RemoveHandle (onDown);
			this.RemoveHandle (onEnter);
			this.RemoveHandle (onExit);
			this.RemoveHandle (onUp);
			this.RemoveHandle (onDrop);
			this.RemoveHandle (onDrag);
			this.RemoveHandle (onDragEnd);
			this.RemoveHandle (onScroll);
			this.RemoveHandle (onMove);
			this.RemoveHandle (onUpdateSelect);
			this.RemoveHandle (onSelect);
			this.RemoveHandle (onDeSelect);
		}
        //移除本类中的对应点击控制类 by 点击控制类
		private void RemoveHandle(TouchHandle _handle)
		{
            //点击控制类不为空时，改为空
			if (null != _handle)
			{
                //清空点击控制类中的事件
				_handle.DestoryHandle();
				_handle = null;
			}
		}

        //各类点击方法的实现，如果对应实例化的TouchHandle点击控制类（如onDrag等）不为空，则运行其中的事件集
        #region IDragHandler implementation
		public void OnDrag (PointerEventData eventData)
		{
			if (onDrag != null) 
				onDrag.CallEventHandle(this.gameObject, eventData);
		}
		#endregion
		
		#region IEndDragHandler implementation
		
		public void OnEndDrag (PointerEventData eventData)
		{
			if (onDragEnd != null) 
				onDragEnd.CallEventHandle(this.gameObject, eventData);
		}
		
		#endregion
		
		#region IDropHandler implementation
		public void OnDrop (PointerEventData eventData)
		{
			if (onDrop != null) 
				onDrop.CallEventHandle(this.gameObject, eventData);
		}
		#endregion
		
		#region IPointerClickHandler implementation
		public void OnPointerClick (PointerEventData eventData)
		{
			if (onClick != null) 
				onClick.CallEventHandle(this.gameObject, eventData);
		}
		#endregion
		
		#region IPointerDownHandler implementation
		public void OnPointerDown (PointerEventData eventData)
		{
			if (onDown != null) 
				onDown.CallEventHandle(this.gameObject, eventData);
		}
		#endregion
		
		#region IPointerUpHandler implementation
		public void OnPointerUp (PointerEventData eventData)
		{
			if (onUp != null) 
				onUp.CallEventHandle(this.gameObject, eventData);
		}
		#endregion
		
		#region IPointerEnterHandler implementation
		public void OnPointerEnter (PointerEventData eventData)
		{
			if (onEnter != null) 
				onEnter.CallEventHandle(this.gameObject, eventData);
		}
		#endregion
		
		#region IPointerExitHandler implementation
		public void OnPointerExit (PointerEventData eventData)
		{
			if (onExit != null) 
				onExit.CallEventHandle(this.gameObject, eventData);
		}
		#endregion
		
		#region ISelectHandler implementation
		public void OnSelect (BaseEventData eventData)
		{
			if (onSelect != null) 
				onSelect.CallEventHandle(this.gameObject, eventData);
		}
		#endregion
		
		#region IUpdateSelectedHandler implementation
		public void OnUpdateSelected (BaseEventData eventData)
		{
			if (onUpdateSelect != null) 
				onUpdateSelect.CallEventHandle(this.gameObject, eventData);
		}
		#endregion

		#region IDeselectHandler implementation

		public void OnDeselect (BaseEventData eventData)
		{
			if (onDeSelect != null) 
				onDeSelect.CallEventHandle(this.gameObject, eventData);
		}

		#endregion

		#region IScrollHandler implementation

		public void OnScroll (PointerEventData eventData)
		{
			if (onScroll != null) 
				onScroll.CallEventHandle(this.gameObject, eventData);
		}

		#endregion

		#region IMoveHandler implementation

		public void OnMove (AxisEventData eventData)
		{
			if (onMove != null) 
				onMove.CallEventHandle(this.gameObject, eventData);
		}

		#endregion

        //绑定传入的 点击事件集 到对应的 TouchHandle点击控制类 中  by 点击事件类型 & 点击事件集 & 可变参数集
		public void SetEventHandle(EnumTouchEventType _type, OnTouchEventHandle _handle, params object[] _params)
		{
			switch(_type)
			{
			case EnumTouchEventType.OnClick:
				if (null == onClick) {
					onClick = new TouchHandle();
				}
				onClick.SetHandle(_handle, _params);
				break;
			case EnumTouchEventType.OnDoubleClick:
				if (null == onDoubleClick) {
					onDoubleClick = new TouchHandle();
				}
				onDoubleClick.SetHandle(_handle, _params);
				break;
			case EnumTouchEventType.OnDown:
				if (onDown == null) {
					onDown = new TouchHandle();
				}
				onDown.SetHandle (_handle, _params);
				break;
			case EnumTouchEventType.OnUp:
				if (onUp == null) {
					onUp = new TouchHandle();
				}
				onUp.SetHandle (_handle, _params);
				break;
			case EnumTouchEventType.OnEnter:
				if (onEnter == null) {
					onEnter = new TouchHandle();
				}
				onEnter.SetHandle (_handle, _params);
				break;
			case EnumTouchEventType.OnExit:
				if (onExit == null) {
					onExit = new TouchHandle();
				}
				onExit.SetHandle (_handle, _params);
				break;
			case EnumTouchEventType.OnDrag:
				if (onDrag == null) {
					onDrag = new TouchHandle();
				}
				onDrag.SetHandle (_handle, _params);
				break;
			case EnumTouchEventType.OnDrop:
				if (onDrop == null) {
					onDrop = new TouchHandle();
				}
				onDrop.SetHandle (_handle, _params);
				break;

			case EnumTouchEventType.OnDragEnd:
				if (onDragEnd == null)
				{
					onDragEnd = new TouchHandle();
				}
				onDragEnd.SetHandle(_handle, _params);
				break;
			case EnumTouchEventType.OnSelect:
				if (onSelect == null)
				{
					onSelect = new TouchHandle();
				}
				onSelect.SetHandle(_handle, _params);
				break;
			case EnumTouchEventType.OnUpdateSelect:
				if (onUpdateSelect == null)
				{
					onUpdateSelect = new TouchHandle();
				}
				onUpdateSelect.SetHandle(_handle, _params);
				break;
			case EnumTouchEventType.OnDeSelect:
				if (onDeSelect == null)
				{
					onDeSelect = new TouchHandle();
				}
				onDeSelect.SetHandle(_handle, _params);
				break;
			case EnumTouchEventType.OnScroll:
				if (onScroll == null)
				{
					onScroll = new TouchHandle();
				}
				onScroll.SetHandle(_handle, _params);
				break;
			case EnumTouchEventType.OnMove:
				if (onMove == null)
				{
					onMove = new TouchHandle();
				}
				onMove.SetHandle(_handle, _params);
				break;
			}
		} 
	}
}
