using UnityEngine;
using UnityEngine.EventSystems;

public class UIHint : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Font font;//字体类型
    public int fontSize = 10;//字体大小
    public FontStyle fontStyle = FontStyle.Normal;//字体样式(粗体斜体)
    public Color color = new Color();//字体颜色
    public TextAnchor anchor = TextAnchor.UpperLeft;//文本锚点，默认往左上靠
    public bool autoRefresh = true;//内容更新时是否自动调用Refresh函数（在Inspector中动态修改时开上，在确定不再修改时就关上
    [Multiline]//让inspector可以输入多行文本
    public string text = "显示的文本";

    private bool showText = false;
    public GUIStyle style;//这个参数没啥作用，最好就把public设置为private

    public void Start()
    {
        style = new GUIStyle("box");//样式风格
        style.richText = true;//富文本设置
        Refresh();
    }
    public void Refresh()
    {//重新加载字体信息。当参数发生变化时要调用该函数让参数修改生效
        //还好C#这里是引用的赋值，这赋值再多也不会对系统造成多大负担，但为了文雅还是把这赋值操作单独抓出来
        style.font = font;
        style.fontSize = fontSize;
        style.fontStyle = fontStyle;
        style.alignment = anchor;
        style.normal.textColor = color;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        showText = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        showText = false;
    }
    public void OnGUI()
    {
        if (showText)
        {
            var vt = style.CalcSize(new GUIContent(text));
            if (autoRefresh)
                Refresh();//虽然可以让OnGUI每次都调用Refresh函数，但看到这种高频率调用的函数里放着没啥用的语句时总是会感到烦躁，所以设置了个autoRefresh参数，如果觉得多此一举的可以把这个参数删除
            GUI.Box(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, vt.x, vt.y), text, style);
        }
    }
}


