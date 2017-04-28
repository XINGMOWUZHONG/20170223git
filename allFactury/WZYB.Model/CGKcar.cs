﻿using System;
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
        private uint _CGKcar_id;
        private uint _CGKcar_state;
        private uint _CGKcar_tgt;
        private uint _CGKcar_source;
        private uint _CGKcar_current;
        private uint _CGKcar_pallertstate;
        private uint _CGKcar_action;
        private uint _target_z;

        //private int _CGKcar_tgt_out_z;
        //private float _CGKcar_tgt_out_x;
        //private float _CGKcar_source_out;
        //private float _CGKcar_current_out;
        //private int _CGKcar_state_out;

        public uint target_z
        {
            set { _target_z = value; }
            get { return _target_z; }
        }


        /// <summary>
        /// 穿梭车ID
        /// </summary>
        public uint CGKcar_id
        {
            set { _CGKcar_id = value; }
            get { return _CGKcar_id; }
        }
        /// <summary>
        /// 穿梭车状态
        /// </summary>
        public uint CGKcar_state
        {
            set { _CGKcar_state = value; }
            get { return _CGKcar_state; }
        }
        /// <summary>
        /// 穿梭车目标
        /// </summary>
        public uint CGKcar_tgt
        {
            set { _CGKcar_tgt = value; }
            get { return _CGKcar_tgt; }
        }
        /// <summary>
        /// 穿梭车原位置
        /// </summary>
        public uint CGKcar_source
        {
            set { _CGKcar_source = value; }
            get { return _CGKcar_source; }
        }
        /// <summary>
        /// 穿梭车当前位置
        /// </summary>
        public uint CGKcar_current
        {
            set { _CGKcar_current = value; }
            get { return _CGKcar_current; }
        }
        /// <summary>
        /// 穿梭车托盘状态
        /// </summary>
        public uint CGKcar_pallertstate
        {
            set { _CGKcar_pallertstate = value; }
            get { return _CGKcar_pallertstate; }
        }

        /// <summary>
        /// 穿梭车 取货还是放货 0 静止 1 取货 2放货
        /// </summary>
        public uint CGKcar_action
        {
            set { _CGKcar_action = value; }
            get { return _CGKcar_action; }
        }


        //public float CGKcar_tgt_out_x
        //{
        //    set { _CGKcar_tgt_out_x = value; }
        //    get { return _CGKcar_tgt_out_x; }
        //}
        //public int CGKcar_tgt_out_z
        //{
        //    set { _CGKcar_tgt_out_z = value; }
        //    get { return _CGKcar_tgt_out_z; }
        //}
        //public float CGKcar_source_out
        //{
        //    set { _CGKcar_source_out = value; }
        //    get { return _CGKcar_source_out; }
        //}
        //public float CGKcar_current_out
        //{
        //    set { _CGKcar_current_out = value; }
        //    get { return _CGKcar_current_out; }
        //}
        //public int CGKcar_state_out
        //{
        //    set { _CGKcar_state_out = value; }
        //    get { return _CGKcar_state_out; }
        //}



        #endregion Model
    }
}
