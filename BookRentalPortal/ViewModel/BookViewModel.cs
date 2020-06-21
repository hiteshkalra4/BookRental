using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookRentalPortal.Models;

namespace BookRentalPortal.ViewModel
{
    public class BookViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public Book Book {get;set;}

    }
}