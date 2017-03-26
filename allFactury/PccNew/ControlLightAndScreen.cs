using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZYB.Control;
namespace PccNew
{
     public  class ControlLightAndScreen
    {
        private int ThreadTime = 300;
        public int handle = 1;
        public int AgvCount = 5;
        public bool IsStart = false;
         public void LightThreadFunc()
         {
             int[] index = new int[3];
             index[0] = GetIdex.getDicOutputIndex("ATTRIBUTE01_light1_LIGHT_STATE1");
             index[1] = GetIdex.getDicOutputIndex("ATTRIBUTE01_light1_LIGHT_STATE2");
             index[2] = GetIdex.getDicOutputIndex("ATTRIBUTE01_light1_LIGHT_STATE3");

             ComTCPLib.SetOutputAsUINT(1, index[0], UInt16.Parse("1"));
             ComTCPLib.SetOutputAsUINT(1, index[1], UInt16.Parse("1"));
             ComTCPLib.SetOutputAsUINT(1, index[2], UInt16.Parse("2"));
         }

         public void controlScreen()
         {
             GetIdex gi = new GetIdex();
             if (IsStart)
             {
                 bool flag = false;
                 if (!flag)
                 {
                     flag = true;
                     for (int m = 0; m < 3; m++)
                     {
                         if (bool.Parse(gi.readValue("SCREEN" + (m + 1).ToString() + "01_ButtonPress", 3, 1).ToString()))
                         {
                             Browser bb = new Browser();
                             string mesLink = "http://10.1.50.93:8080/mes/main.shtml";
                             bb.url = mesLink;
                             bb.ShowDialog();
                             if (bb.DialogResult == System.Windows.Forms.DialogResult.OK)
                             {
                                 bb.Close();
                             }
                         }
                     }
                     flag = false;
                 }
             }
         }
    }
}
