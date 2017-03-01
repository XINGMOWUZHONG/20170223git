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
        private int _LiftId;
        private int _LiftTopstate;
        private int _LiftDownstate;
        /// <summary>
        /// 车辆ID
        /// </summary>
        public int LiftId
        {
            set { _LiftId = value; }
            get { return _LiftId; }
        }
      
        /// <summary>
        /// 方向0停止　1向前　2向后
        /// </summary>
        public int LiftTopstate
        {
            set { _LiftTopstate = value; }
            get { return _LiftTopstate; }
        }
        /// <summary>
        /// 所在驱动段顺序
        /// </summary>
        public int LiftDownstate
        {
            set { _LiftDownstate = value; }
            get { return _LiftDownstate; }
        }
      
        #endregion

	}
}

