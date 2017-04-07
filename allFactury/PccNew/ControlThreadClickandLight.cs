using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WZYB.Control;

namespace PccNew
{

    public class ControlThreadClickandLight
    {
        private ControlClickAndLightThread clickControl = new ControlClickAndLightThread();
        private Thread[] clickThread;


        //type 1agv 2ddj  3pcc 4csc 5ocs 6 screen
        private void StartClickThread()
        {
            //if (clickThread == null)
                clickThread = new Thread[clickControl.AllCount];
            int m = 0;
            for (int i = 0; i < clickControl.AgvCount; i++)
            {
                string[] array = { (i+1).ToString (), "1" };
                clickThread[m] = new Thread(new ParameterizedThreadStart(clickControl.ClickThreadFunc));
                clickThread[m].Start(array);
                m++;
            }

            for (int i = 0; i < clickControl.DdjCount; i++)
            {
                string[] array = { (i + 1).ToString(), "2" };
                clickThread[m] = new Thread(new ParameterizedThreadStart(clickControl.ClickThreadFunc));
                clickThread[m].Start(array);
                m++;
            }

            for (int i = 0; i < clickControl.PccCount; i++)
            {
                string[] array = { (i + 1).ToString(), "3" };
                clickThread[m] = new Thread(new ParameterizedThreadStart(clickControl.ClickThreadFunc));
                clickThread[m].Start(array);
                m++;
            }

            for (int i = 0; i < clickControl.CscCount; i++)
            {
                string[] array = { (i + 1).ToString(), "4" };
                clickThread[m] = new Thread(new ParameterizedThreadStart(clickControl.ClickThreadFunc));
                clickThread[m].Start(array);
                m++;
            }

            for (int i = 0; i < clickControl.OcsCount; i++)
            {
                string[] array = { (i + 1).ToString(), "5" };
                clickThread[m] = new Thread(new ParameterizedThreadStart(clickControl.ClickThreadFunc));
                clickThread[m].Start(array);
                m++;
            }

            for (int i = 0; i < clickControl.MachineCount; i++)
            {
                string[] array = { (i + 1).ToString(), "6" };
                clickThread[m] = new Thread(new ParameterizedThreadStart(clickControl.ClickThreadFunc));
                clickThread[m].Start(array);
                m++;
            }
        }

        private Thread[] LightThread;
        private void StartLightThread()
        {
            //if (LightThread == null)
                LightThread = new Thread[clickControl.MachineCount];
            for (int i = 0; i < clickControl.MachineCount; i++)
            {
                LightThread[i] = new Thread(new ParameterizedThreadStart(clickControl.LightThreadFunc));
                LightThread[i].Start(i+1); 
            }
        }
       
        public void threadStartAll()
        {
            StartClickThread();
            StartLightThread();
        }

        public void threadStopAll()
        {
            if (clickThread!=null)
            for (int i = 0; i < clickThread.Length; i++)
            {
                clickThread[i].Abort();
            }
            if (LightThread != null)
            for (int i = 0; i < LightThread.Length; i++)
            {
                LightThread[i].Abort();
            }
        }

        public void threadPauseAll()
        {
            clickControl.IsStart = false;
        }

        public void threadContinueAll()
        {
            clickControl.IsStart = true;
        }

        public string[] getLinkAndType()
        {
            if (clickControl !=null && clickControl.IsStart == false &&  clickControl.TypeStr != 0 && clickControl.LinkStr .Length >0 )
            {
                string[] arrayA = {clickControl.TypeStr.ToString (),clickControl.LinkStr };
                setLinkAndType();
                return  arrayA;
            }
            return null;
        }

        public void setLinkAndType()
        {
            if (clickControl != null )
            {
                clickControl.TypeStr = 0;
                clickControl.LinkStr = "";
            }
        }
    }
}
