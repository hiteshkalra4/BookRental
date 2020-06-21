using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BookRentalPortal.Models
{
    public class IndividualButtonPartial
    {
        public string ButtonType  { get; set; }

        public string Action { get; set; }

        public string Glyph { get; set; }

        public string Text { get; set; }

        public int? GenreId { get; set; }

        public int? BookID { get; set; }

        public int? CustomerID { get; set; }

        public int? MemebershipTypeID { get; set; }

        public string UserId { get; set; }

        public int? BookRentalID { get; set; }



        public string ActionParameter
        {
            get
            {
                var param = new StringBuilder(@"/");

                if(GenreId != null && GenreId > 0)
                {
                    param.Append(string.Format("{0}", GenreId));
                }

                if (BookID != null && BookID > 0)
                {
                    param.Append(string.Format("{0}", BookID));
                }

                if (CustomerID != null && CustomerID > 0)
                {
                    param.Append(string.Format("{0}", CustomerID));
                }

                if (MemebershipTypeID != null && MemebershipTypeID > 0)
                {
                    param.Append(string.Format("{0}", MemebershipTypeID));
                }

                if (UserId != null && UserId.Trim().Length > 0)
                {
                    param.Append(string.Format("{0}", UserId));
                }

                if (BookRentalID != null && BookRentalID > 0)
                {
                    param.Append(string.Format("{0}", BookRentalID));
                }

                return param.ToString();

            }
        }
    }
}