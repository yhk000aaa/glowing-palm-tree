//故事文本解析方法集

//故事文本格式说明

//起头段落
//%$pg$1：标识此处之后的第一个建立开头的标识句为段落id1
//%$text$标题文本：文本样式段落头
//%$speak$name$headpic，说话样式

//特殊
//%$card$2：卡片切换至对应id

//结尾段落
//%$check$判断表id$5$8$12$44：直接判断对应判断表中的内容，跳转对应段落

//%$goto$1btn$5：跳转，单按钮，跳转至段落5
//%$goto$4btn：跳转，四按钮-继续读
//%$btn$按钮文本$0$5：按钮1内容，0表示不判断，跳转至段落5
//%$btn$按钮文本$判断表id$5$8：按钮2内容，读取判断表id中的内容，合格则去段落5，不合格则去段落8               
//%$btn$按钮文本$判断表id$5$8$12$44：按钮3内容，读取判断表id中的内容，结果1则去段落5，结果2则去段落8，结果3则去段落12，结果4则去段落44

    
//值变化                
//%event$值id$增减符号$数值：对应值变化





using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace XHFrameWork
{
    public class BaseStoryPage
    {
        public SortedList<int, string> pageText;//解析时用于转存的段落文本
    }

    public class TextPage : BaseStoryPage
    {
        public EnumStoryPageType storyPageType = EnumStoryPageType.TextPage;
        public EnumInboxType inboxType = EnumInboxType.Text;
    }
    public class SpeakPage : BaseStoryPage
    {
        public EnumStoryPageType storyPageType = EnumStoryPageType.SpeakPage;
        public EnumInboxType inboxType = EnumInboxType.Speak;
        public string roleName;
        public string rolePic;
    }
    public class CardPage : BaseStoryPage
    {
        public EnumStoryPageType storyPageType = EnumStoryPageType.CardPage;
        public int cardID;
    }
    public class CheckPage : BaseStoryPage
    {
        public EnumStoryPageType storyPageType = EnumStoryPageType.CheckPage;
        public int checkId;
        public Dictionary<int, int> checkTo;
    }
    public class BtnsPage : BaseStoryPage
    {
        public EnumStoryPageType storyPageType = EnumStoryPageType.BtnsPage;
        public Dictionary<int, string> btnText;
        public Dictionary<int, int> btnCheckID;
        public Dictionary<int, Dictionary<int, int>> checkTo;//每个按钮0123对应一组<int,int>
        public string title;
        public string text;
        public int btnCount;
    }
    public class EventPage : BaseStoryPage
    {
        public EnumStoryPageType storyPageType = EnumStoryPageType.EventPage;
        public string valueType;
        public string changeSymbol;
        public string changevalue;
    }

    public class StoryExplainTools : Singleton<StoryExplainTools>
    {
        //封装层：故事包包含多个段落包，段落包包括文本头info()，文本
        SortedList<int, object> explainedStory;//解析好的故事包（自然段编号，自然段page）
        Dictionary<int, int> pageToPra;//段落对应自然段的id，用于跳转段落时从此获取对应的自然段id
        Dictionary<int, EnumStoryPageType> praToPageType;//自然段的id对应类型
        
        EnumStoryPageType nowPageType;//记录当前page类型
        SortedList<int, string> pageText;//当前文本

        TextPage textPage;
        SpeakPage speakPage;
        CardPage cardPage;
        CheckPage checkPage;
        BtnsPage btnsPage;
        EventPage eventPage;
        

        int pageID;//用于缓存的段落id，只供读到段落标识符时写入
        int praID;//用于缓存自然段的自然段id，每个开始段落都生成1个
        int btnId;//用于计数，看获取的按钮是第几个

        public override void Init()
        {
            nowPageType = EnumStoryPageType.Start;
            pageID = 0;
            praID = 0;
            btnId = 0;
            pageText = new SortedList<int, string>();
            explainedStory = new SortedList<int, object>();
            pageToPra = new Dictionary<int, int>();
            praToPageType = new Dictionary<int, EnumStoryPageType>();
        }

        //剧本解析器，将剧本逐行分析：%开头代表是标识，进行标识句解析和写入（分为剧本头类型和剧本尾类型）；无标识则逐行写入
        //返回解析后的explainedStory故事包和段落与自然段对应表pageToPra
        public void StoryExplainer(SortedList<int, string> _story,out SortedList<int, object> _explainedStory,out Dictionary<int, int> _pageToPra,out Dictionary<int, EnumStoryPageType>_praToPageType)
        {
            //解析前需要重置一次
            Init();

            for (int i = 0; i < _story.Count; i++)
            {
                string lineWord = _story[i];
                if ((lineWord != null) && (lineWord != ""))
                {
                    if (lineWord[0] == '%')
                    {
                        TextCodeExplain(lineWord);
                    }
                    else
                    {
                        pageText.Add(pageText.Count, lineWord);
                    }
                }
                else
                {
                    Debug.LogWarning("empty line:" + i.ToString());
                }
            }
            //最后一个收尾段落需要结束打包
            PageEndMaker();

            //发还
            _explainedStory = explainedStory;
            _pageToPra = pageToPra;
            _praToPageType = praToPageType;
        }

        //标识句解析
        public void TextCodeExplain(string _lineWord)
        {
            //切割标识句
            string[] lineArray = _lineWord.Split('$');
            switch (lineArray[1])
            {
                //段落标识
                //%$pg$1：标识此处之后的第一个建立开头的标识句为段落id1
                case "pg":
                    {
                        pageID = int.Parse(lineArray[2]);
                    }
                    break;

                //%$text$标题文本：文本样式段落头
                case "text":
                    {
                        //建立开头（同时收尾上一个段落）          
                        PageHeadMaker();
                        //类型&内容
                        textPage = new TextPage();
                        textPage.inboxType=EnumInboxType.Text;
                        
                        nowPageType=EnumStoryPageType.TextPage;
                    }
                    break;

                //%$speak$name$headpic，说话样式
                case "speak":
                    {
                        //建立开头（同时收尾上一个段落）          
                        PageHeadMaker();
                        //类型&内容
                        speakPage = new SpeakPage();
                        speakPage.inboxType=EnumInboxType.Speak;
                        speakPage.roleName= lineArray[2];
                        speakPage.rolePic = lineArray[3];

                        nowPageType=EnumStoryPageType.SpeakPage;
                    }
                    break;

                //%$card$2：卡片切换至对应id
                case "card":
                    {
                        //建立开头（同时收尾上一个段落）          
                        PageHeadMaker();
                        //类型&内容
                        cardPage = new CardPage();
                        cardPage.cardID=int.Parse(lineArray[2]);       
                        nowPageType = EnumStoryPageType.CardPage;
                    }
                    break;

                //%$check$判断表id$5$8$12$44：直接判断对应判断表中的内容，跳转对应段落
                case "check":
                    {
                        //建立开头（同时收尾上一个段落）          
                        PageHeadMaker();
                        //类型&内容
                        checkPage = new CheckPage();
                        checkPage.checkId = int.Parse(lineArray[2]);
                        checkPage.checkTo = new Dictionary<int, int>();
                        for (int i = 3; i < lineArray.Length; i++)
                        {
                            checkPage.checkTo.Add(i - 2, int.Parse(lineArray[i]));
                        }

                        nowPageType = EnumStoryPageType.CheckPage;
                    }
                    break;

                //%$goto$1btn$标题$文本$5：跳转，单按钮，跳转至段落5
                //%$goto$4btn$标题$文本：跳转，四按钮-继续读
                case "goto":
                    {
                        //建立开头（同时收尾上一个段落）          
                        PageHeadMaker();

                        btnsPage = new BtnsPage();
                        nowPageType = EnumStoryPageType.BtnsPage;
                        btnsPage.title = lineArray[3];
                        btnsPage.text = lineArray[4];
                        btnsPage.btnText = new Dictionary<int, string>();
                        btnsPage.btnCheckID = new Dictionary<int, int>();
                        btnsPage.checkTo = new Dictionary<int,Dictionary<int,int>>();
                        //判断按钮数
                        switch (lineArray[2])
                        {
                            case "1btn":
                                {
                                    btnsPage.btnCount = 1;
                                    btnsPage.btnText.Add(0, TextLib.Instance.GetString(15));
                                    btnsPage.btnCheckID.Add(0,0);
                                    Dictionary<int, int> thisto = new Dictionary<int, int>();
                                    thisto.Add(1,int.Parse(lineArray[5]));
                                    btnsPage.checkTo.Add(0, thisto);
                                }
                                break;
                            case "2btn":
                                {
                                    btnsPage.btnCount = 2;
                                }
                                break;
                            case "3btn":
                                {
                                    btnsPage.btnCount = 3;
                                }
                                break;
                            case "4btn":
                                {
                                    btnsPage.btnCount = 4;
                                }
                                break;
                            default:
                                Debug.Log("Not Find btnType ! word: " + _lineWord);
                                break;
                        }
                        btnId = 0;
                    }
                    break;

                //%$btn$按钮文本$0$5：按钮1内容，0表示不判断，跳转至段落5
                //%$btn$按钮文本$判断表id$5$8：按钮2内容，读取判断表id中的内容，合格则去段落5，不合格则去段落8               
                //%$btn$按钮文本$判断表id$5$8$12$44：按钮3内容，读取判断表id中的内容，结果1则去段落5，结果2则去段落8，结果3则去段落12，结果4则去段落44
                case "btn":
                    {
                        //按钮信息
                        btnsPage.btnText.Add(btnId, lineArray[2]);
                        btnsPage.btnCheckID.Add(btnId,int.Parse(lineArray[3]));
                        
                        Dictionary<int, int> thisto = new Dictionary<int, int>();
                        for (int i = 4; i < lineArray.Length-1; i++)
                        {
                            thisto.Add(i - 3, int.Parse(lineArray[i]));
                        }
                        btnsPage.checkTo.Add(btnId, thisto);

                        btnId++;
                    }
                    break;

                //%$event$值id$增减符号$数值：对应值变化
                case "event":
                    {
                        //建立开头（同时收尾上一个段落）          
                        PageHeadMaker();
                        
                        //类型&内容
                        eventPage = new EventPage();

                        eventPage. valueType = lineArray[2];
                        eventPage. changeSymbol = lineArray[3];
                        eventPage. changevalue = lineArray[4];
                        
                        nowPageType=EnumStoryPageType.EventPage;
                    }
                    break;
                default:
                    Debug.Log("Not Find $Type ! word: " + _lineWord);
                    break;
            }
        }


        //开启新段落
        private void PageHeadMaker()
        {
            //先封装上一段落的内容
            PageEndMaker();

            //生成新的自然段id
            praID++;
            //段落id不为空时，将段落id和自然段id的对应关系记录下
            if (pageID != 0)
            {
                pageToPra.Add(pageID, praID);
                pageID = 0;
            }
        }

        //段落结尾，封装内容
        private void PageEndMaker()
        {
            //封装文本内容,封装段落包进故事包
            switch (nowPageType)
            {
                case EnumStoryPageType.Start:
                    { }
                    break;
                case EnumStoryPageType.TextPage:
                    {
                        textPage.pageText = pageText;
                        explainedStory.Add(praID, textPage);
                    }
                    break;
                case EnumStoryPageType.SpeakPage:
                    {
                        speakPage.pageText = pageText;
                        explainedStory.Add(praID, speakPage);
                    }
                    break;
                case EnumStoryPageType.CardPage:
                    {
                        cardPage.pageText = pageText;
                        explainedStory.Add(praID, cardPage);
                    }
                    break;
                case EnumStoryPageType.CheckPage:
                    {
                        checkPage.pageText = pageText;
                        explainedStory.Add(praID, checkPage);
                    }
                    break;
                case EnumStoryPageType.BtnsPage:
                    {
                        btnsPage.pageText = pageText;
                        explainedStory.Add(praID, btnsPage);
                    }
                    break;
                case EnumStoryPageType.EventPage:
                    {
                        eventPage.pageText = pageText;
                        explainedStory.Add(praID, eventPage);
                    }
                    break;
                default:
                    Debug.Log("findn't NowPageType : " + nowPageType);
                    break;
            }
            praToPageType.Add(praID, nowPageType);

            //重置page和pageText
            nowPageType=EnumStoryPageType.Unkown;
            pageText=new SortedList<int,string>();
        }
    }
}