using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using VenMovie.Models;
using VenMovie.ViewModel;

namespace VenMovie.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var membership = _context.MembershipTypes.ToList();
            var CusMem = new CustomerMember
            {
                Customer = new Customer(),
                MembershipType = membership
            };
            return View(CusMem); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            //check if object is valid based on dataanotaion
            if (!ModelState.IsValid)
            {
                var viewmodel = new CustomerMember
                {
                    Customer = customer,
                    MembershipType = _context.MembershipTypes.ToList()
                };
                return View("New", viewmodel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var UpdateDB = _context.Customers.Single(c => c.Id == customer.Id);
                UpdateDB.Name = customer.Name;
                UpdateDB.BirthDate = customer.BirthDate;
                UpdateDB.IsSubscribedToNewLetter = customer.IsSubscribedToNewLetter;
                UpdateDB.MembershipTypeId = customer.MembershipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers"); 
        }
        public ViewResult Index()
        {

            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
            var viewmodel = new CustomerMember
            {
                Customer = customer,
                MembershipType = _context.MembershipTypes.ToList()
            };

            return View("New",viewmodel);
        }
    }
}