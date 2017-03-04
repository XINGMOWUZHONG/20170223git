using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PccNew
{
     public  class ControlLightAndScreen
    {
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

         }
    }
}
