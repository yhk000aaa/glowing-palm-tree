using UnityEngine;
using UnityEngine.EventSystems;

public class UIHint : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Font font;//��������
    public int fontSize = 10;//�����С
    public FontStyle fontStyle = FontStyle.Normal;//������ʽ(����б��)
    public Color color = new Color();//������ɫ
    public TextAnchor anchor = TextAnchor.UpperLeft;//�ı�ê�㣬Ĭ�������Ͽ�
    public bool autoRefresh = true;//���ݸ���ʱ�Ƿ��Զ�����Refresh��������Inspector�ж�̬�޸�ʱ���ϣ���ȷ�������޸�ʱ�͹���
    [Multiline]//��inspector������������ı�
    public string text = "��ʾ���ı�";

    private bool showText = false;
    public GUIStyle style;//�������ûɶ���ã���þͰ�public����Ϊprivate

    public void Start()
    {
        style = new GUIStyle("box");//��ʽ���
        style.richText = true;//���ı�����
        Refresh();
    }
    public void Refresh()
    {//���¼���������Ϣ�������������仯ʱҪ���øú����ò����޸���Ч
        //����C#���������õĸ�ֵ���⸳ֵ�ٶ�Ҳ�����ϵͳ��ɶ�󸺵�����Ϊ�����Ż��ǰ��⸳ֵ��������ץ����
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
                Refresh();//��Ȼ������OnGUIÿ�ζ�����Refresh���������������ָ�Ƶ�ʵ��õĺ��������ûɶ�õ����ʱ���ǻ�е����꣬���������˸�autoRefresh������������ö��һ�ٵĿ��԰��������ɾ��
            GUI.Box(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, vt.x, vt.y), text, style);
        }
    }
}


