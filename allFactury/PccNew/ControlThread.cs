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
            if (ThreadPcc == null)
            ThreadPcc = new Thread(new ParameterizedThreadStart(PccControl.PCCThreadFunc));
            ThreadPcc.Start();
        }
        //DDJ
        private ControlLk LKcontrol = new ControlLk();
        private Thread[] ThreadNewLikuDDJList;
        private void StartThreadNewLikuDDJ()
        {
            if (ThreadNewLikuDDJList == null)
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
            if (ThreadNewLikuCscList == null)
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
            if (ocsThread == null)
            ocsThread = new Thread[OcsControl.ocsCarCount];
            for (int i = 0; i < OcsControl.ocsCarCount; i++)
            {
                ocsThread[i] = new Thread(new ParameterizedThreadStart(OcsControl.OcsThreadFunc));
                ocsThread[i].Start(i + 1);
            }
        }

        //OCS LIFT
        private Thread ThreadOcsLift;
        private ControlOcsLift OcsLiftcontrol = new ControlOcsLift();
        private void StartThreadOcsLift()
        {
            if (ThreadOcsLift == null)
            ThreadOcsLift = new Thread(new ParameterizedThreadStart(OcsLiftcontrol.OcsLiftThreadFunc));
            ThreadOcsLift.Start();
        }


        //AGV
        private ControlAgv agvControl = new ControlAgv();
        private Thread[] agvThread;
        private void StartThreadAGV()
        {
            if (agvThread == null)
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
            if (ThreadNewLikuPallert == null)
            ThreadNewLikuPallert = new Thread(new ParameterizedThreadStart(LKcontrol.PallertThreadFunc));
            ThreadNewLikuPallert.Start();
        }

       
        public void threadStartAll()
        {
            //StartThreadPcc();
            StartThreadNewLikuDDJ();
            StartThreadNewLikuCsc();
            StartThreadOcs();
            StartThreadOcsLift();
            StartThreadNewLikuPallert();
            StartThreadAGV();
        }

        public void threadStopAll()
        {
            ThreadPcc.Abort();
            for (int i = 0; i < ThreadNewLikuDDJList.Length; i++)
            {
                ThreadNewLikuDDJList[i].Abort();
            }
            for (int i = 0; i < ThreadNewLikuCscList.Length; i++)
            {
                ThreadNewLikuCscList[i].Abort();
            }
            for (int i = 0; i < ocsThread.Length; i++)
            {
                ocsThread[i].Abort();
            }
            for (int i = 0; i < agvThread.Length; i++)
            {
                agvThread[i].Abort();
            }
            ThreadOcsLift.Abort();
            ThreadNewLikuPallert.Abort();
        }

        public void threadPauseAll()
        {
            PccControl.IsStart = false;
            LKcontrol.IsStart = false;
            OcsControl.IsStart = false;
            OcsLiftcontrol.IsStart = false;
            agvControl.IsStart = false;
        }

        public void threadContinueAll()
        {
            PccControl.IsStart = true;
            LKcontrol.IsStart = true;
            OcsControl.IsStart = true;
            OcsLiftcontrol.IsStart = true;
            agvControl.IsStart = true;
        }
    }
}
