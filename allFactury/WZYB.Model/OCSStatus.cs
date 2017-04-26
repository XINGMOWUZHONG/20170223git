using System;
namespace WZYB.Model
{
	/// <summary>
	/// ʵ����OCSStatus
	/// </summary>
	[Serializable]
    public class OCSStatus : IComparable
	{
        #region Model
        private int _carid;
        private string _line;
        private int _displayState;
        private float _position;
        /// <summary>
        /// ����ID
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
        /// ����������
        /// </summary>
        public string line
        {
            set { _line = value; }
            get { return _line; }
        }
    
        /// <summary>
        /// ����λ��
        /// </summary>
        public float position
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

