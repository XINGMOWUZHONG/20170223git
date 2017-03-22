using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WZYB.Control
{
    public class GetIdex
    {
        public static int getXMLInputIndex(string name)
        {
            try
            {
                string filepath = Environment.CurrentDirectory + "/CodeGen.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(filepath);

                XmlElement rootElem = doc.DocumentElement;   //获取根节点  
                XmlNode xn = rootElem.SelectSingleNode("Interface/Inputs");
                int i = 0;
                foreach (XmlNode xx in xn.ChildNodes)
                {
                    if (xx.Attributes["Name"].Value.ToString() == name)
                    {
                        return i;
                    }
                    i++;
                }
                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }


        public static int getXMLOutIndex(string name)
        {
            try
            {
                string filepath = Environment.CurrentDirectory + "/CodeGen.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(filepath);

                XmlElement rootElem = doc.DocumentElement;
                XmlNode xn = rootElem.SelectSingleNode("Interface/Outputs");
                int i = 0;
                foreach (XmlNode xx in xn.ChildNodes)
                {
                    if (xx.Attributes["Name"].Value.ToString() == name)
                    {
                        return i;
                    }
                    i++;
                }
                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// 读取数据缓存
        /// </summary>
        public static object GetCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = System.Web.HttpRuntime.Cache;
            return objCache[CacheKey];
        }

        /// <summary>
        /// 设置数据缓存
        /// </summary>
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = System.Web.HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }

        public static void GetSetcache()
        {
            if (GetCache("Input") != null && GetCache("Output") != null)
            {
                return;
            }
            string filepath = Environment.CurrentDirectory + "/CodeGen.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            XmlElement rootElem = doc.DocumentElement;
            //Input 
            XmlNode xn = rootElem.SelectSingleNode("Interface/Inputs");
            Dictionary<String, int> InputDict = new Dictionary<string, int>();
            int i = 0;
            foreach (XmlNode xx in xn.ChildNodes)
            {
                InputDict.Add(xx.Attributes["Name"].Value.ToString(), i);
                i++;
            }
            SetCache("Input", InputDict);
            //Output 
            XmlNode xn2 = rootElem.SelectSingleNode("Interface/Outputs");
            Dictionary<String, int> OutputDict = new Dictionary<string, int>();
            int i2 = 0;
            foreach (XmlNode xx in xn2.ChildNodes)
            {
                OutputDict.Add(xx.Attributes["Name"].Value.ToString(), i2);
                i2++;
            }
            SetCache("Output", OutputDict);

        }

        public static int getDicInputIndex(string name)
        {
            try
            {
                GetSetcache();
                Dictionary<String, int> InputDict = (Dictionary<String, int>)GetCache("Input");
                return InputDict[name];
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public static int getDicOutputIndex(string name)
        {
            try
            {
                GetSetcache();
                Dictionary<String, int> OutputDict = (Dictionary<String, int>)GetCache("Output");
                return OutputDict[name];
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static float getOCSPathLength(string name)
        {
            try
            {
                Dictionary<String, float> pl = (Dictionary<String, float>)GetCache("OCSPathLength");
                return pl[name];
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static void SetOCSPathLengthSetCache(string[,] values)
        {
            Dictionary<String, float> pl = new Dictionary<String, float>();

            for (int i = 0; i < values.GetLength(0); i++)
            {
                pl.Add(values[i, 0], float.Parse(values[i, 1]));
            }

            SetCache("OCSPathLength", pl);
        }


        //type 1 uint,2 float,3 flag
        //设置数据
        public void updateValue(string name, string value, int type, int handle)
        {
            double time, timeStep;
            ComTCPLib.UpdateData(handle, out time, out timeStep);
            int index = getDicOutputIndex(name);
            if (type == 1)
            {
                ComTCPLib.SetOutputAsUINT(handle, index, uint.Parse(value));
            }
            else if (type == 2)
            {
                ComTCPLib.SetOutputAsREAL32(handle, index, float.Parse(value));
            }
            else if (type == 3)
            {
                ComTCPLib.SetOutputAsBOOL(handle, index, bool.Parse(value));
            }
        }

        public object readValue(string name, int type, int handle)
        {
            double time, timeStep;
            ComTCPLib.UpdateData(handle, out time, out timeStep);
            int index = getDicInputIndex(name);
            if (type == 1)
            {
                int result;
                ComTCPLib.GetInputAsINT(handle, index, out result);
                return result;
            }
            else if (type == 2)
            {
                float result;
                ComTCPLib.GetInputAsREAL32(handle, index, out result);
                return result;
            }
            else if (type == 3)
            {
                bool result;
                ComTCPLib.GetInputAsBOOL(handle, index, out result);
                return result;
            }
            return null;
        }
    }
}
