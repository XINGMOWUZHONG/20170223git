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
    public partial class AGVStatus
    {
        public AGVStatus()
        { }
        #region Model
        private uint _id;
        private string _line;
        private uint _carstate;
        private uint _palletstate;
        private string _source;
        private string _target;
        private uint _taskstate;
        private uint _complatestate;
        private DateTime _nowtime;
        private string _additional;
        /// <summary>
        /// 车辆ID
        /// </summary>
        public uint id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 所在驱动段
        /// </summary>
        public string line
        {
            set { _line = value; }
            get { return _line; }
        }
        /// <summary>
        /// 
        /// </summary>
        public uint carstate
        {
            set { _carstate = value; }
            get { return _carstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public uint palletstate
        {
            set { _palletstate = value; }
            get { return _palletstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string target
        {
            set { _target = value; }
            get { return _target; }
        }
        /// <summary>
        /// 
        /// </summary>
        public uint taskstate
        {
            set { _taskstate = value; }
            get { return _taskstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public uint complatestate
        {
            set { _complatestate = value; }
            get { return _complatestate; }
        }
        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime nowtime
        {
            set { _nowtime = value; }
            get { return _nowtime; }
        }
        /// <summary>
        /// 预留字段
        /// </summary>
        public string additional
        {
            set { _additional = value; }
            get { return _additional; }
        }
        #endregion Model

    }
}
