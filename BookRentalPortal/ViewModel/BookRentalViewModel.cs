using BookRentalPortal.Models;
using BookRentalPortal.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace BookRentalPortal.ViewModel
{
    public class BookRentalViewModel
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Range(0, 1000)]
        public int Avaibility { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [DisplayName("Date Added")]
        [DisplayFormat(DataFormatString = "{0: MMM dd yyy}")]
        public DateTime? DateAdded { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        [DisplayName("Publication Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MMM dd yyy}")]
        public DateTime PublicationDate { get; set; }

        public int Pages { get; set; }

        [DisplayName("Product Dimension")]
        public string ProductDimension { get; set; }

        public string Publisher { get; set; }


        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MMM dd yyy}")]
        public DateTime? StartDate { get; set; }

        [DisplayName("Actual End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MMM dd yyy}")]
        public DateTime? ActualEndDate { get; set; }

        [DisplayName("Scheduled End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MMM dd yyy}")]
        public DateTime? ScheduledEndDate { get; set; }

        [DisplayName("Additional Charge")]
        public double? AdditionalCharge { get; set; }

        [DisplayName("Rental Price")]
        public double RentalPrice { get; set; }

        public string RentalDuration { get; set; }

        public string Status { get; set; }

        public double RentalPriceOneMonth { get; set; }

        public double RentalPriceSixMonth { get; set; }



        public string UserId { get; set; }

        public string Email { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Name { get { return FirstName + " " + LastName; } }

        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MMM dd yyy}")]
        public DateTime BirthDate { get; set; }

        public string ActionName
        {
            get
            {
                if (Status.ToLower().Contains(SD.Requested))
                {
                    return "Approve";
                }

                if (Status.ToLower().Contains(SD.Approved))
                {
                    return "PickUp";
                }

                if (Status.ToLower().Contains(SD.Rented))
                {
                    return "Return"; 
                }
                return null;
            }
        }
    }
}