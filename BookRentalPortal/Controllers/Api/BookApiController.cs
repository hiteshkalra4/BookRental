using BookRentalPortal.Models;
using BookRentalPortal.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookRentalPortal.Controllers.Api
{
    public class BookApiController : ApiController
    {
        private ApplicationDbContext db;

        public BookApiController()
        {
            db = ApplicationDbContext.Create();
        }

        // api to get the book title
        [HttpGet]
        public IHttpActionResult Get(string query = null)
        {
            var bookQuery = db.Books.Where(b => b.Title.ToLower().Contains(query.ToLower()));

            return Ok(bookQuery.ToList());
        }

        // api to get book price and availability 
        [HttpGet]
        public IHttpActionResult Get(string type, string isbn = null, string rentalDuration = null, string email = null )
        {
            if (type.Equals("price"))
            {
                Book bookQuery = db.Books.Where(b => b.ISBN.Equals(isbn)).SingleOrDefault();

                var chargeRate = from u in db.Users
                                 join m in db.MembershipTypes on u.MembershipTypeId equals m.Id
                                 where u.Email.Equals(email)
                                 select new { m.ChargeRateOneMonth, m.ChargeRateSixMonth };

                var price = Convert.ToDouble(bookQuery.Price) * Convert.ToDouble(chargeRate.ToList()[0].ChargeRateOneMonth) / 100;
                if(rentalDuration == SD.SixMonthCount)
                {
                    price = Convert.ToDouble(bookQuery.Price) * Convert.ToDouble(chargeRate.ToList()[0].ChargeRateSixMonth) / 100;

                }

                return Ok(price);
            }
            else
            {
                Book bookQuery = db.Books.Where(b => b.ISBN.Equals(isbn)).SingleOrDefault();

                return Ok(bookQuery.Avaibility);

            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }

    }
}
