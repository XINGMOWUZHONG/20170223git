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
        private int _CGKpellertid;
        private int _CGKpellertstate;
        /// <summary>
        /// 托盘id
        /// </summary>
        public int CGKpellertid
        {
            set { _CGKpellertid = value; }
            get { return _CGKpellertid; }
        }
        /// <summary>
        /// 所在驱动段
        /// </summary>
        public int CGKpellertstate
        {
            set { _CGKpellertstate = value; }
            get { return _CGKpellertstate; }
        }
       
        #endregion Model
    }
}
