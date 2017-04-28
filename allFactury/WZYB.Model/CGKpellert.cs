using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZYB.Model
{
    /// <summary>
	/// 实体类AGVStatus
	/// </summary>
    [Serializable]
    public class CGKpellert
    {
        #region Model
        private uint _CGKpellertid;
        private uint _CGKpellertstate;
        /// <summary>
        /// 托盘id
        /// </summary>
        public uint CGKpellertid
        {
            set { _CGKpellertid = value; }
            get { return _CGKpellertid; }
        }
        /// <summary>
        /// 所在驱动段
        /// </summary>
        public uint CGKpellertstate
        {
            set { _CGKpellertstate = value; }
            get { return _CGKpellertstate; }
        }
       
        #endregion Model
    }
}
