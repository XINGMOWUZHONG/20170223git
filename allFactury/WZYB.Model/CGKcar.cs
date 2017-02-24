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
    public class CGKcar
    {
        #region Model
        private int _CGKcar_id;
        private int _CGKcar_state;
        private float _CGKcar_tgt;
        private float _CGKcar_source;
        private float _CGKcar_current;
        private int _CGKcar_pallertstate;
        /// <summary>
        /// 穿梭车ID
        /// </summary>
        public int CGKcar_id
        {
            set { _CGKcar_id = value; }
            get { return _CGKcar_id; }
        }
        /// <summary>
        /// 穿梭车状态
        /// </summary>
        public int CGKcar_state
        {
            set { _CGKcar_state = value; }
            get { return _CGKcar_state; }
        }
        /// <summary>
        /// 穿梭车目标
        /// </summary>
        public float CGKcar_tgt
        {
            set { _CGKcar_tgt = value; }
            get { return _CGKcar_tgt; }
        }
        /// <summary>
        /// 穿梭车原位置
        /// </summary>
        public float CGKcar_source
        {
            set { _CGKcar_source = value; }
            get { return _CGKcar_source; }
        }
        /// <summary>
        /// 穿梭车当前位置
        /// </summary>
        public float CGKcar_current
        {
            set { _CGKcar_current = value; }
            get { return _CGKcar_current; }
        }
        /// <summary>
        /// 穿梭车托盘状态
        /// </summary>
        public int CGKcar_pallertstate
        {
            set { _CGKcar_pallertstate = value; }
            get { return _CGKcar_pallertstate; }
        }
        #endregion Model
    }
}
