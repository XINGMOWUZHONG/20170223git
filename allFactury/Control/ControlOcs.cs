using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WZYB.Model;
using WZYB.BLL;

namespace WZYB.Control
{
    public  class ControlOcs
    {
        
        public bool IsStart = false;
        public int handle = 1;
        public int sleepTime = int.Parse( System.Configuration.ConfigurationManager.AppSettings["OCS_sleeptime"].ToString());
        public int ocsCarCount = int.Parse( System.Configuration.ConfigurationManager.AppSettings["OCS_count"].ToString());

        public ControlOcs()
        {
            IsStart = true;
        }

        public void OcsThreadFunc(object o)
        {
            try
            {
                OCSStatus lastModel = null;
                int ID = Convert.ToInt16(o);
                int[] XmlIndex = getXmlIndex(ID);
                while (true)
                {
                    if (IsStart)
                    {
                        OCSStatus thisModel = OCSStatusBLL.GetModel(ID);
                        if (thisModel != null)
                        {
                            setCarData(lastModel, thisModel, XmlIndex);
                            lastModel = thisModel;
                        }
                    }
                    Thread.Sleep(sleepTime);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int[] getXmlIndex(int index)
        {
            int[] indexArr = new int[4];
            indexArr[0] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_OcsArea_" + index.ToString("000"));
            indexArr[1] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_OcsPath_" + index.ToString("000"));
            indexArr[2] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_OcsPos_" + index.ToString("000"));
            indexArr[3] = GetIdex.getDicOutputIndex("TCP_ATTRIBUTE01_IN_OcsFtv_" + index.ToString("000"));
            return indexArr;
        }

        private void setCarData(OCSStatus lastData, OCSStatus thisData, int[] xmlIndex)
        {
            int CarXmlIndex_OcsArea = xmlIndex[0];
            int CarXmlIndex_OcsPath = xmlIndex[1];
            int CarXmlIndex_OcsPos = xmlIndex[2];
            int CarXmlIndex_OcsFtv = xmlIndex[3];

            if (lastData == null)
            {
                //设定区域  001
                int tmpArea = getOcsArea(thisData.line);
                if (tmpArea != -1)
                {
                    ComTCPLib.SetOutputAsUINT(handle, CarXmlIndex_OcsArea, (UInt32)tmpArea);
                }
                //设定驱动段 002
                ComTCPLib.SetOutputAsUINT(handle, CarXmlIndex_OcsPath, UInt32.Parse(thisData.line.Substring(1)));
                //设定位置 003
                ComTCPLib.SetOutputAsREAL32(handle, CarXmlIndex_OcsPos,  thisData.position );
                //设定是否显示阀体
                ComTCPLib.SetOutputAsUINT(handle, CarXmlIndex_OcsFtv, (UInt32)thisData.displayState);

            }
            else if (!thisData.Equals(lastData))
            {
                if (!thisData.line.Equals (lastData.line))
               {
                   int tmpArea = getOcsArea(thisData.line);
                   if (tmpArea != -1)
                   {
                       ComTCPLib.SetOutputAsUINT(handle, CarXmlIndex_OcsArea, (UInt32)tmpArea);
                   }
                   ComTCPLib.SetOutputAsUINT(handle, CarXmlIndex_OcsPath, UInt32.Parse(thisData.line.Substring(1)));
               }

                if (thisData.position !=lastData.position)
                {
                    ComTCPLib.SetOutputAsREAL32(handle, CarXmlIndex_OcsPos,  thisData.position );
                }

                if (thisData.displayState != lastData.displayState)
                {
                    ComTCPLib.SetOutputAsUINT(handle, CarXmlIndex_OcsFtv, (UInt32)thisData.displayState);
                }

            }

        }

        public int getOcsArea(string line)
        {
            int tmpArea =-1;
            if (line.Substring(0, 1).ToLower() == "a")
            {
                tmpArea = 1;
                if (line.IndexOf("1150") > -1 || line.IndexOf("1070") > -1)
                {
                     tmpArea=11;
                }
            }
            else if (line.Substring(0, 1).ToLower() == "b")
            {
                tmpArea = 2;
                if (line.IndexOf("1130") > -1 || line.IndexOf("1170") > -1 || line.IndexOf("1090") > -1)
                {
                    tmpArea=21;
                }
            }
            else if (line.Substring(0, 1).ToLower() == "c")
            {
                tmpArea = 3;
                if (line.IndexOf("1210") > -1 || line.IndexOf("1080") > -1 || line.IndexOf("2820") > -1 || line.IndexOf("1160") > -1)
                {
                    tmpArea=31;
                }
            }
            return tmpArea ;
        }


    }
}
