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
    public class CGKddj
    {
        #region Model
        private int _CGKddj_id;
        private int _CGKddj_state;
        private float _CGKddj_tgt;
        private float _CGKddj_source;
        private float _CGKddj_current;
        private float _CGKddj_forktgt;
        private float _CGKddj_platformtgt;
        private int _CGKddj_pallertstate;
        /// <summary>
        /// 堆垛机ID
        /// </summary>
        public int CGKddj_id
        {
            set { _CGKddj_id = value; }
            get { return _CGKddj_id; }
        }
        /// <summary>
        /// 堆垛机状态
        /// </summary>
        public int CGKddj_state
        {
            set { _CGKddj_state = value; }
            get { return _CGKddj_state; }
        }
        /// <summary>
        /// 堆垛机目标
        /// </summary>
        public float CGKddj_tgt
        {
            set { _CGKddj_tgt = value; }
            get { return _CGKddj_tgt; }
        }
        /// <summary>
        /// 堆垛机启动位置
        /// </summary>
        public float CGKddj_source
        {
            set { _CGKddj_source = value; }
            get { return _CGKddj_source; }
        }
        /// <summary>
        /// 堆垛机当前位置
        /// </summary>
        public float CGKddj_current
        {
            set { _CGKddj_current = value; }
            get { return _CGKddj_current; }
        }
        /// <summary>
        /// 堆垛机货叉目标
        /// </summary>
        public float CGKddj_forktgt
        {
            set { _CGKddj_forktgt = value; }
            get { return _CGKddj_forktgt; }
        }



        /// <summary>
        /// 堆垛机平台目标
        /// </summary>
        public float CGKddj_platformtgt
        {
            set { _CGKddj_platformtgt = value; }
            get { return _CGKddj_platformtgt; }
        }

        /// <summary>
        /// 堆垛托盘状态
        /// </summary>
        public int CGKddj_pallertstate
        {
            set { _CGKddj_pallertstate = value; }
            get { return _CGKddj_pallertstate; }
        }

        #endregion Model
    }
}
