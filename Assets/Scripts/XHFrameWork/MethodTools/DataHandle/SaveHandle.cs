//存档管理器（Save1为自动存档，BookSave为永久继承内容存档，config为设置存档）

//读档时直接使用方法，返回存档的键值对
//存档时需要先将待存档内容存到playerSavingdata中，然后再存档

using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace XHFrameWork
{
    public class SaveHandle : Singleton<SaveHandle>
    {
        #region 初始化Init&检查存档check
        public override void Init()
        {
        }

        //基础方法：检查存档文件夹是否存在，不存在则新建
        public void checkSaveFolder()
        {
            string path = CsvPath.GetSaveFolderPath();

            //判断文件夹是否存在，不存在则新建
            if (Directory.Exists(path) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(path);
            }
            //Directory.Delete(Server.MapPath("~/upimg/hufu"), true);//删除文件夹以及文件夹中的子目录，文件    
        }

        //基础方法：检查存档文件是否存在，不存在则新建
        public void checkSaver(SaveID saveid)
        {
            checkSaveFolder();
            string path = CsvPath.GetSavePath(saveid);

            //判断文件的存在，不存在则新建
            if (!File.Exists(path))
            {
                //创建该文件
                File.Create(path).Dispose();
                //Debug.Log("新建空存档文件:"+saveid.ToString());
                saveSaver(saveid);//存储默认的初始mainData数据进存档文件
            }
        }

        public void checkAllSaver()
        {
            checkSaver(SaveID.AutoSave);
            checkSaver(SaveID.Save1);
            checkSaver(SaveID.Save2);
            checkSaver(SaveID.Save3);
            checkSaver(SaveID.BookSave);
            checkSaver(SaveID.Config);
        }

        #endregion

        #region 读档
        //读档-设置部分
        public ConfigData loadSaver_configData()
        {
            checkSaver(SaveID.Config);//检查存档文件夹和文件是否存在
            ConfigData playerSavingdata;
            string path = CsvPath.GetSavePath(SaveID.Config);

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                //Json读档方法
                string str = sr.ReadToEnd();
                playerSavingdata = JsonConvert.DeserializeObject<ConfigData>(str);
            }
            return playerSavingdata;
        }

        #endregion

        #region 存档
        //存档(重载：存默认主数据)
        public void saveSaver(SaveID saveid)
        {
            if (saveid == SaveID.Config)
            {
                saveSaver(saveid, MainData.Instance.configData);
            }
        }

        //存档(根方法)
        void saveSaver(SaveID saveid, object playerSavingdata)
        {
            checkSaver(saveid);//检查存档文件夹和文件是否存在
            string path = CsvPath.GetSavePath(saveid);
            //Debug.Log(saveid.ToString() + "存档");
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                //json方法写入
                string str = JsonConvert.SerializeObject(playerSavingdata);
                sw.Write(str);

                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                sw.Dispose();
            }
        }
        #endregion
    }
}