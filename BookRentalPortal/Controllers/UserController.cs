using BookRentalPortal.Models;
using BookRentalPortal.Utility;
using BookRentalPortal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookRentalPortal.Controllers
{
    [Authorize(Roles = SD.AdminUserRole)]

    public class UserController : Controller
    {

        private ApplicationDbContext db;

        public UserController()
        {
            db = ApplicationDbContext.Create();
        }

        // GET: User
        // retrive all users
        public ActionResult Index()
        {
            var user = from u in db.Users
                       join m in db.MembershipTypes on u.MembershipTypeId equals m.Id
                       select new UserViewModel
                       {
                           Id = u.Id,
                           FirstName = u.FirstName,
                           LastName = u.LastName,
                           Email = u.Email,
                           Phone = u.Phone,
                           BirthDate = u.BirthDate,
                           MembershipTypeId = u.MembershipTypeId,
                           MembershipTypes = (ICollection<MembershipType>)db.MembershipTypes.ToList().Where(n => n.Id.Equals(u.MembershipTypeId)),
                           Disabled = u.Disabled
                       };

            var userList = user.ToList();

            return View(userList);
        }

        //GET: Edit User
        // retrive details of selected user for edit 
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            else
            {
                UserViewModel model = new UserViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    Id = user.Id,
                    MembershipTypeId = user.MembershipTypeId,
                    Phone = user.Phone,
                    Disabled = user.Disabled,
                    MembershipTypes = db.MembershipTypes.ToList()
                };

                return View(model);
            }

        }

        //POST: Edit User
        // post method for edit details of user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                UserViewModel model = new UserViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    Id = user.Id,
                    MembershipTypeId = user.MembershipTypeId,
                    Phone = user.Phone,
                    Disabled = user.Disabled,
                    MembershipTypes = db.MembershipTypes.ToList()
                };

                return View("Edit", model);
            }
            else
            {
                var userInDb = db.Users.Single(u => u.Id.Equals(user.Id));
                userInDb.FirstName = user.FirstName;
                userInDb.LastName = user.LastName;
                userInDb.BirthDate = user.BirthDate;
                userInDb.Phone = user.Phone;
                userInDb.Email = user.Email;
                userInDb.MembershipTypeId = user.MembershipTypeId;
                userInDb.Disabled = user.Disabled;
            }

            db.SaveChanges();

            return RedirectToAction("Index", "User");

        }

        public ActionResult Details(string id)
        {

            if(id == null || id.Length == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApplicationUser user = db.Users.Find(id);

            UserViewModel model = new UserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Id = user.Id,
                MembershipTypeId = user.MembershipTypeId,
                Phone = user.Phone,
                Disabled = user.Disabled,
                MembershipTypes = db.MembershipTypes.ToList()
            };

            return View(model);
        }

        //Get: Delete User
        // retrive selected user detail for delete
        public ActionResult Delete(string id)
        {

            if (id == null || id.Length == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApplicationUser user = db.Users.Find(id);

            UserViewModel model = new UserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Id = user.Id,
                MembershipTypeId = user.MembershipTypeId,
                Phone = user.Phone,
                Disabled = user.Disabled,
                MembershipTypes = db.MembershipTypes.ToList()
            };

            return View(model);
        }

        //Delete 
        // post method for deleting user
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var userInDb = db.Users.Find(id);

            if(id == null || id.Length == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            db.Users.Remove(userInDb);
            db.SaveChanges();
            return RedirectToAction("Index");
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