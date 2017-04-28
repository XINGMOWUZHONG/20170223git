using System;
namespace WZYB.Model
{
	/// <summary>
	/// 实体类OCSStatus
	/// </summary>
	[Serializable]
    public class OCSLift 
	{
        #region Model
        private uint _LiftId;
        private uint _LiftTopstate;
        private uint _LiftDownstate;
        /// <summary>
        /// 车辆ID
        /// </summary>
        public uint LiftId
        {
            set { _LiftId = value; }
            get { return _LiftId; }
        }
      
        /// <summary>
        /// 方向0停止　1向前　2向后
        /// </summary>
        public uint LiftTopstate
        {
            set { _LiftTopstate = value; }
            get { return _LiftTopstate; }
        }
        /// <summary>
        /// 所在驱动段顺序
        /// </summary>
        public uint LiftDownstate
        {
            set { _LiftDownstate = value; }
            get { return _LiftDownstate; }
        }
      
        #endregion

	}
}

