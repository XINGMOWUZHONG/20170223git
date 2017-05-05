using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WZYB.Control;

namespace PccNew
{

    public  class ControlThread
    {
        //PCC
        private Thread ThreadPcc;
        private ControlPeiCan PccControl = new ControlPeiCan();
        private void StartThreadPcc()
        {
            //if (ThreadPcc == null)
            ThreadPcc = new Thread(new ParameterizedThreadStart(PccControl.PCCThreadFunc));
            ThreadPcc.Start();
        }
        //DDJ
        private ControlLk LKcontrol = new ControlLk();
        private Thread[] ThreadNewLikuDDJList;
        private void StartThreadNewLikuDDJ()
        {
            //if (ThreadNewLikuDDJList == null)
            ThreadNewLikuDDJList = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                ThreadNewLikuDDJList[i] = new Thread(new ParameterizedThreadStart(LKcontrol.DDJThreadFunc));
                ThreadNewLikuDDJList[i].Start(i + 1);
            }
        }
        //CSC
        private Thread[] ThreadNewLikuCscList;
        private void StartThreadNewLikuCsc()
        {
            //if (ThreadNewLikuCscList == null)
            ThreadNewLikuCscList = new Thread[2];
            for (int i = 0; i < 2; i++)
            {
                ThreadNewLikuCscList[i] = new Thread(new ParameterizedThreadStart(LKcontrol.CarThreadFunc));
                ThreadNewLikuCscList[i].Start(i + 1);
            }
        }
        //OCS
        private ControlOcs OcsControl = new ControlOcs();
        private Thread[] ocsThread;
        private void StartThreadOcs()
        {
            //if (ocsThread == null)
            ocsThread = new Thread[OcsControl.ocsCarCount];
            for (int i = 0; i < OcsControl.ocsCarCount; i++)
            {
                ocsThread[i] = new Thread(new ParameterizedThreadStart(OcsControl.OcsThreadFunc));
                ocsThread[i].Start(i + 1);
                //Thread.Sleep(500);
            }
        }

        //OCS LIFT
        private Thread ThreadOcsLift;
        private ControlOcsLift OcsLiftcontrol = new ControlOcsLift();
        private void StartThreadOcsLift()
        {
           // if (ThreadOcsLift == null)
            ThreadOcsLift = new Thread(new ParameterizedThreadStart(OcsLiftcontrol.OcsLiftThreadFunc));
            ThreadOcsLift.Start();
        }


        //AGV
        private ControlAgv agvControl = new ControlAgv();
        private Thread[] agvThread;
        private void StartThreadAGV()
        {
            //if (agvThread == null)
            agvThread = new Thread[agvControl.AgvCount];
            for (int i = 0; i < agvControl.AgvCount; i++)
            {
                agvThread[i] = new Thread(new ParameterizedThreadStart(agvControl.AGVThreadFunc));
                agvThread[i].Start(i + 1);
            }
        }
        //PALLET
        private Thread ThreadNewLikuPallert;
        private void StartThreadNewLikuPallert()
        {
            //if (ThreadNewLikuPallert == null)
            ThreadNewLikuPallert = new Thread(new ParameterizedThreadStart(LKcontrol.PallertThreadFunc));
            ThreadNewLikuPallert.Start();
        }


        //update data industrial
        private ControlUpdateData DataControl = new ControlUpdateData();
        private Thread ThreadUpdateData;
        private void StartThreadUpdateData()
        {
            ThreadUpdateData = new Thread(new ParameterizedThreadStart(DataControl.DataThreadFunc));
            ThreadUpdateData.Start();
        }
       
        public void threadStartAll()
        {
            StartThreadUpdateData();

            StartThreadPcc();
            StartThreadNewLikuDDJ();
            StartThreadNewLikuCsc();
            StartThreadOcs();
            StartThreadOcsLift();
            StartThreadNewLikuPallert();
            StartThreadAGV();
        }

        public void threadStopAll()
        {
            if (ThreadPcc!=null)
            ThreadPcc.Abort();
            if (ThreadNewLikuDDJList != null)
            for (int i = 0; i < ThreadNewLikuDDJList.Length; i++)
            {
                ThreadNewLikuDDJList[i].Abort();
            }
            if (ThreadNewLikuCscList != null)
            for (int i = 0; i < ThreadNewLikuCscList.Length; i++)
            {
                ThreadNewLikuCscList[i].Abort();
            }
            if (ocsThread != null)
            for (int i = 0; i < ocsThread.Length; i++)
            {
                ocsThread[i].Abort();
            }
            if (agvThread != null)
            for (int i = 0; i < agvThread.Length; i++)
            {
                agvThread[i].Abort();
            }
            if (ThreadOcsLift != null)
            ThreadOcsLift.Abort();
            if (ThreadNewLikuPallert != null)
            ThreadNewLikuPallert.Abort();

            if (ThreadUpdateData != null)
                ThreadUpdateData.Abort();
        }

        public void threadPauseAll()
        {
            PccControl.IsStart = false;
            LKcontrol.IsStart = false;
            OcsControl.IsStart = false;
            OcsLiftcontrol.IsStart = false;
            agvControl.IsStart = false;
            DataControl.IsStart = false;
        }

        public void threadContinueAll()
        {
            PccControl.IsStart = true;
            LKcontrol.IsStart = true;
            OcsControl.IsStart = true;
            OcsLiftcontrol.IsStart = true;
            agvControl.IsStart = true;
            DataControl.IsStart = true;
        }
    }
}
