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
		public string ArtCallUrl { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime EndDate { get; set; }
		public DateTime? EntryDeadline { get; set; }
		public int? EntryStatus { get; set; }
		public int GalleryExhibitionId { get; set; }
		public int GalleryId { get; set; }
		public DateTime? ModifyDate { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		public string ProspectusUrl { get; set; }
		public DateTime StartDate { get; set; }


		public GalleryExhibition()
		{
			ArtCallUrl = "";
			CreateDate = DateTime.Now;
			EndDate = DateTime.Now;
			EntryDeadline = null;
			EntryStatus = null;
			GalleryExhibitionId = 0;
			GalleryId = 0;
			ModifyDate = null;
			Name = "";
			Notes = "";
			ProspectusUrl = "";
			StartDate = DateTime.Now;
		}




	}  // end of class
}  // end of namespace
