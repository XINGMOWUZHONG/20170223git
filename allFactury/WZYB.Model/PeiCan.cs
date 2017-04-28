using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZYB.Model
{
    public class PeiCan
    {
        public PeiCan()
		{}
		#region Model
        private uint _id;
        private uint _source;
        private uint _target;
        private uint _target_z;
		private long _currentlocation;
        private uint _carstate;
        private uint _palletstate;
        private uint _taskstate;
        private uint _complatestate;
		private DateTime _time;
		private string _additional;
		/// <summary>
		/// 
		/// </summary>
        public uint id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
        public uint source
		{
			set{ _source=value;}
			get{return _source;}
		}
		/// <summary>
		/// 
		/// </summary>
        public uint target
		{
			set{ _target=value;}
			get{return _target;}
		}
		/// <summary>
		/// 
		/// </summary>
        public uint target_z
		{
			set{ _target_z=value;}
			get{return _target_z;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long currentlocation
		{
			set{ _currentlocation=value;}
			get{return _currentlocation;}
		}
		/// <summary>
		/// 
		/// </summary>
        public uint Carstate
		{
			set{ _carstate=value;}
			get{return _carstate;}
		}
		/// <summary>
		/// 
		/// </summary>
        public uint Palletstate
		{
			set{ _palletstate=value;}
			get{return _palletstate;}
		}
		/// <summary>
		/// 
		/// </summary>
        public uint TaskState
		{
			set{ _taskstate=value;}
			get{return _taskstate;}
		}
		/// <summary>
		/// 
		/// </summary>
        public uint ComplateState
		{
			set{ _complatestate=value;}
			get{return _complatestate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Time
		{
			set{ _time=value;}
			get{return _time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Additional
		{
			set{ _additional=value;}
			get{return _additional;}
		}
		#endregion Model
    }
}
