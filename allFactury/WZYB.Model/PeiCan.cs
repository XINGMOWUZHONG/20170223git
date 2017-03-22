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
		private int _id;
		private int _source;
		private int _target;
		private int _target_z;
		private long _currentlocation;
		private int _carstate;
		private int _palletstate;
		private int _taskstate;
		private int _complatestate;
		private DateTime _time;
		private string _additional;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int source
		{
			set{ _source=value;}
			get{return _source;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int target
		{
			set{ _target=value;}
			get{return _target;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int target_z
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
		public int Carstate
		{
			set{ _carstate=value;}
			get{return _carstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Palletstate
		{
			set{ _palletstate=value;}
			get{return _palletstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TaskState
		{
			set{ _taskstate=value;}
			get{return _taskstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ComplateState
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
