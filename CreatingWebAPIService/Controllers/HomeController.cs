using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CreatingWebAPIService;
using CreatingWebAPIService.Models;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Diagnostics;
using CreatingWebAPIService.Controllers;

namespace CreatingWebAPIService.Controllers
{
    public class HomeController : ApiController
    {
        [HttpPost]
        public IHttpActionResult AddEmpDetails(CustModel cust)
        {
 
            string password = cust.Pass;
            string Name = cust.Name;
            string value;
            var Affirm = new AffirmModel();

            using (LinqToDBDataContext con = new LinqToDBDataContext())
            {
                var query = (from p in con.Customers
                             where p.CustomerName == Name
                             select p.CustomerPassword).FirstOrDefault();
                value = query.ToString();
                if (value == password)
                {
                    Affirm.AffirmLogIn = true;
                }
                else
                {
                    Affirm.AffirmLogIn = false;
                }
                var query1 = (from p in con.Customers
                             where p.CustomerName == Name
                             select p.CustomerID).FirstOrDefault();
                value = query1.ToString();
                Affirm.CustId = value;

                var json = new JavaScriptSerializer().Serialize(Affirm);
                return new RawJsonActionResult(json);
            }
        }

        [HttpGet]
        public void GetEmpDetails()
        {

        }
        [HttpDelete]
        public void DeleteEmpDetails(string id)
        {
         

        }
        [HttpPut]
        public void UpdateEmpDetails(string Name)
        {

        }
    }

}

