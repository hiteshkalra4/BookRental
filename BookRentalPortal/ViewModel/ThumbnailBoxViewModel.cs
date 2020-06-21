using BookRentalPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookRentalPortal.ViewModel
{
    public class ThumbnailBoxViewModel
    {
        public IEnumerable<ThumbnailModel> Thumbnails { get; set; }
    }
}