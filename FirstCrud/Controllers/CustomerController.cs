using FirstCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Core.Objects;
using System.Web.UI.WebControls;
using System.Data.Entity.Validation;

namespace FirstCrud.Controllers
{
    public class CustomerController : Controller
    {
        CustomerEntities db = new CustomerEntities();
        public ActionResult Index()
        {
            List<sp_viewAllCustomer_Result> lst = new List<sp_viewAllCustomer_Result>();
            lst = db.sp_viewAllCustomer().ToList();
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
       
        public ActionResult create(Customer tbl)
        {
            ObjectParameter para = new ObjectParameter("idout", typeof(int));
            int result = db.sp_insertupdate_customer(tbl.id, tbl.name, tbl.location, tbl.phone, para);
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int? id)
        {
            sp_viewCustomerById_Result obj = new sp_viewCustomerById_Result();
            obj = db.sp_viewCustomerById(id).FirstOrDefault();
            return View(obj);
        }
        [HttpPost]

        public ActionResult Edit(Customer tblobj)
        {
            ObjectParameter para = new ObjectParameter("idout", typeof(int));
            int result = db.sp_insertupdate_customer(tblobj.id, tblobj.name, tblobj.location, tblobj.phone, para);
            this.db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            sp_viewCustomerById_Result obj = new sp_viewCustomerById_Result();
            obj = db.sp_viewCustomerById(id).FirstOrDefault();
            return View(obj);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            int result = db.sp_customerDelete(id);
            this.db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}