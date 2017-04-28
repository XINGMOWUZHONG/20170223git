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
        private uint _LiftId;
        private uint _LiftTopstate;
        private uint _LiftDownstate;
        /// <summary>
        /// ����ID
        /// </summary>
        public uint LiftId
        {
            set { _LiftId = value; }
            get { return _LiftId; }
        }
      
        /// <summary>
        /// ����0ֹͣ��1��ǰ��2���
        /// </summary>
        public uint LiftTopstate
        {
            set { _LiftTopstate = value; }
            get { return _LiftTopstate; }
        }
        /// <summary>
        /// ����������˳��
        /// </summary>
        public uint LiftDownstate
        {
            set { _LiftDownstate = value; }
            get { return _LiftDownstate; }
        }
      
        #endregion

	}
}

