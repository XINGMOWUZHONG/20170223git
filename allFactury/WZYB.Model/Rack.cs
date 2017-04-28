using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZYB.Model
{
    /// <summary>
    /// 实体类Rack
	/// </summary>
    [Serializable]
    public class Rack
    {
        #region Model
        private uint _id;
        private uint _Rack_type;
        private uint _Rack_row;
        private uint _Rack_colum;
        private uint _Rack_id;
        private uint _Rack_state;
        private uint _Rack_z;
        /// <summary>
        /// 穿梭车ID
        /// </summary>
        public uint id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 货架类型//1 新立库 2 双身为 3 配餐  4老库 5 窄巷道
        /// </summary>
        public uint Rack_type
        {
            set { _Rack_type = value; }
            get { return _Rack_type; }
        }

        /// <summary>
        /// 行
        /// </summary>
        public uint Rack_row
        {
            set { _Rack_row = value; }
            get { return _Rack_row; }
        }

        /// <summary>
        /// 列
        /// </summary>
        public uint Rack_colum
        {
            set { _Rack_colum = value; }
            get { return _Rack_colum; }
        }

        /// <summary>
        /// 货位标识
        /// </summary>
        public uint Rack_id
        {
            set { _Rack_id = value; }
            get { return _Rack_id; }
        }

        /// <summary>
        /// 货位状态
        /// </summary>
        public uint Rack_state
        {
            set { _Rack_state = value; }
            get { return _Rack_state; }
        }


        /// <summary>
        /// 货位z轴
        /// </summary>
        public uint Rack_z
        {
            set { _Rack_z = value; }
            get { return _Rack_z; }
        }

        #endregion Model
    }
}
