using System;
namespace WZYB.Model
{
	/// <summary>
	/// ʵ����OCSStatus
	/// </summary>
	[Serializable]
    public class OCSLift 
	{
        #region Model
        private int _LiftId;
        private int _LiftTopstate;
        private int _LiftDownstate;
        /// <summary>
        /// ����ID
        /// </summary>
        public int LiftId
        {
            set { _LiftId = value; }
            get { return _LiftId; }
        }
      
        /// <summary>
        /// ����0ֹͣ��1��ǰ��2���
        /// </summary>
        public int LiftTopstate
        {
            set { _LiftTopstate = value; }
            get { return _LiftTopstate; }
        }
        /// <summary>
        /// ����������˳��
        /// </summary>
        public int LiftDownstate
        {
            set { _LiftDownstate = value; }
            get { return _LiftDownstate; }
        }
      
        #endregion

	}
}

