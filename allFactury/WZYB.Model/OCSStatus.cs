using System;
namespace WZYB.Model
{
	/// <summary>
	/// 实体类OCSStatus
	/// </summary>
	[Serializable]
    public class OCSStatus : IComparable
	{
        #region Model
        private int _carid;
        private string _line;
        private int _displayState;
        private decimal? _position;
        /// <summary>
        /// 车辆ID
        /// </summary>
        public int carId
        {
            set { _carid = value; }
            get { return _carid; }
        }

        public int displayState
        {
            set { _displayState = value; }
            get { return _displayState; }
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
        /// 具体位置
        /// </summary>
        public decimal? position
        {
            set { _position = value; }
            get { return _position; }
        }
        #endregion Model

        public int CompareTo(object obj)
        {
            int res = 0;
            try
            {
                
                    res = 1;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
            return res;
        }

	}
}

