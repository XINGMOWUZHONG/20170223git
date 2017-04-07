using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WZYB.Model;
using WZYB.BLL;
using WZYB.Control;
using Storage;

namespace PccNew
{
    public class ControlStorageThread 
    {
        #region
        //
        //storage 货位的初始化和点击
        //
        public General Storage_PCC = null;
        public General Storage_NEW = null;
        public General Storage_NEW2 = null;

        //配餐车 货位的点击 触发事件
        private static void PCC_placeSelected(StorageArea.Model.Place selectedPlace)
        {
            var placeData = selectedPlace.GetData();
        }
        private static void NEW_placeSelected(StorageArea.Model.Place selectedPlace)
        {
            var placeData = selectedPlace.GetData();
        }

        private static void NEW2_placeSelected(StorageArea.Model.Place selectedPlace)
        {
            var placeData = selectedPlace.GetData();
        }

        //初始化 货位
        public void InitializStorage()
        {
            //初始化 配餐 托盘
            Storage_PCC = new General();
            Storage_PCC.Initialize("StorageArea_pcc");
            Storage_PCC.connection.PlaceSelected += PCC_placeSelected;
            //Storage_PCC.FullAll();

            //初始化 新库 托盘
            Storage_NEW = new General();
            Storage_NEW.Initialize("StorageArea_new");
            Storage_NEW.connection.PlaceSelected += NEW_placeSelected;
            //Storage_NEW.FullAll();

            Storage_NEW2 = new General();
            Storage_NEW2.Initialize("StorageArea_new_double");
            Storage_NEW2.connection.PlaceSelected += NEW2_placeSelected;
            //Storage_NEW2.FullAll();
        }

        //第一次默认加载数据库的货位信息
        private Thread ThreadStorageShowPallet;

        public void InitializStorageShowPallet()
        {
            List<General> lg = new List<General>();
            if (Storage_PCC != null)
            {
                lg.Add(Storage_PCC);
            }
            if (Storage_NEW != null)
            {
                lg.Add(Storage_NEW);
            }
            if (Storage_NEW2 != null)
            {
                lg.Add(Storage_NEW2);
            }
            ThreadStorageShowPallet = new Thread(new ParameterizedThreadStart(Storagecontrol.InitializeStoragePallet));
            ThreadStorageShowPallet.Start(lg);

        }
        #endregion

        //货位线程操作
        ControlStorage Storagecontrol = new ControlStorage();

        #region
        private Thread ThreaStoragePcc;
        private Thread ThreaStorageNew;
        private Thread ThreaStorageNewDouble;
        public void StartThreadStorage()
        {
            
            ThreaStoragePcc = new Thread(new ParameterizedThreadStart(Storagecontrol.StorageThreadFunc));
            ThreaStorageNew = new Thread(new ParameterizedThreadStart(Storagecontrol.StorageThreadFunc));
            ThreaStorageNewDouble = new Thread(new ParameterizedThreadStart(Storagecontrol.StorageThreadFunc));
            
            ThreaStoragePcc.Start(Storage_PCC);
            ThreaStorageNew.Start(Storage_NEW);
            ThreaStorageNewDouble.Start(Storage_NEW2);
        }
        public void StopThreadStorage()
        {
            if (ThreaStoragePcc != null)
            ThreaStoragePcc.Abort();
            if (ThreaStorageNew != null)
            ThreaStorageNew.Abort();
            if (ThreaStorageNewDouble != null)
            ThreaStorageNewDouble.Abort();
        }
        public void PauseThreadStorage()
        {
            Storagecontrol.IsStart = false;
        }

        public void ContinueThreadStorage()
        {
            Storagecontrol.IsStart = true;
        }

        #endregion
    }
}
