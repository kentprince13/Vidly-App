using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly_App.Models;
using Vidly_App.Models.ViewModels;

namespace Vidly_App.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: Customer
        // without using DataTables
        //public ActionResult Index()
        //{
        //    var customers = _context.Customer.Include(c=>c.MembershipType).ToList();
        //    return View(customers);
        //}
       // [Authorize(Roles = "CanManageMovies")]
        public ActionResult Index()
        {
            return !User.IsInRole("CanManageMovies") ? View("Readonly") : View("custIndex");
        }

        
        public ActionResult Details(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        public ActionResult Create()
        {
            var vm = new NewFormViewModel
            {
                MembershipTypes = _context.membershipTypes.ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(NewFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var vm = new NewFormViewModel
                {
                    MembershipTypes = _context.membershipTypes.ToList()
                };
                return View("create",vm);
            }

            if (viewModel.Id <= 0)
            {
                var customer = new Customer
                {
                    DateOfBirth = viewModel.DateOfBirth,
                    IsSubcribed = viewModel.IsSubcribed,
                    MembershipTypeId = viewModel.membershipTypesId,
                    Name = viewModel.FirstName + " " + viewModel.LastName
                };
                _context.Customer.Add(customer);
                _context.SaveChanges();
            }
            else
            {
                var edit = _context.Customer.Single(c => c.Id == viewModel.Id);
                edit.IsSubcribed = viewModel.IsSubcribed;
                edit.MembershipTypeId = viewModel.membershipTypesId;
                edit.Name = viewModel.FirstName + " " + viewModel.LastName;
                edit.DateOfBirth = viewModel.DateOfBirth;
                _context.SaveChanges();
            }
            return RedirectToAction("custIndex");
        }
       
        public ActionResult Edit(int id)
        {
            var customer = _context.Customer.Single(c => c.Id == id);
            if(customer == null)
            {
                return HttpNotFound();
            };
            var cust = customer.Name.Split(' ');
            var vm = new NewFormViewModel
            {
                MembershipTypes = _context.membershipTypes.ToList(),
                LastName = cust[1],
                FirstName = cust[0],
                DateOfBirth = customer.DateOfBirth,
                IsSubcribed =customer.IsSubcribed,
                membershipTypesId = customer.MembershipTypeId
            };

            return View("create",vm);
        }
    }
}