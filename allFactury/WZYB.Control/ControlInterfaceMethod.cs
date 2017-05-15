using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZYB.Model;

namespace WZYB.Control
{
    public class ControlInterfaceMethod
    {
        //type 1agv 2ddj  3pcc 4csc 5ocs 6 screen 7liku 8 platform
        public static string getLinkByTypeAndNum(int type,string num)
        {
            string linkStr = "";
            switch (type)
            {
                case 1:
                    linkStr = getAgvClick(num);
                    break;
                case 2:
                    linkStr = getDdjClick(num);
                    break;
                case 3:
                    linkStr = getPccClick(num);
                    break;
                case 4:
                    linkStr = getCscClick(num);
                    break;
                case 5:
                    linkStr = getOcsClick(num);
                    break;
                case 6:
                    linkStr = getMachineScreen(num);
                    break;
                case 7:
                    linkStr = getLikuPalletClick(num);
                    break;
                case 8:
                    linkStr = getPlatformPalletClick(num);
                    break;
                default:
                    break;
            }
            return linkStr;
        }


        //机床三色灯状态
        public static int getMachineLightState(string Num)
        {
            return 1;
        }


        ////////////////////////////////////////
        //机床屏幕点击链接
        private static string getMachineScreen(string Num)
        { 
            return   "http://10.1.50.93:8080/mes/main.shtml";
        }
        //AGV 点击获取任务
        private static string getAgvClick(string Num)
        {
            return "https://www.baidu.com/";
        }

        //DDJ 点击获取任务
        private static string getDdjClick(string Num)
        {
            return "http://10.1.50.93:8080/mes/main.shtml";
        }

        //OCS 点击获取任务
        private static string getOcsClick(string Num)
        {
            return "http://10.1.50.93:8080/mes/main.shtml";
        }

        //PCC 点击获取任务
        private static string getPccClick(string Num)
        {
            return "http://10.1.50.93:8080/mes/main.shtml";
        }

        //CSC 点击获取任务
        private static string getCscClick(string Num)
        {
            return "http://10.1.50.93:8080/mes/main.shtml";
        }

        //立库的PALLET 点击获信息
        private static string getLikuPalletClick(string Num)
        {
            return "http://10.1.50.93:8080/mes/main.shtml";
        }

        //站台的PALLET 点击获信息
        private static string getPlatformPalletClick(string Num)
        {
            return "http://10.1.50.93:8080/mes/main.shtml";
        }

        //搜索托盘
        public static Rack searchRack(string rackNum)
        {
            return null;
        }

        //登录操作
        public static bool login(string name,string pass)
        {
            return true;
        }
        //视频监控
        public static  string getVideo(string name)
        {
            return string.Empty;
        }
    }
}
