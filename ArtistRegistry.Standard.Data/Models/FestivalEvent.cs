using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data
{
	/*  this is automatically generated code from Code Generator app - do not modify */

	public partial class FestivalEvent
	{
		public DateTime CreateDate { get; set; }
		public DateTime EndDate { get; set; }
		public int FestivalEventId { get; set; }
		public int FestivalId { get; set; }
		public DateTime? ModifyDate { get; set; }
		public DateTime StartDate { get; set; }


		public FestivalEvent()
		{
			CreateDate = DateTime.Now;
			EndDate = DateTime.Now;
			FestivalEventId = 0;
			FestivalId = 0;
			ModifyDate = null;
			StartDate = DateTime.Now;
		}




	}  // end of class
}  // end of namespace
