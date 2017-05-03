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
        private ControlClickLight clickControl = new ControlClickLight();
        private Thread clickThread;


        //type 1agv 3ddj  2pcc 4ssj 5platform 7ocs 6 screen machine
        private void StartClickThread()
        {
            clickThread = new Thread(new ParameterizedThreadStart(clickControl.ClickThreadFunc));
            clickThread.Start();
             
        }

        private Thread[] LightThread;
        private void StartLightThread()
        { 
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
                clickThread.Abort();
            if (LightThread != null)
            {
                for (int i = 0; i < LightThread.Length; i++)
                {
                    LightThread[i].Abort();
                }
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
            if (clickControl !=null && clickControl.IsStart == false &&  clickControl.TypeStr != 0 && clickControl.LinkStr.Length >0 )
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
                clickControl.ResetClick();
            }
        }
    }
}
