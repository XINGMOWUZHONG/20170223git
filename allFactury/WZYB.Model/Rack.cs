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
        private int _id;
        private int _Rack_type;
        private int _Rack_row;
        private int _Rack_colum;
        private int _Rack_id;
        private int _Rack_state;
        private int _Rack_z;
        /// <summary>
        /// 穿梭车ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 货架类型 1 新立库 2 配餐 3 老立库
        /// </summary>
        public int Rack_type
        {
            set { _Rack_type = value; }
            get { return _Rack_type; }
        }

        /// <summary>
        /// 行
        /// </summary>
        public int Rack_row
        {
            set { _Rack_row = value; }
            get { return _Rack_row; }
        }

        /// <summary>
        /// 列
        /// </summary>
        public int Rack_colum
        {
            set { _Rack_colum = value; }
            get { return _Rack_colum; }
        }

        /// <summary>
        /// 货位标识
        /// </summary>
        public int Rack_id
        {
            set { _Rack_id = value; }
            get { return _Rack_id; }
        }

        /// <summary>
        /// 货位状态
        /// </summary>
        public int Rack_state
        {
            set { _Rack_state = value; }
            get { return _Rack_state; }
        }


        /// <summary>
        /// 货位z轴
        /// </summary>
        public int Rack_z
        {
            set { _Rack_z = value; }
            get { return _Rack_z; }
        }

        #endregion Model
    }
}
