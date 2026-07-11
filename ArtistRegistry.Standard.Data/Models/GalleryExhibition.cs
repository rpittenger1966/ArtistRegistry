using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data
{
	/*  this is automatically generated code from Code Generator app - do not modify */

	public partial class GalleryExhibition
	{
		public DateTime CreateDate { get; set; }
		public DateTime EndDate { get; set; }
		public int GalleryExhibitionId { get; set; }
		public int GalleryId { get; set; }
		public DateTime? ModifyDate { get; set; }
		public DateTime StartDate { get; set; }


		public GalleryExhibition()
		{
			CreateDate = DateTime.Now;
			EndDate = DateTime.Now;
			GalleryExhibitionId = 0;
			GalleryId = 0;
			ModifyDate = null;
			StartDate = DateTime.Now;
		}




	}  // end of class
}  // end of namespace
