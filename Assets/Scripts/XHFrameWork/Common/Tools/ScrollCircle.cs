//摇杆类,决定摇杆如何移动。
//实际进行移动结算时，由移动控制的部分直接读取摇杆图片的RectTransform值作为偏移值即可换算

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace XHFrameWork
{
	public class ScrollCircle :ScrollRect 
	{
		protected float mRadius=0f;
			
		protected override void Start()
		{
			content = transform.Find ("Image") as RectTransform;

			base.Start();

			//计算摇杆块的半径
			mRadius = (transform as RectTransform).sizeDelta.x * 0.5f;
		}

		public override void OnDrag (UnityEngine.EventSystems.PointerEventData eventData)
		{
			base.OnDrag (eventData);
			var contentPostion = this.content.anchoredPosition;
			if (contentPostion.magnitude > mRadius) 
			{
				contentPostion = contentPostion.normalized * mRadius;
				SetContentAnchoredPosition (contentPostion);
			}
		}

        //松开秒回正（此方法不重写也可以用，松开缓慢回正）
        public override void OnEndDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            base.OnEndDrag(eventData);
            SetContentAnchoredPosition(Vector2.zero);
        }
	}
}