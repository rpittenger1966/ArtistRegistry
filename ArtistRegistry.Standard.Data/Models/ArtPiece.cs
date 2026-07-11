using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data
{
	/*  this is automatically generated code from Code Generator app - do not modify */

	public partial class ArtPiece
	{
		public int ArtPieceId { get; set; }
		public string Category { get; set; }
		public int ContactId { get; set; }
		public DateTime CreateDate { get; set; }
		public string Medium { get; set; }
		public DateTime? ModifyDate { get; set; }
		public int? Price { get; set; }
		public string Size { get; set; }
		public string Title { get; set; }


		public ArtPiece()
		{
			ArtPieceId = 0;
			Category = "";
			ContactId = 0;
			CreateDate = DateTime.Now;
			Medium = "";
			ModifyDate = null;
			Price = null;
			Size = "";
			Title = "";
		}




	}  // end of class
}  // end of namespace
